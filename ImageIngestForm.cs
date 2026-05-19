using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace PreciseSkin___LUMYVUE
{
    public partial class ImageIngestForm : Form
    {
        // Stores uploaded image path
        private string _selectedFilePath = "";

        public ImageIngestForm()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private async void ImageIngestForm_Load(object sender, EventArgs e)
        {
            // Launch maximized
            this.WindowState = FormWindowState.Maximized;

            // Initialize WebView2
            await webView21.EnsureCoreWebView2Async();

            // Assets folder
            string assetsFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets"
            );

            // Map local assets
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "lumyvue.local",
                assetsFolder,
                Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow
            );

            // HTML background
            string htmlLayout = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        * {
            margin: 0;
            padding: 0;
            overflow: hidden;
            box-sizing: border-box;
            font-family: 'Segoe UI', sans-serif;
        }

        body, html {
            width: 100%;
            height: 100%;
            background-color: #1a1512;
        }

        .dashboard-bg {
            position: fixed;
            top: 0;
            left: 0;

            width: 100vw;
            height: 100vh;

            background-image:
                url('https://lumyvue.local/ImageUpload.png');

            background-size: cover;
            background-position: center center;
            background-repeat: no-repeat;

            z-index: 1;
        }
    </style>
</head>

<body>
    <div class='dashboard-bg'></div>
</body>
</html>";

            webView21.NavigateToString(htmlLayout);

            // Auto-generate patient ID
            TxtPatientID.Text =
                "PS-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            TxtPatientID.ReadOnly = true;
        }

        /// <summary>
        /// Upload image
        /// </summary>
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title =
                    "Select Patient Skin Sample";

                openFileDialog.Filter =
                    "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath =
                        openFileDialog.FileName;

                    // Dispose old image
                    if (picPatientUpload.Image != null)
                    {
                        picPatientUpload.Image.Dispose();
                        picPatientUpload.Image = null;
                    }

                    // Safe image loading
                    using (var stream = new FileStream(
                        _selectedFilePath,
                        FileMode.Open,
                        FileAccess.Read))
                    {
                        picPatientUpload.Image =
                            System.Drawing.Image.FromStream(stream);
                    }
                }
            }
        }

        /// <summary>
        /// Run AI Diagnostics
        /// </summary>
        private void btnRunDiagnostics_Click(object sender, EventArgs e)
        {
            // Validate uploaded image
            if (string.IsNullOrEmpty(_selectedFilePath))
            {
                MessageBox.Show(
                    "Please upload a skin image first.",
                    "Missing Image"
                );

                return;
            }

            // Validate patient info
            if (string.IsNullOrWhiteSpace(TxtFullName.Text))
            {
                MessageBox.Show(
                    "Please enter patient full name.",
                    "Missing Patient Information"
                );

                return;
            }

            try
            {
                // Run AI
                SkinAnalyzer analyzer =
                    new SkinAnalyzer();

                var report =
                    analyzer.AnalyzeImage(_selectedFilePath);

                // Open Results Form
                ResultsForm diagnosticsWindow =
                    new ResultsForm(

                        report.ConditionPrediction,
                        report.RawScores,
                        _selectedFilePath,

                        TxtPatientID.Text,
                        TxtFullName.Text,
                        TxtAge.Text,
                        TxtGender.Text,
                        TxtContactNumber.Text,
                        TxtLocation.Text,
                        dateTimePicker1.Value.ToShortDateString()
                    );

                diagnosticsWindow.Show();

                // Hide upload screen
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"AI Runtime Error:\n\n{ex.Message}",
                    "ONNX Runtime Error"
                );
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            //
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //
        }
    }
}