using System;
using Microsoft.Data.SqlClient;

namespace PreciseSkin___LUMYVUE
{
    public class DatabaseHelper
    {
        private string connectionString =
            "Data Source=LAPTOP-0DMT6OS6\\SQLEXPRESS;Initial Catalog=PreciseSkinDB;Integrated Security=True;TrustServerCertificate=True";

        public void SavePatientRecord(
            string patientId,
            string fullName,
            int age,
            string gender,
            string contact,
            string location,
            DateTime date,
            string prediction,
            string confidence,
            string imagePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO Patients
                (PatientId, FullName, Age, Gender, ContactNumber, Location, ConsultationDate, Prediction, ConfidenceScores, ImagePath)
                VALUES
                (@PatientId, @FullName, @Age, @Gender, @ContactNumber, @Location, @ConsultationDate, @Prediction, @ConfidenceScores, @ImagePath)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ContactNumber", contact);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@ConsultationDate", date);
                    cmd.Parameters.AddWithValue("@Prediction", prediction);
                    cmd.Parameters.AddWithValue("@ConfidenceScores", confidence);
                    cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}