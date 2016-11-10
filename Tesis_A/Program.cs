using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesis_A
{
    static class Program
    {
        //public static string server = "server=192.168.222.131; ";
        //public static string dbname = "database=Joec; ";
        //public static string dbuser = "Uid=Joec; ";
        //public static string dbpass = "pwd=joec2107;";
        public static string server = "server=192.168.222.131; ";
        public static string dbname = "database=BDJuego2; ";
        public static string dbuser = "Uid=BD_Game; ";
        public static string dbpass = "pwd=123456;";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
