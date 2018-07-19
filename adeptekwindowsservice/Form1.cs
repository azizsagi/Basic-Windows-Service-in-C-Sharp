using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdeptekWindowsService
{
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=AZIZ-PC\WINCC;Initial Catalog=service;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = "Adeptek Service";


            MessageBox.Show("Status is " + sc.Status.ToString());



        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = "Adeptek Service";

            try
            {
                // Start the service, and wait until its status is "Running".
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);

                MessageBox.Show("Status is " + sc.Status.ToString());

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Could not start the Adeptek service.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = "Adeptek Service";

            try
            {
                // Start the service, and wait until its status is "Running".
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);

                MessageBox.Show("Status is " + sc.Status.ToString());

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Could not stop the Adeptek service.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                conn.Open();

                int s = 0;

                string query = "SELECT * FROM status WHERE id=1";
                SqlCommand qry = new SqlCommand(query, conn);


                SqlDataReader reader = qry.ExecuteReader();

                while (reader.Read())
                {
                    s = reader.GetInt32(0);
                }

                reader.Close();

                if (s == 1)
                {
                    query = "INSERT INTO dbo.names VALUES('Aziz',GETDATE())";
                    SqlCommand qry2 = new SqlCommand(query, conn);
                    qry2.ExecuteNonQuery();
                    System.Threading.Thread.Sleep(100);

                }



                System.Threading.Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

