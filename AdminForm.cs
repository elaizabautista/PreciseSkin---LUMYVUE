using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace PreciseSkin___LUMYVUE
{
    public partial class AdminForm : Form
    {
        private string connectionString =
            @"Data Source=LAPTOP-0DMT6OS6\SQLEXPRESS;
              Initial Catalog=PreciseSkinDB;
              Integrated Security=True;
              TrustServerCertificate=True";

        public AdminForm()
        {
            InitializeComponent();
        }

        // LOAD ALL RECORDS WHEN FORM OPENS
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
        }

        private void LoadAllPatients()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM Patients", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // SEARCH BUTTON (BY PATIENT ID)
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = PatientIDHistoryTxt.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT * FROM Patients
                    WHERE PatientId LIKE @PatientId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", "%" + searchValue + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // CLICK ROW TO VIEW DETAILS
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                PatientIDHistoryTxt.Text = row.Cells["PatientId"].Value.ToString();
            }
        }

        // OPTIONAL: FILTER BY DATE
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT * FROM Patients
                    WHERE ConsultationDate LIKE @Date";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", "%" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}