using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

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
        private void GenerateHospitalReport()
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PDF Files|*.pdf";

            save.FileName =
                "PreciseSkin_Report_" +
                patientidlbl.Text +
                ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 40, 40, 60, 40);

                PdfWriter.GetInstance(
                    doc,
                    new FileStream(save.FileName, FileMode.Create)
                );

                doc.Open();

                // =========================
                // LOGO
                // =========================
                string logoPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Assets",
                    "PreciseSkinLogo.png"
                );

                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo =
                        iTextSharp.text.Image.GetInstance(logoPath);

                    logo.ScaleToFit(80f, 80f);
                    logo.Alignment = Element.ALIGN_CENTER;

                    doc.Add(logo);
                }

                // =========================
                // FONTS
                // =========================
                Font titleFont =
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22);

                Font subtitleFont =
                    FontFactory.GetFont(FontFactory.HELVETICA, 12);

                Font sectionFont =
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);

                Font bodyFont =
                    FontFactory.GetFont(FontFactory.HELVETICA, 11);

                // =========================
                // TITLE
                // =========================
                Paragraph title =
                    new Paragraph(
                        "PRECISESKIN MEDICAL REPORT",
                        titleFont
                    );

                title.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);

                Paragraph clinic =
                    new Paragraph(
                        "AI-Assisted Dermatological Screening and Patient Record Management System",
                        subtitleFont
                    );

                clinic.Alignment = Element.ALIGN_CENTER;

                doc.Add(clinic);

                doc.Add(new Paragraph("\n"));

                // =========================
                // PATIENT INFORMATION
                // =========================
                Paragraph patientHeader =
                    new Paragraph(
                        "PATIENT INFORMATION",
                        sectionFont
                    );

                doc.Add(patientHeader);

                doc.Add(new Paragraph(
                    "Patient ID: " + patientidlbl.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    "Full Name: " + fullnamelbl.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    "Gender: " + genderlbl.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    "Contact Number: " + contactnumberlbl.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    "Location: " + locationlbl.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    "Consultation Date: " + dateofconsultationlbl.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph("\n"));

                // =========================
                // AI DIAGNOSIS
                // =========================
                Paragraph diagnosisHeader =
                    new Paragraph(
                        "AI DIAGNOSTIC RESULTS",
                        sectionFont
                    );

                doc.Add(diagnosisHeader);

                doc.Add(new Paragraph(
                    "Predicted Skin Condition:",
                    bodyFont
                ));

                Paragraph prediction =
                    new Paragraph(
                        lblCondition1.Text,
                        FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            16
                        )
                    );

                prediction.SpacingAfter = 10f;

                doc.Add(prediction);

                doc.Add(new Paragraph(
                    "Model Confidence Scores:",
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    lblmodelconfidencescores.Text,
                    bodyFont
                ));

                doc.Add(new Paragraph("\n"));

                // =========================
                // ABOUT PRECISESKIN
                // =========================
                Paragraph aboutHeader =
                    new Paragraph(
                        "ABOUT PRECISESKIN",
                        sectionFont
                    );

                doc.Add(aboutHeader);

                doc.Add(new Paragraph(
                    "PrecisionSkin is a machine learning-based AI-assisted dermatological screening system designed to support preliminary skin condition analysis and patient data management. The system utilizes deep learning and ONNX runtime integration to classify selected dermatological conditions through automated image analysis.",
                    bodyFont
                ));

                doc.Add(new Paragraph("\n"));

                // =========================
                // DISCLAIMER
                // =========================
                Paragraph disclaimerHeader =
                    new Paragraph(
                        "DISCLAIMER",
                        sectionFont
                    );

                doc.Add(disclaimerHeader);

                doc.Add(new Paragraph(
                    "This report is generated through an AI-assisted screening system and is intended solely for preliminary assessment purposes. The results provided should not replace professional medical diagnosis, treatment, or consultation from licensed dermatologists or healthcare providers.",
                    bodyFont
                ));

                doc.Add(new Paragraph("\n\n"));

                // =========================
                // SIGNATURE AREA
                // =========================
                doc.Add(new Paragraph(
                    "______________________________",
                    bodyFont
                ));

                doc.Add(new Paragraph(
                    "Authorized Medical Personnel",
                    bodyFont
                ));

                // CLOSE PDF
                doc.Close();

                MessageBox.Show(
                    "Professional medical report exported successfully!",
                    "PDF Export"
                );
            }
        }

        private async void ResultsForm_Load(object sender, EventArgs e)
        {
            // Maximize form
            this.WindowState = FormWindowState.Maximized;

            // Initialize WebView2
            await webView21.EnsureCoreWebView2Async();

            // Assets path
            string assetsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

            // Map local assets
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("lumyvue.local", assetsFolder, Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

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

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            GenerateHospitalReport();
        }
    }
}