using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesis_A.Clase;

namespace Tesis_A.Control
{
    public partial class New_SL2 : UserControl
    {
        Mysql_Master msql = new Mysql_Master();
        PictureBox Pic_B_G;
        List<Grid_0> gr2 = new List<Grid_0>();
        Number_To_Image LTI = new Number_To_Image();
        List<string> selec = new List<string>();
        List<char> pala;
        int cniv_n1 = 1;
        List<Palab> Lista = new List<Palab>();

        public class Grid_0
        {
            public int a { get; set; }
            public int b { get; set; }
            public string v { get; set; }
            public string r { get; set; }
        }

        public class Palab
        {
            public string cpalabra { get; set; }
            public Int32 cnivel { get; set; }
            public Int32 cniv_n { get; set; }
            public string cNiv_Cod { get; set; }
            public string cini { get; set; }
            public string cfin { get; set; }
        }

        public New_SL2()
        {
            InitializeComponent();
            Combo_Box();
        }
        
        public PictureBox pb()
        {
            Pic_B_G = new PictureBox();
            Pic_B_G.Dock = DockStyle.Fill;
            Pic_B_G.SizeMode = PictureBoxSizeMode.StretchImage;
            Pic_B_G.Cursor = Cursors.Hand;
            Pic_B_G.Click += textBox1_Click;
            Pic_B_G.Margin = new Padding(1);
            Pic_B_G.Enabled = false;
            Pic_B_G.BorderStyle = BorderStyle.FixedSingle;
            return Pic_B_G;
        }

