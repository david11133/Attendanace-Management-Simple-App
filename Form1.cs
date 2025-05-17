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
            txtSearch.TextChanged += txtSearch_TextChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
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
            var headers = lines[0].Split(',').Where(h => h != "Class").ToArray();

            var booleanColumns = headers
                .Where(h => DateTime.TryParseExact(h, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
                .ToList();

            foreach (var header in headers)
                dt.Columns.Add(header, booleanColumns.Contains(header) ? typeof(bool) : typeof(string));

            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(',');
                var row = dt.NewRow();
                int columnIndex = 0;
                for (int j = 0; j < headers.Length; j++)
                {
                    var header = headers[j];
                    var value = data[columnIndex++];
                    row[header] = booleanColumns.Contains(header) ? bool.TryParse(value, out bool b) && b : value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void EnsureTodayColumn(DataTable dt)
        {
            if (dt.Columns.Contains(todayColumn)) return;

            int insertIndex = dt.Columns.Contains("Gender") ? dt.Columns["Gender"].Ordinal + 1 : dt.Columns.Count;
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

            if (maleRadioButton.Checked)
                newRow["Gender"] = "Male";
            else if (femaleRadioButton.Checked)
                newRow["Gender"] = "Female";
            else
                newRow["Gender"] = "Unspecified";

            newRow[todayColumn] = false;
            dt.Rows.Add(newRow);

            txtName.Clear();
            maleRadioButton.Checked = false;
            femaleRadioButton.Checked = false;

            originalDataTable = dt.Copy();
            UpdateStudentCountLabel();
            TriggerAutoSave();
        }

        private DataTable CreateNewDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Gender");
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

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit checkbox value immediately when edited
            if (dataGridView1.IsCurrentCellDirty)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnName == todayColumn)
                {
                    TriggerAutoSave(); // Save when today's attendance checkbox is changed
                }
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ResetSearchResults();
            }
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

            string filter = $"Name LIKE '%{searchTerm}%' OR Gender LIKE '%{searchTerm}%'";
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

        private void newAttendanceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to start a new attendance file? All unsaved data will be lost.",
                                   "Confirm New File", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            dataGridView1.DataSource = null;
            originalDataTable = null;
            currentCsvFilePath = null;
            isCsvFileLoaded = false;
            isDataModified = false;

            labelStudentCount.Text = "Number of Students: 0";
            labelAutoSave.Text = "Auto-save not started.";
            labelSearchStatus.Text = "";
            txtSearch.Clear();

            txtName.Clear();
            maleRadioButton.Checked = false;
            femaleRadioButton.Checked = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                var login = new LoginForm();
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
        }

        private void SetDataGridTextColor(Color color)
        {
            dataGridView1.DefaultCellStyle.ForeColor = color;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = color;
        }


        private void darkBlueTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDataGridTextColor(Color.DarkBlue);
        }

        private void greenTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDataGridTextColor(Color.DarkGreen);
        }

        private void blackTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDataGridTextColor(Color.Black);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e) => Application.Exit();

        private void redToolStripMenuItem_Click(object sender, EventArgs e) => panelRight.BackColor = Color.LightSteelBlue;

        private void greenToolStripMenuItem_Click(object sender, EventArgs e) => panelRight.BackColor = Color.SkyBlue;

        private void blueToolStripMenuItem_Click(object sender, EventArgs e) => panelRight.BackColor = SystemColors.ButtonHighlight;
    }
}
