using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace Tesis_A.Control
{
    public partial class Laberinto3 : UserControl
    {
        Mysql_Master msqldb = new Mysql_Master();
        List<Grid_0> gr1 = new List<Grid_0>();
        PictureBox CartasJuego;
        List<PictureBox> lpb;
        dynamic Gen_Mas2;
        List<string> Juego_Completado = new List<string>();
        int Errores_Max = 0;
        Random rnd = new Random();
        int cnivel_;


        Stopwatch Temporizador = new Stopwatch();


        public class Grid_0
        {
            public int a { get; set; }
            public int b { get; set; }
            public string v { get; set; }
            public string r { get; set; }
        }

        public Laberinto3(int cnivel)
        {
            InitializeComponent();
            cnivel_ = cnivel;
            Gen_Parametros();
            Temporizador.Start();
        }

        public void Gen_Parametros()
        {
            Juego_Completado = msqldb.msqldb_Select_Fields("cmensaje", "Mensajes_Completados", "").ToList().Select(x => x.Field<string>("cmensaje")).ToList();

            Errores_Max = Convert.ToInt32(msqldb.msqldb_Select_Fields("cerrores_max", "Juegos_Niveles", " WHERE cjuego = 'Laberinto' AND cnivel = " + cnivel_.ToString()).ToList().Single()[0]);

            Gen_Mas2 = msqldb.msqldb_Select("J_Laberinto", " WHERE cnivel = " + cnivel_.ToString()).ToList().Select(x => new
            {
                cinicio_1 = x.Field<string>("cinicio_1"),
                cfin_1 = x.Field<string>("cfin_1"),
                cdimension = x.Field<Int32>("cdimension"),
                cnivel = x.Field<Int32>("cnivel"),
                cniv_n = x.Field<Int32>("cniv_n"),
                cNiv_Cod = x.Field<string>("cNiv_Cod")
            }).ToList().OrderBy(x => rnd.Next()).Take(1).Single();
            Gen_Lab();
        }

        public void Gen_Lab()
        {
            //err = 0;
            TableLayoutPanel tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = Gen_Mas2.cdimension;
            tablaPanel.ColumnCount = Gen_Mas2.cdimension;
            for (int i = 0; i < Gen_Mas2.cdimension; i++)
            {
                var Porcentaje = 1;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }

            for (int a = 0; a < Gen_Mas2.cdimension; a++)
            {
                for (int b = 0; b < Gen_Mas2.cdimension; b++)
                {
                    var cj1 = pb();
                    cj1.Name = a.ToString() + b.ToString();
                    tablaPanel.Controls.Add(cj1, a, b);
                }
            }

            tablaPanel.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(tablaPanel);

            Des_Lab();
        }

        public void Des_Lab()
        {
            gr1.Clear();
            string Whe = " WHERE  cjuego = 1 AND cNiv_Cod = '" + Gen_Mas2.cNiv_Cod + "' AND cvalor = 1";

            msqldb.msqldb_Select("Juegos_Det", Whe).ToList().ForEach(x =>
            {
                gr1.Add(new Grid_0
                {
                    a = x.Field<Int32>("cpos_x"),
                    b = x.Field<Int32>("cpos_y"),
                    r = x.Field<string>("ccodigo"),
                    v = x.Field<string>("cvalor")
                });
            });

            panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(
                x => gr1.Select(y => y.r.ToString()).Contains(x.Name.ToString())
                ).ToList().ForEach(x => x.BackColor = Color.White);

            panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(
                x => !gr1.Select(y => y.r.ToString()).Contains(x.Name.ToString())
                ).ToList().ForEach(x => x.BackColor = Color.Black);


            var inicio = panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Single(x => x.Name.ToString() == Gen_Mas2.cinicio_1);
            var fin = panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Single(x => x.Name.ToString() == Gen_Mas2.cfin_1);
            inicio.BackColor = Color.Green;
            inicio.Enabled = true;
            fin.BackColor = Color.LightGreen;

            lpb = new List<PictureBox>();
            lpb = panel1.Controls[0].Controls.OfType<PictureBox>().ToList();

        }
        public PictureBox pb()
        {
            CartasJuego = new PictureBox();
            CartasJuego.Dock = DockStyle.Fill;
            CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
            CartasJuego.Cursor = Cursors.Hand;
            CartasJuego.MouseEnter += PB_Over;
            CartasJuego.Margin = new Padding(0);
            CartasJuego.Enabled = false;
            return CartasJuego;
        }

        private void PB_Over(object sender, EventArgs e)
        {
            lpb = panel1.Controls[0].Controls.OfType<PictureBox>().ToList();

            if (((PictureBox)sender).Name.ToString() == Gen_Mas2.cinicio_1)
            {
                lpb.ForEach(x => x.Enabled = true);
                ((PictureBox)sender).BackColor = Color.Green;
            }

            if (((PictureBox)sender).Name.ToString() != Gen_Mas2.cinicio_1)
            {
                ((PictureBox)sender).Enabled = false;
                lpb.Where(x => x.BackColor == Color.Green).ToList().ForEach(x => x.Enabled = false);
                lpb.Where(x => x.BackColor != Color.Green).ToList().ForEach(x => x.Enabled = true);

                if (((PictureBox)sender).BackColor == Color.White && True_Axis(((PictureBox)sender).Name.ToString()))
                {
                    ((PictureBox)sender).BackColor = Color.Green;
                }
                else if (((PictureBox)sender).BackColor == Color.Black)
                {
                    ((PictureBox)sender).BackColor = Color.Red;
                }
            }

            if (Errores_Max > 0 && lpb.Where(x => x.BackColor == Color.Red).Count() >= Errores_Max)
            {
                MessageBox.Show("Demasiado Errores, Intentalo Nuevamente");
                Gen_Parametros();
            }

            if (((PictureBox)sender).Name.ToString() == Gen_Mas2.cfin_1 && lpb.Where(x => x.BackColor == Color.White).Count() == 0)
            {
                Temporizador.Stop();
                if (finish_game()){
                    MessageBox.Show(Juego_Completado.OrderBy(x => rnd.Next()).Take(1).ToList()[0].ToString() + " - Errores: " + lpb.Where(x => x.BackColor == Color.Red).Count().ToString());
                    Gen_Parametros();
                }else { MessageBox.Show("Error al guardar el resultado"); }
            }
        }

        public bool finish_game()
        {
            try
            {
                string Fiel_Ins = "(`cjugador`, `cjuego`, `cnivel`, `cniv_n`, `cerrores`, `ctime`, `cfecha`)";
                string Val_Ins = "(" + Form1.usua + ", 1, " + Gen_Mas2.cnivel + ", " + Gen_Mas2.cniv_n + ", " + lpb.Where(x => x.BackColor == Color.Red).Count() + ", '" + Temporizador.Elapsed.TotalSeconds.ToString().Replace(',', '.') + "', NOW())";
                msqldb.msqldb_insert_fields("Resultados", Fiel_Ins, Val_Ins);
                return true;
            }
            catch { return false; }
        }

        public bool True_Axis(string pos)
        {
            List<string> pos1 = new List<string>();
            lpb = panel1.Controls[0].Controls.OfType<PictureBox>().ToList();
            var izq = pos.ToArray()[0].ToString();
            var der = pos.ToArray()[1].ToString();
            pos1.Add(izq + (Convert.ToInt32(der) - 1).ToString());
            pos1.Add(izq + (Convert.ToInt32(der) + 1).ToString());
            pos1.Add((Convert.ToInt32(izq) - 1).ToString() + der);
            pos1.Add((Convert.ToInt32(izq) + 1).ToString() + der);
            return lpb.Where(x => pos1.Contains(x.Name.ToString())).ToList().Any(x=>x.BackColor == Color.Green);
        }
    }
}
