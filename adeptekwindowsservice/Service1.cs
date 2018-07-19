using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace AdeptekWindowsService
{
    public partial class Service1 : ServiceBase
    {

        SqlConnection conn = new SqlConnection(@"Data Source=AZIZ-PC\WINCC;Initial Catalog=service;Integrated Security=True");


        public Service1()
        {
            InitializeComponent();
        }

        public void onDebug()
        {
                OnStart(null);

        }


        protected override void OnStart(string[] args)
        {

            //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "start.txt");
           
                conn.Open();
            
                int s = 0;
                try
                {

                    while (true)
                    {

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
                }
            catch(Exception ex)
                {
                  

                }

        }

        protected override void OnStop()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "stop.txt");

        }
    }
}
