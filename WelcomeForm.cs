using Microsoft.Web.WebView2.Core;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PreciseSkin___LUMYVUE
{
    public partial class WelcomeForm : Form
    {
        private bool isExiting = false;

        public WelcomeForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

        
            this.Opacity = 0;

            this.Load += new System.EventHandler(this.WelcomeForm_Load_1);
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
        }


        // This forces Windows to compositing the entire form layer down 
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; 
                return cp;
            }
        }

        private async void WelcomeForm_Load_1(object sender, EventArgs e)
        {
            // animation timer
            animationTimer.Interval = 15;
            animationTimer.Start();

            //video engine background
            await videoBackground.EnsureCoreWebView2Async();
            string assetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
            videoBackground.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "lumyvue.local",
                assetsFolder,
                Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow
            );

            string htmlLayout = @"
        <!DOCTYPE html>
        <html>
        <head>
            <style>
                * { margin: 0; padding: 0; overflow: hidden; box-sizing: border-box; }
                body, html { width: 100%; height: 100%; background-color: #1a1512; }
                video { position: fixed; top: 50%; left: 50%; min-width: 100%; min-height: 100%; width: 100vw; height: 100vh; transform: translate(-50%, -50%); object-fit: cover; }
            </style>
        </head>
        <body>
            <video autoplay loop muted playsinline><source src='https://lumyvue.local/LUMYVUE.mp4' type='video/mp4'></video>
        </body>
        </html>";

            videoBackground.NavigateToString(htmlLayout);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (!isExiting)
            {
                // entrance
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.05; 
                }
                else
                {
                    animationTimer.Stop();
                }
            }
            else
            {
                // exit
                if (this.Opacity > 0.0)
                {
                    this.Opacity -= 0.06; 
                }
                else
                {
                    animationTimer.Stop();

                    // Open the AboutUs form 
                    AboutUs nextForm = new AboutUs();
                    nextForm.Show();
                    this.Hide();
                }
            }
        }

        private void btnGetStarted_Click(object sender, EventArgs e)
        {
            isExiting = true;
            animationTimer.Start();
        }

        private void videoBackground_Click_1(object sender, EventArgs e) { }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string password =
                    Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter Admin Password",
                        "Admin Authentication"
                    );

            if (password == "admin123")
            {
                AdminForm admin = new AdminForm();

                admin.Show();
            }
            else
            {
                MessageBox.Show(
                    "Access Denied",
                    "Security Warning"
                );
            }
        }
    }
}