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
        Mysql_Master msql = new Mysql_Master();
        Laberinto3 J_Lab;
        public Form1()
        {
            InitializeComponent();
        }

        public void Laber()
        {
            J_Lab = new Laberinto3(1);
            J_Lab.Dock = DockStyle.Fill;
            J_Lab.Name = "Juego";
            Juego_G.Controls.Add(J_Lab);
        }

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

        private void Res_Lab(object sender, EventArgs e)
        {
            Laberinto_Dg.DataSource = msql.msqldb_Select("Resultados", " WHERE cnivel = 1").Select(x => new
            {
                cnivel = x.Field<Int32>("cnivel"),
                cniv_n = x.Field<Int32>("cniv_n"),
                cerrores = x.Field<Int32>("cerrores"),
                ctime = x.Field<decimal>("ctime")
            }).ToList().OrderBy(x => x.cniv_n).ThenBy(x => x.cerrores).ThenBy(x => x.ctime).ToList();
        }
  
    }
}
