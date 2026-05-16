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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        // ✅ 1. This fires automatically the split second the form opens
        private async void WelcomeForm_Load_1(object sender, EventArgs e)
        {
            // 1. Initialize the Edge Chromium engine
            await videoBackground.EnsureCoreWebView2Async();

            // 2. Point to your Assets folder where LUMYVUE.mp4 lives
            string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "LUMYVUE.mp4");
            string videoUrl = new Uri(videoPath).AbsoluteUri;

            // 🚨 QUICK TEST: If the file is physically missing where the app runs, show a warning
            if (!File.Exists(videoPath))
            {
                MessageBox.Show($"Video file not found at path:\n{videoPath}\n\nPlease check your Assets folder properties!", "Missing Video Asset");
            }

            // 3. Setup a borderless HTML5 player
            string htmlLayout = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <style>
                * {{ margin: 0; padding: 0; overflow: hidden; }}
                body, html {{ 
                    width: 100%; 
                    height: 100%; 
                    background-color: #1a1512; 
                }}
                video {{
                    position: fixed;
                    top: 50%;
                    left: 50%;
                    min-width: 100%;
                    min-height: 100%;
                    width: auto;
                    height: auto;
                    transform: translate(-50%, -50%);
                    object-fit: cover;
                }}
            </style>
        </head>
        <body>
            <video autoplay loop muted playsinline>
                <source src='{videoUrl}' type='video/mp4'>
            </video>
        </body>
        </html>";

            // 4. Inject and play the video canvas automatically
            videoBackground.NavigateToString(htmlLayout);
        }

        // ✅ 2. This satisfies the precise name the designer file wants
        private void videoBackground_Click_1(object sender, EventArgs e)
        {
            // Keeps the designer happy!
            // Later, you can add code here to transition to your ImageIngestForm
        }
    }
}