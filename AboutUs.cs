using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PreciseSkin___LUMYVUE
{
    public partial class AboutUs : Form
    {
        // Track if the form is fading IN (false) or fading OUT to the next screen (true)
        private bool isExitingToUpload = false;

        public AboutUs()
        {
            InitializeComponent();

            // Force double-buffering to keep WebView2 video transitions seamless
            this.DoubleBuffered = true;
            this.Opacity = 0;

            // 🌟 FIXED: This explicitly tells Windows Forms to run your setup code when this form loads!
            this.Load += new System.EventHandler(this.AboutUs_Load);

            // 🌟 FIXED: Safely wire up the fade timer tick event in case the designer dropped it
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
        }

        // Overrides window parameters to prevent flickering layers during alpha cross-fades
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void AboutUs_Load(object sender, EventArgs e)
        {
            fadeTimer.Interval = 15;
            fadeTimer.Start();

            // 🌟 THE ULTIMATE LAYOUT RESET FOR THE BUTTON 🌟
            btnProceedToUpload.Dock = DockStyle.Bottom;        // Forces it to stretch across the full width
            btnProceedToUpload.Height = 44;                    // Dictates the exact height of the bottom bar
            btnProceedToUpload.AutoSize = false;               // Stops WinForms from squishing the height down
            btnProceedToUpload.TextAlign = ContentAlignment.MiddleCenter; // Centers the text perfectly
            btnProceedToUpload.Padding = new Padding(0);       // Clears out any bad text padding loops

            // Force the video layout container to go to the back layer so the button sits on top
            webView21.SendToBack();

            // 1. Wait for the engine to initialize
            await webView21.EnsureCoreWebView2Async();

            string assetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping(
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
            <video autoplay loop muted playsinline><source src='https://lumyvue.local/AboutUs.mp4' type='video/mp4'></video>
        </body>
        </html>";

            webView21.NavigateToString(htmlLayout);
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (!isExitingToUpload)
            {
                // --- ENTRANCE FADE IN ---
                if (this.Opacity < 1.0)
                {
                    this.Opacity += 0.05;
                }
                else
                {
                    fadeTimer.Stop(); // Lock at fully solid
                }
            }
            else
            {
                // --- EXIT FADE OUT ---
                if (this.Opacity > 0.0)
                {
                    this.Opacity -= 0.06; // Smoothly dim to black
                }
                else
                {
                    fadeTimer.Stop();

                    // Launch step 2 of your checklist: Picture Ingestion!
                    ImageIngestForm uploadForm = new ImageIngestForm();
                    uploadForm.Show();

                    this.Hide();
                }
            }
        }

        private void btnProceedToUpload_Click(object sender, EventArgs e)
        {
            // Reverse the timer direction to smoothly fade this screen away
            isExitingToUpload = true;
            fadeTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}