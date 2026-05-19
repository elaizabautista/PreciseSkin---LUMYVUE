namespace PreciseSkin___LUMYVUE
{
    partial class ImageIngestForm
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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSelectImage = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            picPatientUpload = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnRunDiagnostics = new Button();
            panel1 = new Panel();
            TxtLocation = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            TxtGender = new TextBox();
            TxtAge = new TextBox();
            TxtFullName = new TextBox();
            TxtPatientID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblpatientid = new Label();
            label6 = new Label();
            TxtContactNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPatientUpload).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(1924, 1061);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.Click += webView21_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Tan;
            flowLayoutPanel1.Controls.Add(btnSelectImage);
            flowLayoutPanel1.Location = new Point(977, 91);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(893, 59);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnSelectImage
            // 
            btnSelectImage.BackColor = Color.SeaShell;
            btnSelectImage.FlatStyle = FlatStyle.Flat;
            btnSelectImage.Font = new Font("Yu Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectImage.ForeColor = Color.SaddleBrown;
            btnSelectImage.Location = new Point(3, 3);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(890, 52);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "C H O O S E   F I L E";
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Tan;
            flowLayoutPanel3.Controls.Add(picPatientUpload);
            flowLayoutPanel3.Location = new Point(1107, 397);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(692, 498);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // picPatientUpload
            // 
            picPatientUpload.BackColor = Color.Transparent;
            picPatientUpload.BackgroundImageLayout = ImageLayout.Zoom;
            picPatientUpload.Location = new Point(3, 3);
            picPatientUpload.Name = "picPatientUpload";
            picPatientUpload.Size = new Size(689, 495);
            picPatientUpload.TabIndex = 0;
            picPatientUpload.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Linen;
            flowLayoutPanel2.Controls.Add(btnRunDiagnostics);
            flowLayoutPanel2.Location = new Point(1107, 901);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(692, 75);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // btnRunDiagnostics
            // 
            btnRunDiagnostics.BackColor = Color.Bisque;
            btnRunDiagnostics.FlatStyle = FlatStyle.Flat;
            btnRunDiagnostics.Font = new Font("Yu Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRunDiagnostics.Location = new Point(3, 3);
            btnRunDiagnostics.Name = "btnRunDiagnostics";
            btnRunDiagnostics.Size = new Size(689, 72);
            btnRunDiagnostics.TabIndex = 0;
            btnRunDiagnostics.Text = "S T A R T   S K I N   A N A L Y S I S";
            btnRunDiagnostics.UseVisualStyleBackColor = false;
            btnRunDiagnostics.Click += btnRunDiagnostics_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Snow;
            panel1.Controls.Add(TxtContactNumber);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TxtLocation);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(TxtGender);
            panel1.Controls.Add(TxtAge);
            panel1.Controls.Add(TxtFullName);
            panel1.Controls.Add(TxtPatientID);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblpatientid);
            panel1.Location = new Point(977, 156);
            panel1.Name = "panel1";
            panel1.Size = new Size(893, 113);
            panel1.TabIndex = 5;
            // 
            // TxtLocation
            // 
            TxtLocation.Location = new Point(570, 66);
            TxtLocation.Name = "TxtLocation";
            TxtLocation.Size = new Size(310, 23);
            TxtLocation.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(570, 41);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // TxtGender
            // 
            TxtGender.Location = new Point(570, 13);
            TxtGender.Name = "TxtGender";
            TxtGender.Size = new Size(310, 23);
            TxtGender.TabIndex = 8;
            // 
            // TxtAge
            // 
            TxtAge.Location = new Point(81, 60);
            TxtAge.Name = "TxtAge";
            TxtAge.Size = new Size(348, 23);
            TxtAge.TabIndex = 8;
            // 
            // TxtFullName
            // 
            TxtFullName.Location = new Point(81, 33);
            TxtFullName.Name = "TxtFullName";
            TxtFullName.Size = new Size(348, 23);
            TxtFullName.TabIndex = 7;
            // 
            // TxtPatientID
            // 
            TxtPatientID.Location = new Point(81, 7);
            TxtPatientID.Name = "TxtPatientID";
            TxtPatientID.Size = new Size(348, 23);
            TxtPatientID.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 9.75F);
            label5.Location = new Point(435, 74);
            label5.Name = "label5";
            label5.Size = new Size(64, 17);
            label5.TabIndex = 5;
            label5.Text = "Location:";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 9.75F);
            label4.Location = new Point(435, 47);
            label4.Name = "label4";
            label4.Size = new Size(137, 17);
            label4.TabIndex = 4;
            label4.Text = "Date of Consultation:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9.75F);
            label1.Location = new Point(435, 21);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 3;
            label1.Text = "Gender:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 9.75F);
            label3.Location = new Point(3, 62);
            label3.Name = "label3";
            label3.Size = new Size(34, 17);
            label3.TabIndex = 2;
            label3.Text = "Age:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 9.75F);
            label2.Location = new Point(3, 39);
            label2.Name = "label2";
            label2.Size = new Size(72, 17);
            label2.TabIndex = 1;
            label2.Text = "Full Name:";
            // 
            // lblpatientid
            // 
            lblpatientid.AutoSize = true;
            lblpatientid.Font = new Font("Yu Gothic", 9.75F);
            lblpatientid.Location = new Point(3, 13);
            lblpatientid.Name = "lblpatientid";
            lblpatientid.Size = new Size(74, 17);
            lblpatientid.TabIndex = 0;
            lblpatientid.Text = "Patient ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 9.75F);
            label6.Location = new Point(3, 86);
            label6.Name = "label6";
            label6.Size = new Size(113, 17);
            label6.TabIndex = 11;
            label6.Text = "Contact Number:";
            // 
            // TxtContactNumber
            // 
            TxtContactNumber.Location = new Point(122, 86);
            TxtContactNumber.Name = "TxtContactNumber";
            TxtContactNumber.Size = new Size(307, 23);
            TxtContactNumber.TabIndex = 12;
            // 
            // ImageIngestForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(webView21);
            Name = "ImageIngestForm";
            Text = "ImageIngestForm";
            WindowState = FormWindowState.Maximized;
            Load += ImageIngestForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPatientUpload).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        public FlowLayoutPanel flowLayoutPanel1;
        public FlowLayoutPanel flowLayoutPanel3;
        public FlowLayoutPanel flowLayoutPanel2;
        public PictureBox picPatientUpload;
        public Button btnRunDiagnostics;
        public Button btnSelectImage;
        private PictureBox pictureBox1;
        public Panel panel1;
        public Label label3;
        public Label label2;
        public Label lblpatientid;
        public Label label5;
        public Label label4;
        public Label label1;
        public TextBox TxtLocation;
        public DateTimePicker dateTimePicker1;
        public TextBox TxtGender;
        public TextBox TxtAge;
        public TextBox TxtFullName;
        public TextBox TxtPatientID;
        public TextBox TxtContactNumber;
        public Label label6;
    }
}