        public void Generar(int tam)
        {
            if (Convert.ToInt32(msql.msqldb_Select_Fields("COUNT(*)", "J_Sopa_Letras", "WHERE cnivel = " + Cb_Nivel.Text.Trim())[0][0]) > 0)
            {
                cniv_n1 = Convert.ToInt32(msql.msqldb_Select_Fields("DISTINCT(cniv_n)", "J_Sopa_Letras", "WHERE cnivel = " + Cb_Nivel.Text.Trim() + " ORDER BY cniv_n DESC LIMIT 1")[0][0]) + 1;
            }

            TableLayoutPanel tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = tam;
            tablaPanel.ColumnCount = tam;
            for (int i = 0; i < tam; i++)
            {
                var Porcentaje = 1;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }


            for (int a = 0; a < tam; a++)
            {
                for (int b = 0; b < tam; b++)
                {
                    var PB1 = pb();
                    PB1.Name = a.ToString() + b.ToString();
                    tablaPanel.Controls.Add(PB1, a, b);
                }
            }

            tablaPanel.Dock = DockStyle.Fill;
            tablaPanel.Name = "tbl";
            panel1.Controls.Clear();
            panel1.Controls.Add(tablaPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length <= Convert.ToInt32(Cb_Dimension.Text.Trim()))
            {
                pala = new List<char>();
                pala = textBox1.Text.Trim().ToArray().ToList();
                panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(x => x.BorderStyle == BorderStyle.FixedSingle).ToList().ForEach(x => x.Enabled = true);
            }
            else
            {
                MessageBox.Show("Debe ingresar una palabra menor a la dimension");
                textBox1.Clear();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            var asd = ((PictureBox)sender).Name.ToString();

            if (pala.Count > 0)
            {
                obcl(((PictureBox)sender));
                
                Size sz = ((PictureBox)sender).Size;
                Font bigFont = new Font(DefaultFont.FontFamily, (sz.Width * 80) / 100, FontStyle.Regular);

                ((PictureBox)sender).Image = LTI.DTI2(pala[0].ToString().Trim().ToUpper(), bigFont, Color.Black, Color.White, sz);
                ((PictureBox)sender).Enabled = false;
                ((PictureBox)sender).BorderStyle = BorderStyle.None;

                gr2.Add(new Grid_0 { a = Convert.ToInt32(asd.ToCharArray()[0].ToString()), b = Convert.ToInt32(asd.ToCharArray()[1].ToString()), r = asd, v = pala[0].ToString().ToUpper() });

                if (Lista.Any(x => x.cpalabra == textBox1.Text.Trim().ToUpper()))
                {
                    Lista.Where(x => x.cpalabra == textBox1.Text.Trim().ToUpper()).Single().cfin = "'" + asd + "'";
                }
                else
                {
                    Lista.Add(new Palab
                    {
                        cpalabra = textBox1.Text.Trim().ToUpper(), cnivel = Convert.ToInt32(Cb_Nivel.Text.Trim()), cniv_n = cniv_n1, cNiv_Cod = "'" + Cb_Nivel.Text.Trim() + "-" + cniv_n1 + "'",
                        cini = "'" + asd + "'", cfin = ""
                    });
                }
                pala.RemoveAt(0);
            }
            else
            {
                selec.Clear();
                panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(x => x.BorderStyle == BorderStyle.FixedSingle).ToList().ForEach(x => x.Enabled = true);
            }

            if (pala.Count == 0)
            {
                panel1.Controls[0].Controls.OfType<PictureBox>().ToList().ForEach(x => x.Enabled = false);
                selec.Clear();
                textBox1.Clear();
            }
        }

        private void obcl(PictureBox pbx)
        {
            string pos = pbx.Name.ToString();
            var Mcon = panel1.Controls[0].Controls.OfType<PictureBox>().ToList();
            
            List<string> pos1 = new List<string>();
                var izq = pos.ToArray()[0].ToString();
                var der = pos.ToArray()[1].ToString();

                pos1.Add(izq + (Convert.ToInt32(der) - 1).ToString());
                pos1.Add(izq + (Convert.ToInt32(der) + 1).ToString());
                pos1.Add((Convert.ToInt32(izq) - 1).ToString() + der);
                pos1.Add((Convert.ToInt32(izq) + 1).ToString() + der);
            
            Mcon.ForEach(x => x.Enabled = false);
            selec.Add(pbx.Name.ToString());

            if (selec.Count > 1)
            {
                var op = selec.Select(x => new { ini = x.ToCharArray()[0].ToString() }).ToList().All(x => x.ini == pos[0].ToString());
                if (op)
                {
                    try { Mcon.Single(x => x.Name.ToString() == pos1.Where(y => y[0].ToString() == pos[0].ToString()).ToList().First()).Enabled = true; } catch { }
                    try { Mcon.Single(x => x.Name.ToString() == pos1.Where(y => y[0].ToString() == pos[0].ToString()).ToList().Last()).Enabled = true; } catch { }
                }
                else
                {
                    try { Mcon.Single(x => x.Name.ToString() == pos1.Where(y => y[1].ToString() == pos[1].ToString()).ToList().First()).Enabled = true; } catch { }
                    try { Mcon.Single(x => x.Name.ToString() == pos1.Where(y => y[1].ToString() == pos[1].ToString()).ToList().Last()).Enabled = true; } catch { }
                }
            }
            else
            {
                Mcon.Where(x => pos1.Contains(x.Name.ToString())).ToList().ForEach(x => x.Enabled = true);
            }
        }

        private void Combo_Box()
        {
            Cb_Nivel.Items.Clear();
            Cb_Dimension.Items.Clear();
            Cb_Nivel.Items.Add("Nivel Juego");
            Cb_Dimension.Items.Add("Dimension");

            var a = msql.msqldb_Select_Fields("DISTINCT(cnivel)", "J_Sopa_Letras", "").ToList().Select(x => new { cnivel_n = x.Field<Int32>("cnivel") }).ToList();

            for (int i = 1; i < a.Count + 2; i++)
            {
                Cb_Nivel.Items.Add(i.ToString());
            }

            for (int i = 1; i < 11; i++)
            {
                if (i > 2)
                {
                    Cb_Dimension.Items.Add(i.ToString());
                }
            }

            Cb_Nivel.SelectedItem = "Nivel Juego";
            Cb_Dimension.SelectedItem = "Dimension";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Generar(Convert.ToInt32(Cb_Dimension.Text.Trim()));
            Add_Palabra.Enabled = true;
            textBox1.Enabled = true;
        }

        private void Cb_Dimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cb_Nivel.Text.Trim() != "Nivel Juego") && (Cb_Dimension.Text.Trim() != "Dimension"))
            {
                Generar_Grid.Enabled = true;
            }
            else
            {
                Generar_Grid.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.RemoveByKey("tbl");
            Combo_Box();
            Add_Palabra.Enabled = false;
            textBox1.Enabled = false;
            gr2.Clear();
            Lista.Clear();
            selec.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //nueva_palabra();
            string Val = "";
            Lista.ForEach(x =>
            {
                Val += "('" + x.cpalabra.ToString() + "', " + x.cnivel.ToString() + ", " + x.cniv_n.ToString() + ", " + x.cNiv_Cod.ToString() + ", " + x.cini + ", " + x.cfin + ", " + Cb_Dimension.Text.Trim() + "), ";
            });
            Val = Val.Trim().TrimEnd(',');
            msql.msqldb_insert_fields("J_Sopa_Letras", "(`cpalabra`, `cnivel`, `cniv_n`, `cNiv_Cod`, `cini`, `cfin`, `cdimension`)", Val);

            Val = "";
            gr2.ForEach(x =>
            {
                Val += "(3, '" + Cb_Nivel.Text.Trim() + "-" + cniv_n1.ToString() + "', " + x.a + ", " + x.b + ", '" + x.r + "', '" + x.v + "'), ";
            });
            Val = Val.Trim().TrimEnd(',');
            msql.msqldb_insert_fields("Juegos_Det", "(`cjuego`, `cNiv_Cod`, `cpos_x`, `cpos_y`, `ccodigo`, `cvalor`)", Val);
        }

    }
}
