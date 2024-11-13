using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class ADMIN : Form
    {
        string connectionString = "Data Source=SHAMIM\\SQLEXPRESS;Initial Catalog=C#Project;Integrated Security=True";

        public decimal amountCollected=0;
        public ADMIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PROVIDER_MANAGEMENT().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new USER_MANAGEMENT().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Close();
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Appointment_Table WHERE count = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                int count = (int)cmd.ExecuteScalar();
                label4.Text = count.ToString();
                connection.Close();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(amount) FROM Appointment_Table";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    decimal totalAmount = Convert.ToDecimal(result);
                    label5.Text = $"{totalAmount:C}";
                }
                conn.Close();
            }

        }

    }
}
