using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PreciseSkin___LUMYVUE
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(

            string condition,
            string modelconfidencescores,
            string imagePath,

            string patientId,
            string fullName,
            string age,
            string gender,
            string contactNumber,
            string location,
            string consultationDate
        )
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // =========================
            // AI RESULTS
            // =========================

            lblCondition1.Text =
                condition;

            lblmodelconfidencescores.Text =
                modelconfidencescores;

            // =========================
            // PATIENT INFORMATION
            // =========================

            patientidlbl.Text =
                patientId;

            fullnamelbl.Text =
                fullName;

            agelbl.Text =
                age;

            genderlbl.Text =
                gender;

            contactnumberlbl.Text =
                contactNumber;

            locationlbl.Text =
                location;

            dateofconsultationlbl.Text =
                consultationDate;

            // =========================
            // IMAGE LOADING
            // =========================

            if (picAnalyzedImage.Image != null)
            {
                picAnalyzedImage.Image.Dispose();
                picAnalyzedImage.Image = null;
            }

            if (!string.IsNullOrEmpty(imagePath)
                && File.Exists(imagePath))
            {
                using (var stream = new FileStream(
                    imagePath,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    picAnalyzedImage.Image =
                        System.Drawing.Image.FromStream(stream);
                }
            }
        }

        private async void ResultsForm_Load(
            object sender,
            EventArgs e)
        {
            // Maximize form
            this.WindowState =
                FormWindowState.Maximized;

            // Initialize WebView2
            await webView21.EnsureCoreWebView2Async();

            // Assets path
            string assetsFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets"
            );

            // Map local assets
            webView21.CoreWebView2
                .SetVirtualHostNameToFolderMapping(

                "lumyvue.local",
                assetsFolder,

                Microsoft.Web.WebView2.Core
                .CoreWebView2HostResourceAccessKind.Allow
            );

            // Background layout
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
        url('https://lumyvue.local/ResultsForm.png');

    background-size: cover;
    background-position: center center;
    background-repeat: no-repeat;
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
        /// Return to upload screen
        /// </summary>
        private void btnBackToUpload_Click(
            object sender,
            EventArgs e)
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

            ImageIngestForm ingestScreen =
                new ImageIngestForm();

            ingestScreen.Show();

            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblSkinType_Click(object sender, EventArgs e)
        {
            //
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            string password = Interaction.InputBox(
                "Enter Admin Password",
                "Admin Access"
            );

            // Check password FIRST before opening AdminForm
            if (password == "admin123")
            {
                AdminForm adminForm = new AdminForm();

                adminForm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Access Denied",
                    "Security Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}