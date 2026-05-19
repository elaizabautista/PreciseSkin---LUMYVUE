using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PreciseSkin___LUMYVUE
{
    public partial class ResultsForm : Form
    {

        // 🌟 Updated Constructor: Now accepts 'imagePath' as a third input item
        public ResultsForm(string condition, string modelconfidencescores, string imagePath)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 1. Assign the predictions
            lblCondition1.Text = condition;
            lblmodelconfidencescores.Text = modelconfidencescores;

            // 2. 🎯 FORCED UPDATE: Clear out old image references first
            if (picAnalyzedImage.Image != null)
            {
                picAnalyzedImage.Image.Dispose();
                picAnalyzedImage.Image = null;
            }

            // 3. Load the fresh path passed from the upload screen
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                // Using a safe stream open prevents Windows from locking the file in your assets folder
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    picAnalyzedImage.Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }

        private async void ResultsForm_Load(object sender, EventArgs e)
        {
            // Force this dashboard window to launch completely maximized
            this.WindowState = FormWindowState.Maximized;

            // Initialize the WebView2 browser background canvas engine safely
            await webView21.EnsureCoreWebView2Async();

            // Pin down the physical path to your local Assets folder where ResultsForm.png lives
            string assetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

            // Map the folder to a virtual local domain to completely bypass browser security filters
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "lumyvue.local",
                assetsFolder,
                Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow
            );

            // Inject full-bleed responsive CSS styling to dynamically lock your layout background in place
            string htmlLayout = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        * { margin: 0; padding: 0; overflow: hidden; box-sizing: border-box; }
                        body, html { 
                            width: 100%; 
                            height: 100%; 
                            background-color: #1a1512; /* Matches your luxury brand dark aesthetic */
                        }
                        
                        /* FULL SCREEN STATIC BACKGROUND SCALING VIA COVER */
                        .dashboard-bg {
                            position: fixed;
                            top: 0;
                            left: 0;
                            width: 100vw;
                            height: 100vh;
                            background-image: url('https://lumyvue.local/ResultsForm.png');
                            background-size: cover;          /* Completely floods out any black bars or sides */
                            background-position: center center; /* Keeps your layout graphic composition perfectly centered */
                            background-repeat: no-repeat;
                        }
                    </style>
                </head>
                <body>
                    <div class='dashboard-bg'></div>
                </body>
                </html>";

            // Project your responsive background layout image onto the form
            webView21.NavigateToString(htmlLayout);
        }

        /// <summary>
        /// Closes this screen and brings the user back to the image selection screen.
        /// </summary>
        private void btnBackToUpload_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is ImageIngestForm)
                {
                    openForm.Show();
                    this.Close();
                    return;
                }
            }

            ImageIngestForm ingestScreen = new ImageIngestForm();
            ingestScreen.Show();
            this.Close();
        }

        private void lblCondition_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblSkinType_Click(object sender, EventArgs e)
        {
            //
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //
        }
    }
}