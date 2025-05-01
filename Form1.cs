using System.Data;

namespace AttendanaceManagement
{
    public partial class Form1 : Form
    {
        private int autoSaveCountdown = 10;
        private bool isDataModified = false;
        private bool isCsvFileLoaded = false;

        private string currentCsvFilePath = null;
        private string todayColumn => DateTime.Today.ToString("yyyy-MM-dd");
        private DataTable originalDataTable = null;

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelAttendance.Text = $"Take Attendance (Today's Date: {DateTime.Today:yyyy-MM-dd})";
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new() { Filter = "CSV Files (*.csv)|*.csv" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            var lines = File.ReadAllLines(ofd.FileName);
            if (lines.Length == 0)
            {
                MessageBox.Show("CSV file is empty.");
                return;
            }

            currentCsvFilePath = ofd.FileName;
            var dt = LoadCsvToDataTable(lines);
            EnsureTodayColumn(dt);

            dataGridView1.DataSource = dt;
            ReplaceColumnWithCheckbox(todayColumn);
            originalDataTable = dt.Copy();

            UpdateStudentCountLabel();
            isCsvFileLoaded = true;
        }

        private DataTable LoadCsvToDataTable(string[] lines)
        {
            var dt = new DataTable();
            var headers = lines[0].Split(',');

            var booleanColumns = headers
                .Where(h => DateTime.TryParseExact(h, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
                .ToList();

            foreach (var header in headers)
                dt.Columns.Add(header, booleanColumns.Contains(header) ? typeof(bool) : typeof(string));

            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(',');
                var row = dt.NewRow();
                for (int j = 0; j < headers.Length; j++)
                {
                    var value = data[j];
                    row[headers[j]] = booleanColumns.Contains(headers[j]) ? bool.TryParse(value, out bool b) && b : value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void EnsureTodayColumn(DataTable dt)
        {
            if (dt.Columns.Contains(todayColumn)) return;

            int insertIndex = dt.Columns.Contains("Class") ? dt.Columns["Class"].Ordinal + 1 : dt.Columns.Count;
            dt.Columns.Add(todayColumn, typeof(bool));
            dt.Columns[todayColumn].SetOrdinal(insertIndex);

            foreach (DataRow row in dt.Rows)
                row[todayColumn] = false;
        }

        private void ReplaceColumnWithCheckbox(string columnName)
        {
            if (dataGridView1.Columns[columnName] is DataGridViewCheckBoxColumn) return;

            int index = dataGridView1.Columns[columnName].Index;
            dataGridView1.Columns.Remove(columnName);

            var checkboxColumn = new DataGridViewCheckBoxColumn
            {
                Name = columnName,
                HeaderText = columnName,
                DataPropertyName = columnName,
                TrueValue = true,
                FalseValue = false
            };

            dataGridView1.Columns.Insert(index, checkboxColumn);
        }

        private void UpdateStudentCountLabel()
        {
            labelStudentCount.Text = $"Number of Students: {(dataGridView1.DataSource as DataTable)?.Rows.Count ?? 0}";
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var dt = dataGridView1.DataSource as DataTable ?? CreateNewDataTable();

            if (!dt.Columns.Contains(todayColumn))
            {
                EnsureTodayColumn(dt);
                ReplaceColumnWithCheckbox(todayColumn);
            }

            var newRow = dt.NewRow();
            newRow["Name"] = txtName.Text;
            newRow["Class"] = txtClass.Text;
            newRow[todayColumn] = false;
            dt.Rows.Add(newRow);

            txtName.Clear();
            txtClass.Clear();

            originalDataTable = dt.Copy();
            UpdateStudentCountLabel();
            TriggerAutoSave();
        }

        private DataTable CreateNewDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Class");
            dt.Columns.Add(todayColumn, typeof(bool));

            dataGridView1.DataSource = dt;
            ReplaceColumnWithCheckbox(todayColumn);
            return dt;
        }

        private void TriggerAutoSave()
        {
            isDataModified = true;
            if (!isCsvFileLoaded) return;

            autoSaveCountdown = 10;
            labelAutoSave.Text = $"Auto-saving in: {autoSaveCountdown}s";
            timerAutoSave.Start();
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            SaveCSV(false);
        }

        private void SaveCSV(bool silent)
        {
            if (dataGridView1.DataSource is not DataTable dt)
            {
                if (!silent) MessageBox.Show("No data to save.");
                return;
            }

            if (string.IsNullOrEmpty(currentCsvFilePath))
            {
                if (silent) return;

                using SaveFileDialog sfd = new() { Filter = "CSV Files (*.csv)|*.csv" };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                currentCsvFilePath = sfd.FileName;
            }

            try
            {
                using StreamWriter sw = new(currentCsvFilePath, false);
                var headers = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
                sw.WriteLine(string.Join(",", headers));

                foreach (DataRow row in dt.Rows)
                {
                    var fields = dt.Columns.Cast<DataColumn>().Select(col =>
                        row[col] is bool b ? b.ToString().ToLower() : row[col]?.ToString() ?? string.Empty);
                    sw.WriteLine(string.Join(",", fields));
                }

                if (!silent)
                    MessageBox.Show("CSV file saved successfully!");
            }
            catch (IOException ex)
            {
                if (!silent) MessageBox.Show("File in use.\n" + ex.Message);
            }
            catch (Exception ex)
            {
                if (!silent) MessageBox.Show("Error saving file: " + ex.Message);
            }
        }

        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            if (!isDataModified)
            {
                labelAutoSave.Text = "All changes saved.";
                timerAutoSave.Stop();
                return;
            }

            autoSaveCountdown--;
            labelAutoSave.Text = $"Auto-saving in: {autoSaveCountdown}s";

            if (autoSaveCountdown <= 0)
            {
                SaveCSV(true);
                isDataModified = false;
                labelAutoSave.Text = "All changes saved.";
                timerAutoSave.Stop();
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                if (!row.IsNewRow) dataGridView1.Rows.Remove(row);

            UpdateStudentCountLabel();
            TriggerAutoSave();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (originalDataTable == null)
            {
                MessageBox.Show("Please load a CSV file first.");
                return;
            }

            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                ResetSearchResults();
                return;
            }

            string filter = $"Name LIKE '%{searchTerm}%' OR Class LIKE '%{searchTerm}%'";
            var matches = originalDataTable.Select(filter);

            if (matches.Length == 0)
            {
                labelSearchStatus.Text = "No students found.";
                ResetSearchResults();
                return;
            }

            var filtered = originalDataTable.Clone();
            foreach (var row in matches) filtered.ImportRow(row);

            dataGridView1.DataSource = filtered;
            ReplaceColumnWithCheckbox(todayColumn);
            labelSearchStatus.Text = $"Found {matches.Length} student(s).";

            HighlightMatchedRows();
            UpdateStudentCountLabel();
        }

        private void ResetSearchResults()
        {
            dataGridView1.DataSource = originalDataTable;
            ReplaceColumnWithCheckbox(todayColumn);
            labelSearchStatus.Text = "Showing all students.";
            UpdateStudentCountLabel();
        }

        private void HighlightMatchedRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.DefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e) => Application.Exit();

        private void redToolStripMenuItem_Click(object sender, EventArgs e) => panelRight.BackColor = Color.LightSteelBlue;

        private void greenToolStripMenuItem_Click(object sender, EventArgs e) => panelRight.BackColor = Color.SkyBlue;

        private void blueToolStripMenuItem_Click(object sender, EventArgs e) => panelRight.BackColor = SystemColors.ButtonHighlight;
    }
}
