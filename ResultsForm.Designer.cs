namespace PreciseSkin___LUMYVUE
{
    partial class ResultsForm
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
            panel1 = new Panel();
            btnBackToUpload = new Button();
            lblSkinType = new Label();
            label2 = new Label();
            label1 = new Label();
            lblCondition = new Label();
            panel2 = new Panel();
            picAnalyzedImage = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnalyzedImage).BeginInit();
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
            webView21.Size = new Size(2325, 1278);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Tan;
            panel1.Controls.Add(btnBackToUpload);
            panel1.Controls.Add(lblSkinType);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCondition);
            panel1.Location = new Point(132, 557);
            panel1.Name = "panel1";
            panel1.Size = new Size(1353, 546);
            panel1.TabIndex = 1;
            // 
            // btnBackToUpload
            // 
            btnBackToUpload.BackColor = Color.SeaShell;
            btnBackToUpload.FlatStyle = FlatStyle.Flat;
            btnBackToUpload.Location = new Point(0, 497);
            btnBackToUpload.Name = "btnBackToUpload";
            btnBackToUpload.Size = new Size(1353, 49);
            btnBackToUpload.TabIndex = 4;
            btnBackToUpload.Text = "N E W   S C A N ";
            btnBackToUpload.UseVisualStyleBackColor = false;
            btnBackToUpload.Click += btnBackToUpload_Click;
            // 
            // lblSkinType
            // 
            lblSkinType.AutoSize = true;
            lblSkinType.Font = new Font("Yu Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSkinType.Location = new Point(337, 127);
            lblSkinType.Name = "lblSkinType";
            lblSkinType.Size = new Size(258, 27);
            lblSkinType.TabIndex = 3;
            lblSkinType.Text = " D E T E R M I N I N G . . .";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 127);
            label2.Name = "label2";
            label2.Size = new Size(176, 27);
            label2.TabIndex = 2;
            label2.Text = "S K I N   T Y P E:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 68);
            label1.Name = "label1";
            label1.Size = new Size(269, 27);
            label1.TabIndex = 1;
            label1.Text = "S K I N   C O N D I T I O N:";
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.BackColor = Color.Transparent;
            lblCondition.Font = new Font("Yu Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCondition.Location = new Point(348, 68);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(214, 27);
            lblCondition.TabIndex = 0;
            lblCondition.Text = "A N A L Y Z I N G . . .";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Tan;
            panel2.Controls.Add(picAnalyzedImage);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(1551, 557);
            panel2.Name = "panel2";
            panel2.Size = new Size(664, 546);
            panel2.TabIndex = 5;
            // 
            // picAnalyzedImage
            // 
            picAnalyzedImage.BackColor = Color.Transparent;
            picAnalyzedImage.Location = new Point(16, 30);
            picAnalyzedImage.Name = "picAnalyzedImage";
            picAnalyzedImage.Size = new Size(633, 491);
            picAnalyzedImage.SizeMode = PictureBoxSizeMode.Zoom;
            picAnalyzedImage.TabIndex = 6;
            picAnalyzedImage.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(239, 27);
            label3.TabIndex = 5;
            label3.Text = "Y O U R   P I C T U R E ";
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(2325, 1278);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(webView21);
            Name = "ResultsForm";
            Text = "ResultsForm";
            WindowState = FormWindowState.Maximized;
            Load += ResultsForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAnalyzedImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        public Panel panel1;
        public Panel panel2;
        public Label lblCondition;
        public Button btnBackToUpload;
        public Label lblSkinType;
        public Label label2;
        public Label label1;
        public PictureBox picAnalyzedImage;
        public Label label3;
        private PictureBox pictureBox1;
    }
}