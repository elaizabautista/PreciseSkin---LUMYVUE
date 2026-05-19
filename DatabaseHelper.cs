using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PreciseSkin___LUMYVUE
{
    public class DatabaseHelper
    {
        // =========================================
        // SQL SERVER CONNECTION
        // =========================================
        private string connectionString =
            @"Data Source=LAPTOP-0DMT6OS6\SQLEXPRESS;
              Initial Catalog=PreciseSkinDB;
              Integrated Security=True;
              TrustServerCertificate=True";

        // =========================================
        // SAVE PATIENT RECORD
        // =========================================
        public void SavePatientRecord(
            string patientId,
            string fullName,
            string age,
            string gender,
            string contactNumber,
            string location,
            string consultationDate,
            string prediction,
            string confidenceScores,
            string imagePath
        )
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO Patients
                (
                    PatientId,
                    FullName,
                    Age,
                    Gender,
                    ContactNumber,
                    Location,
                    ConsultationDate,
                    Prediction,
                    ConfidenceScores,
                    ImagePath
                )
                VALUES
                (
                    @PatientId,
                    @FullName,
                    @Age,
                    @Gender,
                    @ContactNumber,
                    @Location,
                    @ConsultationDate,
                    @Prediction,
                    @ConfidenceScores,
                    @ImagePath
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                cmd.Parameters.AddWithValue("@Prediction", prediction);
                cmd.Parameters.AddWithValue("@ConfidenceScores", confidenceScores);

                cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                cmd.ExecuteNonQuery();
            }
        }

        // =========================================
        // LOAD ALL PATIENT RECORDS
        // =========================================
        public DataTable GetPatients()
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Patients";

                SqlDataAdapter adapter =
                    new SqlDataAdapter(query, conn);

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
        }
    }
}