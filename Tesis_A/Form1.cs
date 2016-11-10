using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesis_A.Control;

namespace Tesis_A
{
    public partial class Form1 : Form
    {
        //solo pruebas
        public static int usua = 11;
        //solo pruebas



        Mysql_Master msql = new Mysql_Master();
        Laberinto3 J_Lab;
        Memorama J_Mem;
        public Form1()
        {
            InitializeComponent();
        }

        //-----juegos

        public void Laber()
        {
            J_Lab = new Laberinto3(1);
            J_Lab.Dock = DockStyle.Fill;
            J_Lab.Name = "Juego";
            Juego_G.Controls.Add(J_Lab);
        }

        public void Memor2(int nivel)
        {
            J_Mem = new Memorama(nivel);
            J_Mem.Dock = DockStyle.Fill;
            J_Mem.Name = "Juego";
            Juego_G.Controls.Add(J_Mem);
        }


        //-----juegos
        public void Remov()
        {
            Juego_G.Controls.RemoveByKey("Juego");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Remov();
            Laber();
            TabControl_1.SelectedTab = Juego_G;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remov();
            Memor2(1);
            TabControl_1.SelectedTab = Juego_G;
        }

        //----------------------------------------------------------------------------------------
        private void Res_Lab(object sender, EventArgs e)
        {
            Laberinto_Dg.DataSource = msql.msqldb_Select("Resultados", " WHERE cnivel = 1 AND cjuego = '1' AND cjugador = " + usua).Select(x => new
            {
                cnivel = x.Field<Int32>("cnivel"),
                cniv_n = x.Field<Int32>("cniv_n"),
                cerrores = x.Field<Int32>("cerrores"),
                ctime = x.Field<decimal>("ctime")
            }).ToList().OrderBy(x => x.cniv_n).ThenBy(x => x.cerrores).ThenBy(x => x.ctime).ToList();
        }

        private void Res_Mem(object sender, EventArgs e)
        {
            Memoria_Dg.DataSource = msql.msqldb_Select("Resultados", " WHERE cnivel = 1 AND cjuego = '2' AND cjugador = " + usua).Select(x => new
            {
                cnivel = x.Field<Int32>("cnivel"),
                cniv_n = x.Field<Int32>("cniv_n"),
                ctime = x.Field<decimal>("ctime"),
                cfecha = Convert.ToDateTime(x.Field<DateTime>("cfecha")).ToShortDateString()
            }).ToList().OrderBy(x => x.cfecha).ThenBy(x => x.cniv_n).ThenBy(x => x.ctime).ToList();
        }
  
    }
}
