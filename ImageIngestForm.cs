using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // 🌟 This handles your form UI images!
using System.IO;
using System.Text;
using System.Windows.Forms;

// Core ONNX namespaces for handling data streams safely
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace PreciseSkin___LUMYVUE
{
    public partial class ImageIngestForm : Form
    {
        // Global string tracking the selected patient image file path for our ONNX model
        private string _selectedFilePath = "";

        public ImageIngestForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private async void ImageIngestForm_Load(object sender, EventArgs e)
        {
            // 1. Force the application window to launch completely maximized
            this.WindowState = FormWindowState.Maximized;

            // 2. Initialize the WebView2 browser background canvas engine safely
            await webView21.EnsureCoreWebView2Async();

            // 3. Pin down the physical path to your local Assets folder where ImageUpload.png lives
            string assetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

            // 4. Map the folder to a virtual local domain to completely bypass browser security filters
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
        * { margin: 0; padding: 0; overflow: hidden; box-sizing: border-box; font-family: 'Segoe UI', sans-serif; }
        body, html { width: 100%; height: 100%; background-color: #1a1512; }
        
        /* Responsive Luxury Background */
        .dashboard-bg {
            position: fixed;
            top: 0; left: 0; width: 100vw; height: 100vh;
            background-image: url('https://lumyvue.local/ImageUpload.png');
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
        }

        /// <summary>
        /// Sits perfectly over your Canva button coordinates to grab patient photo files.
        /// </summary>
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Patient Skin Sample for Diagnosis";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 🎯 CRITICAL: This global variable MUST be set here!
                    _selectedFilePath = openFileDialog.FileName;

                    // This updates the UI preview box on the ingest screen
                    picPatientUpload.Image = System.Drawing.Image.FromFile(_selectedFilePath);
                }
            }
        }

        /// <summary>
        /// Fires your single-file multi-task ONNX model directly against the uploaded file coordinate.
        /// </summary>
        private void btnRunDiagnostics_Click(object sender, EventArgs e)
        {
            // 1. Ensure the patient has actually uploaded a picture before running the neural network
            if (string.IsNullOrEmpty(_selectedFilePath))
            {
                MessageBox.Show("Please upload a clear photo of the target skin area first.", "Missing Input Image");
                return;
            }

            try
            {
                // 2. Initialize our newly created skin machine learning brain class
                SkinAnalyzer analyzer = new SkinAnalyzer();

                // 🎯 FIXED: Passing '_selectedFilePath' directly to guarantee the model analyzes 
                // the actual picture you just uploaded, instead of a locked default path!
                var report = analyzer.AnalyzeImage(_selectedFilePath);

                // 3. Forward the dynamic data and the chosen image straight to the results dashboard
                ResultsForm diagnosticsWindow = new ResultsForm(report.ConditionPrediction, report.SkinTypePrediction, _selectedFilePath);
                diagnosticsWindow.Show();

                // 4. Cleanly hide this ingestion board from view
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Neural Runtime Disruption: {ex.Message}\n\nIf you see this error, double-check that your ONNX output layer names inside SkinAnalyzer.cs match your model's exact node names!", "ONNX Engine Error");
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}