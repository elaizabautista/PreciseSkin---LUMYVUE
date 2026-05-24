namespace PreciseSkin___LUMYVUE
{
    partial class AdminForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            PatientIDHistoryTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            SearchBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            txtSearchName = new TextBox();
            label4 = new Label();
            btnSearch = new Button();
            cmbFilterDisease = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic Light", 72F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SaddleBrown;
            label1.Location = new Point(86, 65);
            label1.Name = "label1";
            label1.Size = new Size(1073, 124);
            label1.TabIndex = 0;
            label1.Text = "PreciseSkin - LUMYVUE";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.MistyRose;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(86, 285);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1160, 490);
            dataGridView1.TabIndex = 1;
            // 
            // PatientIDHistoryTxt
            // 
            PatientIDHistoryTxt.Location = new Point(182, 258);
            PatientIDHistoryTxt.Name = "PatientIDHistoryTxt";
            PatientIDHistoryTxt.Size = new Size(459, 23);
            PatientIDHistoryTxt.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 264);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Patient ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 198);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Date:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(182, 192);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(647, 258);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(115, 23);
            SearchBtn.TabIndex = 6;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(182, 228);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(459, 23);
            txtSearchName.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 231);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 8;
            label4.Text = "Patient Name:";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(647, 227);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 23);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbFilterDisease
            // 
            cmbFilterDisease.FormattingEnabled = true;
            cmbFilterDisease.Items.AddRange(new object[] { "All", "Acne", "Eczema", "Hyperpigmentation", "Normal" });
            cmbFilterDisease.Location = new Point(867, 256);
            cmbFilterDisease.Name = "cmbFilterDisease";
            cmbFilterDisease.Size = new Size(379, 23);
            cmbFilterDisease.TabIndex = 10;
            cmbFilterDisease.SelectedIndexChanged += cmbFilterDisease_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(782, 264);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 11;
            label5.Text = "Disease Type:";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(1564, 850);
            Controls.Add(label5);
            Controls.Add(cmbFilterDisease);
            Controls.Add(btnSearch);
            Controls.Add(label4);
            Controls.Add(txtSearchName);
            Controls.Add(SearchBtn);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PatientIDHistoryTxt);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Name = "AdminForm";
            Text = "AdminForm";
            WindowState = FormWindowState.Maximized;
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        public DataGridView dataGridView1;
        public TextBox PatientIDHistoryTxt;
        public Label label2;
        public Label label3;
        public DateTimePicker dateTimePicker2;
        public Button SearchBtn;
        private TextBox textBox1;
        protected System.Windows.Forms.Timer timer1;
        private TextBox txtSearchName;
        public Label label4;
        public Button btnSearch;
        public ComboBox cmbFilterDisease;
        public Label label5;
    }
}