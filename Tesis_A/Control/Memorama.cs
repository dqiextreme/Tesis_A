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
    public partial class Memorama : UserControl
    {
        Mysql_Master msqldb = new Mysql_Master();
        int Movimientos = 0;
        int CantidadDeCartasVolteadas = 0;
        List<string> CartasEnumeradas;// = new List<string>();
        List<string> CartasRevueltas;// = new List<string>();
        ArrayList CartasSeleccionadas;// = new ArrayList();
        PictureBox CartaTemporal1;
        PictureBox CartaTemporal2;
        int CartaActual = 0;

        private static int Grid_Size;

        Form frm;

        Stopwatch Temporizador = new Stopwatch();

        public Memorama(int cnivel)
        {
            InitializeComponent();
            cnivel_ = cnivel;
            Gen_Parametros();
        }

        dynamic Gen_Mas2;
        List<string> Juego_Completado = new List<string>();
        int cnivel_;
        Random rnd = new Random();

        public void Gen_Parametros()
        {
            Juego_Completado = msqldb.msqldb_Select_Fields("cmensaje", "Mensajes_Completados", "").ToList().Select(x => x.Field<string>("cmensaje")).ToList();

            Gen_Mas2 = msqldb.msqldb_Select("J_Memoria", " WHERE cnivel = " + cnivel_.ToString()).ToList().Select(x => new
            {
                cdimension = x.Field<Int32>("cdimension"),
                cnivel = x.Field<Int32>("cnivel"),
                cniv_n = x.Field<Int32>("cniv_n"),
                cNiv_Cod = x.Field<string>("cNiv_Cod")
            }).ToList().OrderBy(x => rnd.Next()).Take(1).Single();

            Grid_Size = Gen_Mas2.cdimension;
            Temporizador.Start();
            master();
        }


        private void master()
        {
            timer1.Enabled = false;
            timer1.Stop();
            button2.Text = "Movimientos: 0";
            CantidadDeCartasVolteadas = 0;
            Movimientos = 0;
            panel1.Controls.Clear();
            CartasEnumeradas = new List<string>();
            CartasRevueltas = new List<string>();
            CartasSeleccionadas = new ArrayList();

            for (int i = 0; i < ((Grid_Size * Grid_Size) / 2); i++) 
            {
                CartasEnumeradas.Add(i.ToString());
                CartasEnumeradas.Add(i.ToString());
            }
            var NumeroAleatorio = new Random();
            var Resultado = CartasEnumeradas.OrderBy(item => NumeroAleatorio.Next());
            var a = Resultado.Count();

            foreach (string ValorCarta in Resultado)
            {
                CartasRevueltas.Add(ValorCarta);
            }
            //----
            TableLayoutPanel tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = Grid_Size;
            tablaPanel.ColumnCount = Grid_Size;
            for (int i = 0; i < Grid_Size; i++)
            {
                var Porcentaje = 1;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }
            //----
            int contadorFichas = 1;
            for (var i = 0; i < Grid_Size; i++)
            {
                for (var j = 0; j < Grid_Size; j++)
                {
                    var CartasJuego = new PictureBox();
                    CartasJuego.Name = string.Format("{0}", contadorFichas);
                    CartasJuego.Dock = DockStyle.Fill;
                    CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    CartasJuego.Image = Properties.Resources.Que;
                    CartasJuego.Cursor = Cursors.Hand;
                    CartasJuego.Click += btnCarta_Click;
                    tablaPanel.Controls.Add(CartasJuego, j, i);
                    contadorFichas++;
                }
            }
            tablaPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tablaPanel);
        }
       
        private void btnCarta_Click(object sender, EventArgs e)
        {
            if (CartasSeleccionadas.Count < 2)
            {
                Movimientos++;
                button2.Text = "Movimientos: " + Convert.ToString(Movimientos); 
                var CartasSeleccionadasUsuario = (PictureBox)sender;
                var ubisel = CartasSeleccionadasUsuario.Name;

                CartaActual = Convert.ToInt32(CartasRevueltas[Convert.ToInt32(CartasSeleccionadasUsuario.Name) - 1]);
                //CartasSeleccionadasUsuario.Image = RecuperarImagen(CartaActual);
                CartasSeleccionadasUsuario.Image = RecuperarImagen2(CartaActual);
                CartasSeleccionadas.Add(CartasSeleccionadasUsuario);
                
                if (CartasSeleccionadas.Count == 2)
                {
                    CartaTemporal1 = (PictureBox)CartasSeleccionadas[0];
                    CartaTemporal2 = (PictureBox)CartasSeleccionadas[1];
                    int Carta1 = Convert.ToInt32(CartasRevueltas[Convert.ToInt32(CartaTemporal1.Name) - 1]);
                    int Carta2 = Convert.ToInt32(CartasRevueltas[Convert.ToInt32(CartaTemporal2.Name) - 1]);

                    if (Carta1 != Carta2)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        CartaTemporal1.Enabled = false;
                        CartaTemporal2.Enabled = false;
                        var aa = panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(x => x.Enabled == true).Count();
                        if (panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Where(x => x.Enabled == true).Count() == 0)
                        {
                            Temporizador.Stop();
                            if (finish_game()){
                                MessageBox.Show(Juego_Completado.OrderBy(x => rnd.Next()).Take(1).ToList()[0].ToString());
                                Gen_Parametros();
                            }else { MessageBox.Show("Error al guardar el resultado"); }
                            
                        }
                        CartasSeleccionadas.Clear();
                    }
                }
            }
        }

        private Bitmap RecuperarImagen(int NumeroImagen)
        {
            
            Bitmap TmpImg = new Bitmap(200, 100);
            switch (NumeroImagen)
            {
                case 0: TmpImg = Properties.Resources.A11;
                    break;
                default:
                    var img = "A" + NumeroImagen;
                    TmpImg = (Bitmap)Properties.Resources.ResourceManager.GetObject("A" + NumeroImagen);
                    break;
            }
            return TmpImg;
        }

        //----------
        Tesis_A.Clase.Number_To_Image nti = new Clase.Number_To_Image();
        private Image RecuperarImagen2(int NumeroImagen)
        {
            PictureBox Pb_Size = panel1.Controls[0].Controls.OfType<PictureBox>().ToList().Take(1).SingleOrDefault();
            Size sz = Pb_Size.Size;
            Font bigFont = new Font(DefaultFont.FontFamily, (Pb_Size.Size.Width * 80) / 100, FontStyle.Regular);
            return nti.DTI2(NumeroImagen.ToString(), bigFont, Color.Black, Color.White, sz);
        }
        //----------

        private void timer1_Tick(object sender, EventArgs e)
        {
            int TiempoVirarCarta = 1;
            if (TiempoVirarCarta == 1)
            {
                CartaTemporal1.Image = Properties.Resources.Que;
                CartaTemporal2.Image = Properties.Resources.Que;
                CartasSeleccionadas.Clear();
                TiempoVirarCarta = 0;
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gen_Parametros();
        }

        public bool finish_game()
        {
            try
            {
                string Fiel_Ins = "(cjugador, cjuego, cnivel, cniv_n, cerrores, ctime, cfecha)";
                string Val_Ins = "(" + Form1.usua + ", 2, " + Gen_Mas2.cnivel + ", " + Gen_Mas2.cniv_n + ", 0, '" + Temporizador.Elapsed.TotalSeconds.ToString().Replace(',', '.') + "', NOW())";
                msqldb.msqldb_insert_fields("Resultados", Fiel_Ins, Val_Ins);
                return true;
            }
            catch { return false; }
        }
    }
}
