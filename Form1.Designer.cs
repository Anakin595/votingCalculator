namespace VoteCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.PESEL = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pesell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surnamee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameTip = new System.Windows.Forms.Label();
            this.surnameTip = new System.Windows.Forms.Label();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.checkList = new System.Windows.Forms.CheckedListBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.loginPanel = new System.Windows.Forms.GroupBox();
            this.btnVote = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.resultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExport = new System.Windows.Forms.Button();
            this.dataGridParty = new System.Windows.Forms.DataGridView();
            this.Party = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Votes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParty)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(61, 23);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(110, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(567, 324);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(100, 13);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "VoteCalculator v1.0";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(61, 50);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(110, 20);
            this.textBoxSurname.TabIndex = 3;
            this.textBoxSurname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSurname.TextChanged += new System.EventHandler(this.textBoxSurname_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(20, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSurname.Location = new System.Drawing.Point(6, 53);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(56, 13);
            this.labelSurname.TabIndex = 6;
            this.labelSurname.Text = "Surname";
            // 
            // PESEL
            // 
            this.PESEL.AutoSize = true;
            this.PESEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PESEL.Location = new System.Drawing.Point(14, 80);
            this.PESEL.Name = "PESEL";
            this.PESEL.Size = new System.Drawing.Size(46, 13);
            this.PESEL.TabIndex = 7;
            this.PESEL.Text = "PESEL";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(79, 112);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 8;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pesell,
            this.Namee,
            this.Surnamee});
            this.dataGridView.Location = new System.Drawing.Point(13, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(330, 322);
            this.dataGridView.TabIndex = 9;
            // 
            // pesell
            // 
            this.pesell.DataPropertyName = "Name";
            this.pesell.HeaderText = "Candidate";
            this.pesell.Name = "pesell";
            this.pesell.ReadOnly = true;
            // 
            // Namee
            // 
            this.Namee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Namee.DataPropertyName = "Party";
            this.Namee.HeaderText = "Party";
            this.Namee.Name = "Namee";
            this.Namee.ReadOnly = true;
            this.Namee.Width = 5;
            // 
            // Surnamee
            // 
            this.Surnamee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Surnamee.DataPropertyName = "votesNumber";
            this.Surnamee.HeaderText = "Votes";
            this.Surnamee.Name = "Surnamee";
            this.Surnamee.ReadOnly = true;
            this.Surnamee.Width = 59;
            // 
            // nameTip
            // 
            this.nameTip.AutoSize = true;
            this.nameTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameTip.Location = new System.Drawing.Point(178, 25);
            this.nameTip.Name = "nameTip";
            this.nameTip.Size = new System.Drawing.Size(35, 13);
            this.nameTip.TabIndex = 10;
            this.nameTip.Text = "empty";
            // 
            // surnameTip
            // 
            this.surnameTip.AutoSize = true;
            this.surnameTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surnameTip.Location = new System.Drawing.Point(178, 50);
            this.surnameTip.Name = "surnameTip";
            this.surnameTip.Size = new System.Drawing.Size(35, 13);
            this.surnameTip.TabIndex = 10;
            this.surnameTip.Text = "empty";
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.BeepOnError = true;
            this.maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maskedTextBox.Location = new System.Drawing.Point(61, 76);
            this.maskedTextBox.Mask = "00000000000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(110, 20);
            this.maskedTextBox.TabIndex = 11;
            this.maskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox_MaskInputRejected_1);
            // 
            // checkList
            // 
            this.checkList.FormattingEnabled = true;
            this.checkList.Items.AddRange(new object[] {
            "Mieszko I \t\t\tPiastowie",
            "Bolesław Chrobry \t\tPiastowie",
            "Władysław Łokietek \t\tPiastowie",
            "Kazimierz Wielk \t\t\tPiastowie",
            "Władysław Jagiełło \t\tDynastia Jagiellonów",
            "Władysław Warneńczyk\t\tDynastia Jagiellonów",
            "Zygmunt Stary \t\t\tDynastia Jagiellonów",
            "Henryk Walezy \t\t\tElekcyjni dla Polski",
            "Anna Jagiellonka \t\tElekcyjni dla Polski",
            "Stefan Batory \t\t\tElekcyjni dla Polski",
            "Zygmunt Waza \t\t\tWazowie",
            "Władysław Waza \t\tWazowie",
            "Jan Kazimierz \t\t\tWazowie"});
            this.checkList.Location = new System.Drawing.Point(214, 13);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(295, 199);
            this.checkList.TabIndex = 13;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogout.Location = new System.Drawing.Point(570, 287);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(97, 34);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.labelName);
            this.loginPanel.Controls.Add(this.textBoxName);
            this.loginPanel.Controls.Add(this.textBoxSurname);
            this.loginPanel.Controls.Add(this.maskedTextBox);
            this.loginPanel.Controls.Add(this.labelSurname);
            this.loginPanel.Controls.Add(this.PESEL);
            this.loginPanel.Controls.Add(this.buttonLogin);
            this.loginPanel.Controls.Add(this.surnameTip);
            this.loginPanel.Controls.Add(this.nameTip);
            this.loginPanel.Location = new System.Drawing.Point(244, 86);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(228, 151);
            this.loginPanel.TabIndex = 15;
            this.loginPanel.TabStop = false;
            // 
            // btnVote
            // 
            this.btnVote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVote.Location = new System.Drawing.Point(304, 218);
            this.btnVote.Name = "btnVote";
            this.btnVote.Size = new System.Drawing.Size(111, 56);
            this.btnVote.TabIndex = 16;
            this.btnVote.Text = "VOTE";
            this.btnVote.UseVisualStyleBackColor = true;
            this.btnVote.Click += new System.EventHandler(this.btnVote_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(349, 311);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(85, 23);
            this.btnChart.TabIndex = 17;
            this.btnChart.Text = "Show chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // resultChart
            // 
            chartArea6.Name = "ChartArea";
            this.resultChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend";
            this.resultChart.Legends.Add(legend6);
            this.resultChart.Location = new System.Drawing.Point(-163, 12);
            this.resultChart.Name = "resultChart";
            this.resultChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series6.ChartArea = "ChartArea";
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series6.IsXValueIndexed = true;
            series6.Legend = "Legend";
            series6.Name = "Results";
            this.resultChart.Series.Add(series6);
            this.resultChart.Size = new System.Drawing.Size(950, 268);
            this.resultChart.TabIndex = 18;
            this.resultChart.Text = "Voting results";
            title6.Name = "Title1";
            title6.Text = "Voting results";
            this.resultChart.Titles.Add(title6);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(440, 311);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(96, 23);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export to file...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dataGridParty
            // 
            this.dataGridParty.AllowUserToAddRows = false;
            this.dataGridParty.AllowUserToDeleteRows = false;
            this.dataGridParty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridParty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Party,
            this.Votes});
            this.dataGridParty.Location = new System.Drawing.Point(349, 12);
            this.dataGridParty.Name = "dataGridParty";
            this.dataGridParty.ReadOnly = true;
            this.dataGridParty.Size = new System.Drawing.Size(250, 180);
            this.dataGridParty.TabIndex = 20;
            // 
            // Party
            // 
            this.Party.DataPropertyName = "Party";
            this.Party.HeaderText = "Party";
            this.Party.Name = "Party";
            this.Party.ReadOnly = true;
            // 
            // Votes
            // 
            this.Votes.DataPropertyName = "Votes";
            this.Votes.HeaderText = "Votes";
            this.Votes.Name = "Votes";
            this.Votes.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 346);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnVote);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.checkList);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.resultChart);
            this.Controls.Add(this.dataGridParty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "VoteCalculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label PESEL;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label nameTip;
        private System.Windows.Forms.Label surnameTip;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.CheckedListBox checkList;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox loginPanel;
        private System.Windows.Forms.Button btnVote;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart resultChart;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surnamee;
        private System.Windows.Forms.DataGridView dataGridParty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Party;
        private System.Windows.Forms.DataGridViewTextBoxColumn Votes;
    }
}

