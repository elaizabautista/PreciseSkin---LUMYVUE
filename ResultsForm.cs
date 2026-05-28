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

            // AI RESULT

            lblCondition1.Text =
                condition;

            lblmodelconfidencescores.Text =
                modelconfidencescores;

    
            // PATIENT INFORMATION
    

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

            // IMAGE LOADING
     

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

       
                // LOGO

                string logoPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Assets",
                    "PreciseSkinLogo.png"
                );

                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo =
                        iTextSharp.text.Image.GetInstance(logoPath);

                    logo.ScaleToFit(90f, 90f);
                    logo.Alignment = Element.ALIGN_CENTER;

                    doc.Add(logo);
                }

                // FONTS
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24);

                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);

                Font subHeaderFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                Font boldBody = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);

                // TITLE (CENTER)

                Paragraph title = new Paragraph("PRECISIONSKIN", titleFont);

                title.Alignment = Element.ALIGN_CENTER; doc.Add(title);

                Paragraph subtitle = new Paragraph("AI-Assisted Dermatological Screening and Patient Record Management System", subHeaderFont);

                subtitle.Alignment = Element.ALIGN_CENTER;
                doc.Add(subtitle);

                doc.Add(new Paragraph("\n"));


                // COMPANY HEADER 

                Paragraph companyHeader = new Paragraph("SYSTEM DEVELOPERS / RESEARCH TEAM", headerFont);

                companyHeader.Alignment = Element.ALIGN_CENTER; doc.Add(companyHeader);

                Paragraph names = new Paragraph(
                        "Elaiza Czarina Claire C. Bautista\n" +
                        "Pineda, Francesca Nicolette S.\n" +
                        "Valdez, Andrea M.",
                        bodyFont
                    );

                names.Alignment = Element.ALIGN_CENTER; doc.Add(names);

                doc.Add(new Paragraph("\n"));


                // SYSTEM DESCRIPTION 
                Paragraph systemDesc = new Paragraph(
                        "PreciseSkin is an AI-assisted dermatological screening system that uses machine learning and ONNX runtime integration to analyze skin conditions from uploaded images. The system also provides patient record management, automated diagnostics, and structured medical reporting to support healthcare decision-making.",
                        bodyFont
                    );

                systemDesc.Alignment = Element.ALIGN_JUSTIFIED; doc.Add(systemDesc);

                doc.Add(new Paragraph("\n"));

                // PATIENT INFORMATION
                Paragraph patientHeader = new Paragraph("PATIENT INFORMATION", headerFont);

                patientHeader.Alignment = Element.ALIGN_CENTER; doc.Add(patientHeader);

                doc.Add(new Paragraph("Patient ID: " + patientidlbl.Text, bodyFont));
                doc.Add(new Paragraph("Full Name: " + fullnamelbl.Text, bodyFont));
                doc.Add(new Paragraph("Gender: " + genderlbl.Text, bodyFont));
                doc.Add(new Paragraph("Contact Number: " + contactnumberlbl.Text, bodyFont));
                doc.Add(new Paragraph("Location: " + locationlbl.Text, bodyFont));
                doc.Add(new Paragraph("Consultation Date: " + dateofconsultationlbl.Text, bodyFont));

                doc.Add(new Paragraph("\n"));


                // AI DIAGNOSIS
                Paragraph diagnosisHeader = new Paragraph("AI DIAGNOSTIC RESULTS", headerFont);

                diagnosisHeader.Alignment = Element.ALIGN_CENTER; doc.Add(diagnosisHeader);

                doc.Add(new Paragraph("Predicted Skin Condition:", bodyFont));

                Paragraph prediction = new Paragraph(lblCondition1.Text, boldBody);

                prediction.Alignment = Element.ALIGN_CENTER;
                prediction.SpacingAfter = 10f;

                doc.Add(prediction);

                doc.Add(new Paragraph("Model Confidence Scores:", bodyFont));
                doc.Add(new Paragraph(lblmodelconfidencescores.Text, bodyFont));

                doc.Add(new Paragraph("\n"));

                // DISCLAIMER 
 
                Paragraph disclaimerHeader = new Paragraph("DISCLAIMER", headerFont);

                disclaimerHeader.Alignment = Element.ALIGN_CENTER; doc.Add(disclaimerHeader);

                Paragraph disclaimer =
                    new Paragraph(
                        "This report is generated through an AI-assisted system and is intended for preliminary screening purposes only. It must not replace professional medical diagnosis, consultation, or treatment by licensed healthcare providers.",
                        bodyFont
                    );

                disclaimer.Alignment = Element.ALIGN_JUSTIFIED; doc.Add(disclaimer);

                doc.Add(new Paragraph("\n\n"));

 
                // SIGNATURE
                Paragraph signLine = new Paragraph("______________________________", bodyFont);

                signLine.Alignment = Element.ALIGN_CENTER; doc.Add(signLine);

                Paragraph signText = new Paragraph("Authorized Medical Personnel", bodyFont);

                signText.Alignment = Element.ALIGN_CENTER;  doc.Add(signText);

                doc.Close();

                MessageBox.Show(
                    "Medical report exported successfully!",
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


        /// Return to upload screen
  
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