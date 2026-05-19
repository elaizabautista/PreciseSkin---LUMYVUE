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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            PatientIDHistoryTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            SearchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic Light", 72F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SaddleBrown;
            label1.Location = new Point(86, 74);
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
            dataGridView1.Size = new Size(1425, 509);
            dataGridView1.TabIndex = 1;
            // 
            // PatientIDHistoryTxt
            // 
            PatientIDHistoryTxt.Location = new Point(161, 258);
            PatientIDHistoryTxt.Name = "PatientIDHistoryTxt";
            PatientIDHistoryTxt.Size = new Size(480, 23);
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
            label3.Location = new Point(656, 263);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Date:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(698, 256);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(904, 256);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(121, 23);
            SearchBtn.TabIndex = 6;
            SearchBtn.Text = "button1";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(1564, 850);
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
    }
}