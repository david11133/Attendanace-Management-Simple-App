namespace AttendanaceManagement
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelLeft = new Panel();
            btnLogout = new Button();
            femaleRadioButton = new RadioButton();
            maleRadioButton = new RadioButton();
            label1 = new Label();
            labelSearchStatus = new Label();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnDeleteStudent = new Button();
            labelAutoSave = new Label();
            labelHeader = new Label();
            labelName = new Label();
            txtName = new TextBox();
            btnAddStudent = new Button();
            panelRight = new Panel();
            labelAttendance = new Label();
            labelStudentCount = new Label();
            btnLoadCSV = new Button();
            btnSaveCSV = new Button();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newAttendanceFileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            colorsToolStripMenuItem = new ToolStripMenuItem();
            backgroundColorToolStripMenuItem = new ToolStripMenuItem();
            redToolStripMenuItem = new ToolStripMenuItem();
            greenToolStripMenuItem = new ToolStripMenuItem();
            blueToolStripMenuItem = new ToolStripMenuItem();
            timerAutoSave = new System.Windows.Forms.Timer(components);
            textColorToolStripMenuItem = new ToolStripMenuItem();
            darkBlueTextToolStripMenuItem = new ToolStripMenuItem();
            greenTextToolStripMenuItem = new ToolStripMenuItem();
            blackTextToolStripMenuItem = new ToolStripMenuItem();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.WhiteSmoke;
            panelLeft.Controls.Add(btnLogout);
            panelLeft.Controls.Add(femaleRadioButton);
            panelLeft.Controls.Add(maleRadioButton);
            panelLeft.Controls.Add(label1);
            panelLeft.Controls.Add(labelSearchStatus);
            panelLeft.Controls.Add(btnSearch);
            panelLeft.Controls.Add(txtSearch);
            panelLeft.Controls.Add(btnDeleteStudent);
            panelLeft.Controls.Add(labelAutoSave);
            panelLeft.Controls.Add(labelHeader);
            panelLeft.Controls.Add(labelName);
            panelLeft.Controls.Add(txtName);
            panelLeft.Controls.Add(btnAddStudent);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(20);
            panelLeft.Size = new Size(329, 650);
            panelLeft.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(20, 538);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 10, 0);
            btnLogout.Size = new Size(142, 45);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "🔒  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // femaleRadioButton
            // 
            femaleRadioButton.AutoSize = true;
            femaleRadioButton.Location = new Point(128, 219);
            femaleRadioButton.Name = "femaleRadioButton";
            femaleRadioButton.Size = new Size(93, 29);
            femaleRadioButton.TabIndex = 13;
            femaleRadioButton.TabStop = true;
            femaleRadioButton.Text = "Female";
            femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // maleRadioButton
            // 
            maleRadioButton.AutoSize = true;
            maleRadioButton.Location = new Point(23, 219);
            maleRadioButton.Name = "maleRadioButton";
            maleRadioButton.Size = new Size(75, 29);
            maleRadioButton.TabIndex = 12;
            maleRadioButton.TabStop = true;
            maleRadioButton.Text = "Male";
            maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 178);
            label1.Name = "label1";
            label1.Size = new Size(80, 28);
            label1.TabIndex = 11;
            label1.Text = "Gender:";
            // 
            // labelSearchStatus
            // 
            labelSearchStatus.AutoSize = true;
            labelSearchStatus.ForeColor = SystemColors.HotTrack;
            labelSearchStatus.Location = new Point(20, 490);
            labelSearchStatus.Name = "labelSearchStatus";
            labelSearchStatus.Size = new Size(0, 25);
            labelSearchStatus.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.Highlight;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(176, 436);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(124, 40);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 442);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 8;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.BackColor = Color.OrangeRed;
            btnDeleteStudent.FlatStyle = FlatStyle.Flat;
            btnDeleteStudent.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteStudent.ForeColor = Color.White;
            btnDeleteStudent.Location = new Point(20, 366);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(280, 40);
            btnDeleteStudent.TabIndex = 7;
            btnDeleteStudent.Text = "Delete Selected Student";
            btnDeleteStudent.UseVisualStyleBackColor = false;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // labelAutoSave
            // 
            labelAutoSave.AutoSize = true;
            labelAutoSave.ForeColor = Color.Green;
            labelAutoSave.Location = new Point(12, 616);
            labelAutoSave.Name = "labelAutoSave";
            labelAutoSave.Size = new Size(109, 25);
            labelAutoSave.TabIndex = 6;
            labelAutoSave.Text = "Auto-saving";
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.Location = new Point(20, 20);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(249, 38);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Add New Student";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelName.Location = new Point(20, 79);
            labelName.Name = "labelName";
            labelName.Size = new Size(68, 28);
            labelName.TabIndex = 1;
            labelName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(20, 110);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 34);
            txtName.TabIndex = 2;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.FromArgb(0, 120, 215);
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(20, 300);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(280, 40);
            btnAddStudent.TabIndex = 5;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = SystemColors.ButtonHighlight;
            panelRight.Controls.Add(labelAttendance);
            panelRight.Controls.Add(labelStudentCount);
            panelRight.Controls.Add(btnLoadCSV);
            panelRight.Controls.Add(btnSaveCSV);
            panelRight.Controls.Add(dataGridView1);
            panelRight.Controls.Add(menuStrip1);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(329, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(20);
            panelRight.Size = new Size(871, 650);
            panelRight.TabIndex = 0;
            // 
            // labelAttendance
            // 
            labelAttendance.AutoSize = true;
            labelAttendance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelAttendance.Location = new Point(20, 64);
            labelAttendance.Name = "labelAttendance";
            labelAttendance.Size = new Size(387, 32);
            labelAttendance.TabIndex = 0;
            labelAttendance.Text = "Take Attendance (Today's Date: )";
            // 
            // labelStudentCount
            // 
            labelStudentCount.AutoSize = true;
            labelStudentCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelStudentCount.Location = new Point(20, 586);
            labelStudentCount.Name = "labelStudentCount";
            labelStudentCount.Size = new Size(197, 28);
            labelStudentCount.TabIndex = 1;
            labelStudentCount.Text = "Number of Students: ";
            // 
            // btnLoadCSV
            // 
            btnLoadCSV.BackColor = Color.FromArgb(0, 120, 215);
            btnLoadCSV.FlatStyle = FlatStyle.Flat;
            btnLoadCSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadCSV.ForeColor = Color.White;
            btnLoadCSV.Location = new Point(582, 61);
            btnLoadCSV.Name = "btnLoadCSV";
            btnLoadCSV.Size = new Size(120, 41);
            btnLoadCSV.TabIndex = 2;
            btnLoadCSV.Text = "Load CSV";
            btnLoadCSV.UseVisualStyleBackColor = false;
            btnLoadCSV.Click += btnLoadCSV_Click;
            // 
            // btnSaveCSV
            // 
            btnSaveCSV.BackColor = Color.FromArgb(0, 153, 51);
            btnSaveCSV.FlatStyle = FlatStyle.Flat;
            btnSaveCSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveCSV.ForeColor = Color.White;
            btnSaveCSV.Location = new Point(718, 60);
            btnSaveCSV.Name = "btnSaveCSV";
            btnSaveCSV.Size = new Size(120, 42);
            btnSaveCSV.TabIndex = 3;
            btnSaveCSV.Text = "Save CSV";
            btnSaveCSV.UseVisualStyleBackColor = false;
            btnSaveCSV.Click += btnSaveCSV_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.Location = new Point(20, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(830, 473);
            dataGridView1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, colorsToolStripMenuItem });
            menuStrip1.Location = new Point(20, 20);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(831, 33);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newAttendanceFileToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // newAttendanceFileToolStripMenuItem
            // 
            newAttendanceFileToolStripMenuItem.Name = "newAttendanceFileToolStripMenuItem";
            newAttendanceFileToolStripMenuItem.Size = new Size(275, 34);
            newAttendanceFileToolStripMenuItem.Text = "New Attendance File";
            newAttendanceFileToolStripMenuItem.Click += newAttendanceFileToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(275, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click_1;
            // 
            // colorsToolStripMenuItem
            // 
            colorsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backgroundColorToolStripMenuItem, textColorToolStripMenuItem });
            colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            colorsToolStripMenuItem.Size = new Size(79, 29);
            colorsToolStripMenuItem.Text = "Colors";
            // 
            // backgroundColorToolStripMenuItem
            // 
            backgroundColorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { redToolStripMenuItem, greenToolStripMenuItem, blueToolStripMenuItem });
            backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            backgroundColorToolStripMenuItem.Size = new Size(270, 34);
            backgroundColorToolStripMenuItem.Text = "Background Color";
            // 
            // redToolStripMenuItem
            // 
            redToolStripMenuItem.Name = "redToolStripMenuItem";
            redToolStripMenuItem.Size = new Size(191, 34);
            redToolStripMenuItem.Text = "Light Blue";
            redToolStripMenuItem.Click += redToolStripMenuItem_Click;
            // 
            // greenToolStripMenuItem
            // 
            greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            greenToolStripMenuItem.Size = new Size(191, 34);
            greenToolStripMenuItem.Text = "Sky Blue";
            greenToolStripMenuItem.Click += greenToolStripMenuItem_Click;
            // 
            // blueToolStripMenuItem
            // 
            blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            blueToolStripMenuItem.Size = new Size(191, 34);
            blueToolStripMenuItem.Text = "Default";
            blueToolStripMenuItem.Click += blueToolStripMenuItem_Click;
            // 
            // timerAutoSave
            // 
            timerAutoSave.Interval = 1000;
            timerAutoSave.Tick += timerAutoSave_Tick;
            // 
            // textColorToolStripMenuItem
            // 
            textColorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkBlueTextToolStripMenuItem, greenTextToolStripMenuItem, blackTextToolStripMenuItem });
            textColorToolStripMenuItem.Name = "textColorToolStripMenuItem";
            textColorToolStripMenuItem.Size = new Size(270, 34);
            textColorToolStripMenuItem.Text = "Text Color";
            // 
            // darkBlueTextToolStripMenuItem
            // 
            darkBlueTextToolStripMenuItem.Name = "darkBlueTextToolStripMenuItem";
            darkBlueTextToolStripMenuItem.Size = new Size(270, 34);
            darkBlueTextToolStripMenuItem.Text = "Dark Blue";
            darkBlueTextToolStripMenuItem.Click += darkBlueTextToolStripMenuItem_Click;
            // 
            // greenTextToolStripMenuItem
            // 
            greenTextToolStripMenuItem.Name = "greenTextToolStripMenuItem";
            greenTextToolStripMenuItem.Size = new Size(270, 34);
            greenTextToolStripMenuItem.Text = "Green";
            greenTextToolStripMenuItem.Click += greenTextToolStripMenuItem_Click;
            // 
            // blackTextToolStripMenuItem
            // 
            blackTextToolStripMenuItem.Name = "blackTextToolStripMenuItem";
            blackTextToolStripMenuItem.Size = new Size(270, 34);
            blackTextToolStripMenuItem.Text = "Black";
            blackTextToolStripMenuItem.Click += blackTextToolStripMenuItem_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1200, 650);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Attendance Management System";
            Load += Form1_Load;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelRight;
        private Label labelHeader;
        private Label labelName;
        private TextBox txtName;
        private Button btnAddStudent;

        private Label labelAttendance;
        private Label labelStudentCount;
        private DataGridView dataGridView1;
        private Button btnLoadCSV;
        private Button btnSaveCSV;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem colorsToolStripMenuItem;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem redToolStripMenuItem;
        private ToolStripMenuItem greenToolStripMenuItem;
        private ToolStripMenuItem blueToolStripMenuItem;
        private Label labelAutoSave;
        private System.Windows.Forms.Timer timerAutoSave;
        private Button btnDeleteStudent;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label labelSearchStatus;
        private RadioButton femaleRadioButton;
        private RadioButton maleRadioButton;
        private Label label1;
        private ToolStripMenuItem newAttendanceFileToolStripMenuItem;
        private Button btnLogout;
        private ToolStripMenuItem textColorToolStripMenuItem;
        private ToolStripMenuItem darkBlueTextToolStripMenuItem;
        private ToolStripMenuItem greenTextToolStripMenuItem;
        private ToolStripMenuItem blackTextToolStripMenuItem;
    }
}
