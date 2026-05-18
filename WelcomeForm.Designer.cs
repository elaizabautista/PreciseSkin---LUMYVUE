using System.Drawing;
using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            videoBackground = new Microsoft.Web.WebView2.WinForms.WebView2();
            panelControlBar = new Panel();
            btnProceedToUpload = new Button();
            animationTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)videoBackground).BeginInit();
            panelControlBar.SuspendLayout();
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
            videoBackground.Size = new Size(1394, 685);
            videoBackground.TabIndex = 0;
            videoBackground.ZoomFactor = 1D;
            videoBackground.Click += videoBackground_Click_1;
            // 
            // panelControlBar
            // 
            panelControlBar.BackColor = Color.MistyRose;
            panelControlBar.Controls.Add(btnProceedToUpload);
            panelControlBar.Dock = DockStyle.Bottom;
            panelControlBar.Location = new Point(0, 685);
            panelControlBar.Name = "panelControlBar";
            panelControlBar.Size = new Size(1394, 50);
            panelControlBar.TabIndex = 1;
            // 
            // btnProceedToUpload
            // 
            btnProceedToUpload.BackColor = Color.MistyRose;
            btnProceedToUpload.Dock = DockStyle.Bottom;
            btnProceedToUpload.Font = new Font("Yu Gothic", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProceedToUpload.ForeColor = Color.RosyBrown;
            btnProceedToUpload.Location = new Point(0, 3);
            btnProceedToUpload.Name = "btnProceedToUpload";
            btnProceedToUpload.Size = new Size(1394, 47);
            btnProceedToUpload.TabIndex = 0;
            btnProceedToUpload.Text = "G E T   S T A R T E D";
            btnProceedToUpload.UseVisualStyleBackColor = false;
            btnProceedToUpload.Click += btnGetStarted_Click;
            // 
            // animationTimer
            // 
            animationTimer.Interval = 15;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1394, 735);
            Controls.Add(videoBackground);
            Controls.Add(panelControlBar);
            Name = "WelcomeForm";
            Text = "Welcome Form";
            WindowState = FormWindowState.Maximized;
            Load += WelcomeForm_Load_1;
            Click += WelcomeForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)videoBackground).EndInit();
            panelControlBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Microsoft.Web.WebView2.WinForms.WebView2 videoBackground;
        public Panel panelControlBar;
        private System.Windows.Forms.Timer animationTimer;
        public Button btnProceedToUpload;
    }
}