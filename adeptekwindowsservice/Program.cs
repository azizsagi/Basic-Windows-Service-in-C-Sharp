using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdeptekWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            
               #if DEBUG

                        Service1 mySer = new Service1();
                        mySer.onDebug();
                        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

                 
                #else
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                            { 
                                new Service1() 
                            };
                ServiceBase.Run(ServicesToRun);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                #endif
              
            /*
            
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());
           
             */ 
           
            
             
            

        }
    }
}
