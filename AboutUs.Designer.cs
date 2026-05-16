namespace PreciseSkin___LUMYVUE
{
    partial class AboutUs
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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            fadeTimer = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            btnProceedToUpload = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
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
            webView21.Size = new Size(1531, 806);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // fadeTimer
            // 
            fadeTimer.Interval = 15;
            fadeTimer.Tick += fadeTimer_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaShell;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(btnProceedToUpload);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 762);
            panel1.Name = "panel1";
            panel1.Size = new Size(1531, 44);
            panel1.TabIndex = 1;
            // 
            // btnProceedToUpload
            // 
            btnProceedToUpload.BackColor = Color.PeachPuff;
            btnProceedToUpload.Dock = DockStyle.Bottom;
            btnProceedToUpload.FlatStyle = FlatStyle.Popup;
            btnProceedToUpload.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProceedToUpload.ForeColor = Color.Chocolate;
            btnProceedToUpload.Location = new Point(0, 0);
            btnProceedToUpload.Name = "btnProceedToUpload";
            btnProceedToUpload.Size = new Size(1531, 44);
            btnProceedToUpload.TabIndex = 0;
            btnProceedToUpload.Text = "P R O C E E D   T O   U P L O A D  ->";
            btnProceedToUpload.UseVisualStyleBackColor = false;
            btnProceedToUpload.Click += btnProceedToUpload_Click;
            // 
            // AboutUs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1531, 806);
            Controls.Add(panel1);
            Controls.Add(webView21);
            Name = "AboutUs";
            Text = "AboutUs";
            WindowState = FormWindowState.Maximized;
            Load += AboutUs_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        public System.Windows.Forms.Timer fadeTimer;
        public Panel panel1;
        public Button btnProceedToUpload;
    }
}