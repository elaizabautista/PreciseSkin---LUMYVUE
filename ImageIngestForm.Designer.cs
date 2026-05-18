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
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPatientUpload).BeginInit();
            flowLayoutPanel2.SuspendLayout();
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
            webView21.Size = new Size(2527, 1270);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.Click += webView21_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Tan;
            flowLayoutPanel1.Controls.Add(btnSelectImage);
            flowLayoutPanel1.Location = new Point(1298, 83);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1156, 59);
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
            btnSelectImage.Size = new Size(1183, 52);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "C H O O S E   F I L E";
            btnSelectImage.UseVisualStyleBackColor = false;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Tan;
            flowLayoutPanel3.Controls.Add(picPatientUpload);
            flowLayoutPanel3.Location = new Point(1487, 488);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(967, 648);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // picPatientUpload
            // 
            picPatientUpload.BackColor = Color.Transparent;
            picPatientUpload.BackgroundImageLayout = ImageLayout.Zoom;
            picPatientUpload.Location = new Point(3, 3);
            picPatientUpload.Name = "picPatientUpload";
            picPatientUpload.Size = new Size(964, 645);
            picPatientUpload.TabIndex = 0;
            picPatientUpload.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Linen;
            flowLayoutPanel2.Controls.Add(btnRunDiagnostics);
            flowLayoutPanel2.Location = new Point(1487, 1160);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(967, 75);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // btnRunDiagnostics
            // 
            btnRunDiagnostics.BackColor = Color.Bisque;
            btnRunDiagnostics.FlatStyle = FlatStyle.Flat;
            btnRunDiagnostics.Font = new Font("Yu Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRunDiagnostics.Location = new Point(3, 3);
            btnRunDiagnostics.Name = "btnRunDiagnostics";
            btnRunDiagnostics.Size = new Size(964, 72);
            btnRunDiagnostics.TabIndex = 0;
            btnRunDiagnostics.Text = "S T A R T   S K I N   A N A L Y S I S";
            btnRunDiagnostics.UseVisualStyleBackColor = false;
            btnRunDiagnostics.Click += btnRunDiagnostics_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Snow;
            panel1.Location = new Point(1301, 148);
            panel1.Name = "panel1";
            panel1.Size = new Size(1153, 113);
            panel1.TabIndex = 5;
            // 
            // ImageIngestForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(2527, 1270);
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
        private Panel panel1;
    }
}