using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesis_A.Control
{
    public partial class Adm_Laberinto : UserControl
    {
        Mysql_Master msql = new Mysql_Master();
        int dimen = 0;
        PictureBox Pb_m;
        string cinicio;// = "";
        bool binicio = false;
        string cfin;
        bool bfin = false;
        List<Grid_0> gr1 = new List<Grid_0>();

        public class Grid_0
        {
            public int a { get; set; }
            public int b { get; set; }
            public bool v { get; set; }
            public string r { get; set; }
        }

        public Adm_Laberinto()
        {
            InitializeComponent();
            Combo_Box();
        }

        private void Combo_Box()
        {
            Cb_Nivel.Items.Add("Nivel Juego");
            Cb_Dimension.Items.Add("Dimension");

            for (int i = 1; i < 11; i++)
            {
                Cb_Nivel.Items.Add(i.ToString());
                if (i != 1)
                {
                    Cb_Dimension.Items.Add(i.ToString());
                }

            }
            Cb_Nivel.SelectedItem = "Nivel Juego";
            Cb_Dimension.SelectedItem = "Dimension";
        }

        public void Gen_Lab()
        {
            gr1.Clear();
            TableLayoutPanel tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = dimen;
            tablaPanel.ColumnCount = dimen;
            for (int i = 0; i < dimen; i++)
            {
                var Porcentaje = 1;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }

            for (int a = 0; a < dimen; a++)
            {
                for (int b = 0; b < dimen; b++)
                {
                    var cj1 = pb();
                    cj1.Name = a.ToString() + b.ToString();
                    tablaPanel.Controls.Add(cj1, a, b);
                }
            }

            tablaPanel.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(tablaPanel);
        }

        public PictureBox pb()
        {
            Pb_m = new PictureBox();
            Pb_m.Dock = DockStyle.Fill;
            Pb_m.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb_m.Cursor = Cursors.Hand;
            Pb_m.Click += Pb_Click;
            Pb_m.Margin = new Padding(1);
            Pb_m.BorderStyle = BorderStyle.FixedSingle;
            Pb_m.Enabled = true;
            return Pb_m;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            var nombre = ((PictureBox)sender).Name.ToCharArray();

            if (((cinicio != null) || cfin != null) && (!bfin))
            {
                ((PictureBox)sender).BackColor = Color.Green;
                gr1.Add(new Grid_0 { a = Convert.ToInt32(nombre[0].ToString()), b = Convert.ToInt32(nombre[1].ToString()), r = ((PictureBox)sender).Name.ToString(), v = true });
            }
            if (binicio && cinicio == null)
            {
                ((PictureBox)sender).BackColor = Color.LightGreen;
                ((PictureBox)sender).Enabled = false;
                button1.Enabled = false;
                binicio = false;
                cinicio = ((PictureBox)sender).Name.ToString();
                gr1.Add(new Grid_0 { a = Convert.ToInt32(nombre[0].ToString()), b = Convert.ToInt32(nombre[1].ToString()), r = ((PictureBox)sender).Name.ToString(), v = true });
                button2.Enabled = true;
            }
            if (bfin && cfin == null)
            {
                ((PictureBox)sender).BackColor = Color.Red;
                ((PictureBox)sender).Enabled = false;
                button2.Enabled = false;
                bfin = false;
                cfin = ((PictureBox)sender).Name.ToString();
                gr1.Add(new Grid_0 { a = Convert.ToInt32(nombre[0].ToString()), b = Convert.ToInt32(nombre[1].ToString()), r = ((PictureBox)sender).Name.ToString(), v = true });
                button3.Enabled = true;
                panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(x => x.Enabled == true).ToList().ForEach(y => y.Enabled = false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            binicio = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bfin = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cniv_n1 = Convert.ToInt32(msql.msqldb_Select_Fields("DISTINCT(cniv_n)", "J_Laberinto", "WHERE cnivel = " + Cb_Nivel.Text.Trim() + " ORDER BY cniv_n DESC LIMIT 1")[0][0]) + 1;
            string Val = "";
            gr1.ForEach(x => { Val += "(1, '" + Cb_Nivel.Text.Trim() + "-" + cniv_n1.ToString() + "', " + x.a + ", " + x.b + ", '" + x.r + "', " + x.v + "), "; });
            Val = Val.Trim().TrimEnd(',');
            msql.msqldb_insert_fields("Juegos_Det", "(`cjuego`, `cNiv_Cod`, `cpos_x`, `cpos_y`, `ccodigo`, `cvalor`)", Val);

            msql.msqldb_insert_fields("J_Laberinto", "(`cinicio_1`, `cfin_1`, `cdimension`, `cnivel`, `cniv_n`, `cNiv_Cod`)",
                "('" + cinicio + "', '" + cfin + "', " + Cb_Dimension.Text.Trim() + ", " + Cb_Nivel.Text.Trim() + ", " + cniv_n1 + ", '" + Cb_Nivel.Text.Trim() + "-" + cniv_n1.ToString() + "')");
            Registrado();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Cb_Dimension.Text.Trim().Length <= 2)
            {
                cinicio = null;
                cfin = null;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;

                dimen = Convert.ToInt32(Cb_Dimension.Text.Trim());
                Gen_Lab();
            }
        }

        private void Cb_Dimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cb_Nivel.Text.Trim() != "Nivel Juego") && (Cb_Dimension.Text.Trim() != "Dimension"))
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void Registrado()
        {
            gr1.Clear();
            panel1.Controls.Clear();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            Cb_Nivel.SelectedItem = "Nivel Juego";
            Cb_Dimension.SelectedItem = "Dimension";
            Cb_Nivel.Focus();
        }
    }
}
