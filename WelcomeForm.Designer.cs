namespace PreciseSkin___LUMYVUE
{
    partial class WelcomeForm
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
            videoBackground = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)videoBackground).BeginInit();
            SuspendLayout();
            // 
            // videoBackground
            // 
            videoBackground.AllowExternalDrop = true;
            videoBackground.CreationProperties = null;
            videoBackground.DefaultBackgroundColor = Color.White;
            videoBackground.Dock = DockStyle.Fill;
            videoBackground.Location = new Point(0, 0);
            videoBackground.Name = "videoBackground";
            videoBackground.Size = new Size(1834, 982);
            videoBackground.TabIndex = 0;
            videoBackground.ZoomFactor = 1D;
            videoBackground.Click += videoBackground_Click_1;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1834, 982);
            Controls.Add(videoBackground);
            Name = "WelcomeForm";
            Text = "Welcome Form";
            WindowState = FormWindowState.Maximized;
            Load += WelcomeForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)videoBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 videoBackground;
    }
}