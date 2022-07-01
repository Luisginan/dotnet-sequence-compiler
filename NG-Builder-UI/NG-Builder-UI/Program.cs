using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var xmlPath = "";
            var rootPath = "";
            var binPath = "";
            for (int i = 0; i < args.Length; i++)
            {
                
                    if (args[i].Contains("="))
                    {
                        string param = args[i].Split('=')[0];
                        string paramValue = args[i].Split('=')[1];

                        if (param == "/xml")
                            xmlPath = paramValue;
                        else if (param == "/root")
                            rootPath = paramValue;
                        else if (param == "/bin")
                            binPath = paramValue;
                }             
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(xmlPath,rootPath, binPath));
        }
    }
}
