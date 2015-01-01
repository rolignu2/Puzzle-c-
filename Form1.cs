using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace puzzle_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        protected string[] ResolucionJuego = new string[] { "1", "2", "3", "8", "-1", "4", "7", "6", "5" };
        protected int[] EstadosIniciales;
        protected delegate void DelegadoIniciarJuego();
        protected Thread HiloInicioJuego;
        private PuzzleResolucion PuzzleSolucion;
        private List<Button> ListadoBotones = new List<Button>();
        protected Dictionary<int, string> Pesos;


        private void Reordenamiento()
        {

            try
            {
                if (HiloBuscandoSolucion.IsAlive) HiloBuscandoSolucion.Abort();
            }
            catch { }
            ListaDetallesSolucion.Items.Clear();
            ListaDetallesSolucion.Visible = false;
            Estadoactualform();
            BarraProgreso.Visible = false;
            ListadoBotones = new List<Button>();
            Pesos = new Dictionary<int, string>();
            EstadosIniciales = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            int i = 0 , conteo_tags=0;
            while (true)
            {
                Control controles = this.Controls[i];
                if (controles.GetType() == typeof(Button))
                {
                    Button Boton = (Button) controles;
                    if (Boton.Tag != null)
                    {
                        Random rnd = new Random(DateTime.Now.Millisecond);
                   retorno:
                        int RndEscojido = rnd.Next(0,8);
                        int numero_asignado = EstadosIniciales[RndEscojido];
                        if (numero_asignado == 0) goto retorno;
                        else
                        {
                            if (Convert.ToInt32(Boton.Tag) != 5)
                            {
                                EstadosIniciales[RndEscojido] = 0;
                                conteo_tags++;
                                Boton.Text = numero_asignado.ToString();
                                Boton.ForeColor = Color.Yellow;
                                Boton.BackColor = Color.DarkBlue;
                            }
                            else if (Convert.ToInt32(Boton.Tag) == 5)
                            {
                                Boton.BackColor = Color.Red;
                                Boton.ForeColor = Color.Yellow;
                                Boton.Text = "";
                            }
                            Pesos.Add(int.Parse(Boton.Tag.ToString()), Boton.Text);
                            ListadoBotones.Add(Boton);
                        }
                    }
                }
                i++;
                if (conteo_tags == 8) break;
            }

            lblnotificacion.Visible = false;
            lblnotificacion.Text = "Juego Resuelto Con exito";
            lblcontador_movimiento.Text = "0";
            lbltiempo_transcurrido.Text = "0";
            min = 0;
            seg = 0;
            Ttrascurrido.Enabled = false;
            Tresolucion.Enabled = false;
            PuzzleSolucion = new PuzzleResolucion(ListadoBotones, Pesos);

        }

        protected void CargandoNuevoJuego()
        {

            try { if (HiloInicioJuego.IsAlive) HiloInicioJuego.Abort(); }
            catch { }
            HiloInicioJuego = new Thread(delegate()
            {
                DelegadoIniciarJuego Iniciar = new DelegadoIniciarJuego(Reordenamiento);
                this.Invoke(Iniciar);
            });
            HiloInicioJuego.Start();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
            CargandoNuevoJuego();
        }

        private void nuevoJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargandoNuevoJuego();
       
        }

        private void cmd_derecha_Click(object sender, EventArgs e)
        {
            Ttrascurrido.Enabled = true;
            if (!Tresolucion.Enabled) Tresolucion.Enabled = true;
            PuzzleSolucion.MoverDerecha();
        }

        private void cmd_izquierda_Click(object sender, EventArgs e)
        {
            Ttrascurrido.Enabled = true;
            if (!Tresolucion.Enabled) Tresolucion.Enabled = true;
            PuzzleSolucion.MoverIzquierda();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Ttrascurrido.Enabled = true;
            if (!Tresolucion.Enabled) Tresolucion.Enabled = true;
            PuzzleSolucion.MoverArriba();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Ttrascurrido.Enabled = true;
            if (!Tresolucion.Enabled) Tresolucion.Enabled = true;
            PuzzleSolucion.MoverAbajo();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Ttrascurrido.Enabled = true;
            if (!Tresolucion.Enabled) Tresolucion.Enabled = true;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    PuzzleSolucion.MoverArriba();
                    break;
                case Keys.Down:
                    PuzzleSolucion.MoverAbajo();
                    break;
                case Keys.Left:
                    PuzzleSolucion.MoverIzquierda();
                    break;
                case Keys.Right:
                    PuzzleSolucion.MoverDerecha();
                    break;
                default:
                    break;
            }
        }

        private void Tresolucion_Tick(object sender, EventArgs e)
        {
            try
            {
                string[] MovimientosHechos = PuzzleSolucion.EstadosDePesos;
                if (Enumerable.SequenceEqual(ResolucionJuego, MovimientosHechos))
                {
                    lblnotificacion.Visible = true;
                    Tresolucion.Enabled = false;
                    Ttrascurrido.Enabled = false;
                }
                else
                {
                    lblcontador_movimiento.Text = PuzzleSolucion.ObtenerMovimientos.ToString();
                   
                }
            }
            catch { }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tiempoTrascurridoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        double min=0, seg=0;
        private void Ttrascurrido_Tick(object sender, EventArgs e)
        {
            if (seg >= 60)
            {
                min++;
                seg = 0;
            }
            else seg++;

            lbltiempo_transcurrido.Text = min + " Min: " + seg + " Seg.";

            try
            {
                if (HiloBuscandoSolucion.IsAlive)
                {
                    if (min >= 1)
                    {
                        lblnotificacion.Visible = true;
                        lblnotificacion.Text = "Puede que la solucion tarde demaciado o no encuentre solucion; si desea cancelar ir a opciones y cancelar solucion";
                    }
                }
            }
            catch { }
            
        }

        private Thread HiloBuscandoSolucion;
        private void resolverJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListaDetallesSolucion.Items.Clear();
            ListaDetallesSolucion.Items.Add("Pasos realizados :");
            ListaDetallesSolucion.Items.Add("Secuencias ...");
            Ttrascurrido.Enabled = true;

            HiloBuscandoSolucion = new Thread(delegate()
            {
                BuscandoSolucion__ buscando = new BuscandoSolucion__(BuscandoSolucion);
                this.Invoke(buscando);
                Thread.Sleep(500);
                PuzzleSolucion.ResolverJuego(ResolucionJuego, this);
                SolucionEncontrada__ solve = new SolucionEncontrada__(SolucionEncontrada);
                this.Invoke(solve);
                Thread.Sleep(500);
                Stack<Nodo> PilaNodo = PuzzleSolucion.ObtenerMovimientosPila();

                if (PilaNodo.Count != 0)
                {
                    RealizarMovimientos__ mov = new RealizarMovimientos__(RealizarMovimientos);
                    pasos__ pasos_ = new pasos__(pasos);
                    int iteracion = 0;
                    foreach (PuzzleNodo NodoSolucion in PilaNodo)
                    {
                        iteracion++;
                        int[] Na = NodoSolucion.Hilos;
                        float h = NodoSolucion.Hn;
                        float g = NodoSolucion.Gn;
                        this.Invoke(mov, new object[] { Na, h, g });
                        this.Invoke(pasos_, new object[] { iteracion });
                        Thread.Sleep(500);

                    }
                }
                else
                {
                    Nosolucion__ no = new Nosolucion__(Nosolucion);
                    this.Invoke(no);
                }
            });
            HiloBuscandoSolucion.Start();
        }

        protected delegate void Nosolucion__();
        protected delegate void pasos__(int pasos);
        protected void pasos(int pasos)
        {
            try
            {
                ListaDetallesSolucion.Visible = true;
                ListaDetallesSolucion.Items[0] = "Pasos realizados : " + pasos;
            }
            catch { }
        }
        protected void Nosolucion()
        {
            lblnotificacion.Visible = true;
            lblnotificacion.Text = "No existe solucion";
        }
        protected delegate void RealizarMovimientos__(int[] movimiento, float h, float g);


        protected void RealizarMovimientos(int[] movimiento, float h, float g)
        {

           
            string Sec = null;
            for (int i = 0; i < movimiento.Length; i++)
            {
                int k = 0;
                Sec += movimiento[i].ToString() + "," ;
                while (true)
                {
                    Control controles = this.Controls[k++];
                    if (controles.GetType() == typeof(Button))
                    {
                        Button Boton = (Button)controles;
                        if (Convert.ToInt32(Boton.Tag) == (i+1))
                        {

                            if (movimiento[i] == 0)
                            {
                                Boton.Text = " ";
                                Boton.BackColor = Color.Red;
                            }
                            else
                            {
                                Boton.Text = movimiento[i].ToString();
                                Boton.BackColor = Color.DarkBlue;
                            }

                            break;
                        }
                    }
                }
            }

            ListaDetallesSolucion.Items.Add("{" + Sec + "}  H(n)=" + h + " G(n)= " + g );
            
        }

        protected delegate void SolucionEncontrada__();

        protected void SolucionEncontrada()
        {
            EstadoSolucionForm();
            lblnotificacion.Visible = true;
            lblnotificacion.Text = "Solucion encontrada";
            BarraProgreso.Visible = false;
        }

        protected delegate void BuscandoSolucion__();

        protected void BuscandoSolucion()
        {
            BarraProgreso.Visible = true;
            BarraProgreso.Style = ProgressBarStyle.Marquee;
        }
       
        protected void Estadoactualform()
        {
            this.Size = new Size(442,566);
        }

        protected void EstadoSolucionForm() { this.Size = new Size(442, 675); }

        private void cancelarSolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (HiloBuscandoSolucion.IsAlive) HiloBuscandoSolucion.Abort();
                BarraProgreso.Visible = false;
            }
            catch { }
        } 

       

     
    }
}
