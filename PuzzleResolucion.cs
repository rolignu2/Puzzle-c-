using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle_8
{

    #region resolucion del puzzle
    class PuzzleResolucion
    {

        private List<Button> ListaDeBotones = new List<Button>();
        private Dictionary<int, string> EstadosActuales = new Dictionary<int, string>();
        private int ConteoMovimientos = 0;
        private Nodo NodosMovimientos;

        private enum Movimientos
        {
            derecha,
            izquierda,
            arriba,
            abajo,
        }

        private void VerificarMovimiento(Movimientos Movimiento)
        {
            int ConMov = 0;
            Button Bvacio, BotonTemporal = null, Brespuesta = null;
            Bvacio = VerBotonVacio();
            foreach (Button BotonesReferentes in ListaDeBotones)
            {
                if (BotonesReferentes.Tag == Bvacio.Tag) continue;
                else
                {
                    bool Condicion_Encontrada = Condicion(BotonesReferentes.Location, Bvacio.Location, Movimiento);
                    if (Condicion_Encontrada)
                    {
                        if (BotonTemporal == null)
                            BotonTemporal = BotonesReferentes;
                        else if (BotonTemporal != null)
                            Brespuesta = ResolverChoques(BotonTemporal, BotonesReferentes, Bvacio);
                        if (ConMov == 0) ConMov = 1;
                    }
                }

            }
            try
            {
                if (Brespuesta == null)
                {
                    EstadosActuales[Convert.ToInt32(Bvacio.Tag)] = BotonTemporal.Text;
                    EstadosActuales[Convert.ToInt32(BotonTemporal.Tag)] = "-1";
                    Bvacio.Text = BotonTemporal.Text;
                    BotonTemporal.Text = "";
                    BotonTemporal.BackColor = Color.Red;
                    Bvacio.BackColor = Color.DarkBlue;
                }
                else
                {
                    EstadosActuales[Convert.ToInt32(Bvacio.Tag)] = Brespuesta.Text;
                    EstadosActuales[Convert.ToInt32(Brespuesta.Tag)] = "-1";
                    Bvacio.Text = Brespuesta.Text;
                    Brespuesta.Text = "";
                    Brespuesta.BackColor = Color.Red;
                    Bvacio.BackColor = Color.DarkBlue;
                }

                if (ConMov != 0) this.ConteoMovimientos++;

            }
            catch { }

        }

        private Button ResolverChoques(Button Temporal, Button Bchoque, Button vacio)
        {
            double Distancia1 = 0, Distancia2 = 0;
            Distancia1 = Math.Sqrt((Math.Pow((vacio.Location.X - Temporal.Location.X), 2) + Math.Pow((vacio.Location.Y - Temporal.Location.Y), 2)));
            Distancia2 = Math.Sqrt((Math.Pow((vacio.Location.X - Bchoque.Location.X), 2) + Math.Pow((vacio.Location.Y - Bchoque.Location.Y), 2)));

            if (Distancia2 < Distancia1)
                return Bchoque;
            else
                return Temporal;

        }

        private bool Condicion(Point Verificar, Point Vacio, Movimientos movimiento)
        {
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0, totX = 0, totY = 0;
            x1 = Verificar.X;
            x2 = Vacio.X;
            y1 = Verificar.Y;
            y2 = Vacio.Y;

            totX = x1 - x2;
            totY = y1 - y2;

            switch (movimiento)
            {

                case Movimientos.derecha:

                    if (totX <= -1 && totY == 0)
                        return true;
                    else
                        return false;
                case Movimientos.izquierda:
                    if (totX >= 0 && totY == 0)
                        return true;
                    else
                        return false;
                case Movimientos.arriba:
                    if (totX == 0 && totY >= 0)
                        return true;
                    else
                        return false;
                case Movimientos.abajo:
                    if (totX == 0 && totY < 0)
                        return true;
                    else
                        return false;

                default:
                    return false;

            }
        }

        protected Button VerBotonVacio()
        {

            foreach (Button Boton in ListaDeBotones)
            {
                if (Boton.Text == "")
                {
                    return Boton;
                }

            }

            return new Button();
        }

        public string[] EstadosDePesos
        {
            get
            {

                string[] data = new string[9];
                int i = 8;
                foreach (KeyValuePair<int, string> Valores in EstadosActuales)
                {
                    data[i] = Valores.Value;
                    i--;
                }
                return data;
            }
        }

        public PuzzleResolucion(List<Button> Listado, Dictionary<int, string> Pesos)
        {
            ListaDeBotones = Listado;
            this.EstadosActuales = Pesos;
        }

        public void MoverDerecha()
        {
            VerificarMovimiento(Movimientos.derecha);
        }

        public void MoverIzquierda()
        {
            VerificarMovimiento(Movimientos.izquierda);
        }

        public void MoverArriba()
        {
            VerificarMovimiento(Movimientos.arriba);
        }

        public void MoverAbajo()
        {
            VerificarMovimiento(Movimientos.abajo);
        }

        public int ObtenerMovimientos { get { return this.ConteoMovimientos; } }

        public void ResolverJuego(string[] ResolucionJuego, System.Windows.Forms.Form puntero)
        {

            int[] VectorActual = new int[9];
            int[] VectorMeta = new int[9];

            for (int i = 0; i < 9; i++)
            {
                if (this.EstadosActuales[(i + 1)] != "")
                    VectorActual[i] = Convert.ToInt32(this.EstadosActuales[(i + 1)]);
                else
                    VectorActual[i] = 0;
                if (ResolucionJuego[i] != "-1")
                    VectorMeta[i] = Convert.ToInt32(ResolucionJuego[i]);
                else
                    VectorMeta[i] = 0;
            }

            var Ganador = new PuzzleNodo { Hilos= VectorMeta };
            var Inicial = new PuzzleNodo { Hilos = VectorActual };

            var BuscarSimilitudes = new BuscarUbicacion(
                        new SucesorNodosGenerador(),
                        new CalculadorDevalores(),
                        new ManhattanCalculadorDistancia());

            Nodo resultado = BuscarSimilitudes.Ejecutar(Inicial, Ganador);
            this.NodosMovimientos = resultado;
            //obsoleto , use una forma mejor de resolver los datos
            //ImprimirSolucion(resultado , puntero);
        }

        public Stack<Nodo> ObtenerMovimientosPila()
        {
            Stack<Nodo> pila = new Stack<Nodo>();

            do
            {
              pila.Push(NodosMovimientos);
            } while ((NodosMovimientos = NodosMovimientos.Padre) != null);

            return pila;
        }
       

        /// <summary>
        ///  se consideran obsoletos ya que utilice una mejor solucion
        /// </summary>
        /// <param name="NodoB"></param>
        [Obsolete]
        private delegate void ReordenamientoBotonesDelegado(int[] NodoB);

        /// <summary>
        /// se consideran obsoletos ya que utilice una mejor solucion
        /// </summary>
        /// <param name="NodoB"></param>
        [Obsolete]
        private void ReordenamientBotones(int[] NodoB)
        {

            int k = 0;
            for (int i = (NodoB.Length - 1); i >= 0; i--,k++)
            {
                var tag = ListaDeBotones[i].Tag;
                if (NodoB[k] == 0)
                {
                    ListaDeBotones[i].Text = " ";
                    ListaDeBotones[i].BackColor = Color.Red;
                }
                else
                {
                    ListaDeBotones[i].Text = NodoB[k].ToString();
                    ListaDeBotones[i].BackColor = Color.DarkBlue;
                }

            }
        }

        /// <summary>
        /// se consideran obsoletos ya que utilice una mejor solucion
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="puntero"></param>
        [Obsolete]
        private void ImprimirSolucion(Nodo nodo, System.Windows.Forms.Form puntero)
        {

            if (nodo != null)
            {

                Stack<Nodo> pila = new Stack<Nodo>();

                do
                {
                    pila.Push(nodo);
                } while ((nodo = nodo.Padre) != null);


                ReordenamientoBotonesDelegado reordenar = new ReordenamientoBotonesDelegado(ReordenamientBotones);
                foreach (PuzzleNodo NodoSolucion in pila)
                {

                    int[] Na = NodoSolucion.Hilos;
                    puntero.Invoke(reordenar, new object[] { Na });
                    Thread.Sleep(1000);
                }

            }
            else
            {
               // Console.WriteLine("No solution");
            }

        }


    }
    #endregion


    #region Solucion metodo Heuristico y manhathan
    public interface Nodo
    {
        float Fn { get; set; } // G + H
        float Gn { get; set; } // Cost pasado 
        float Hn { get; set; } // Heurstica - estimado costos ganancia
        Nodo Padre { get; set; }

        bool EstadoNodosIguales(Nodo node);
    }

    public class CalculadorDevalores : IGCalculador
    {
        private const float Factorcosto = 0.265f; 

        public float Executar(Nodo node)
        {
            return node.Gn + Factorcosto;
        }

    }

    public class ManhattanCalculadorDistancia : IHCalculador
    {
        private const float factorcosto = 1.0f;

        public float EjecutarSecuencia(Nodo ganador, Nodo nodo)
        {
            float resultado = 0.0f;
            var nodo_actual = nodo as PuzzleNodo;
            var nodo_ganador = ganador as PuzzleNodo;

            for (int i = 0; i < 9; i++)
            {
                if (nodo_ganador == null) continue;
                int numeroActual = nodo_ganador.Hilos[i];
                int indexadoActual = EncontrarIndexadoActual(numeroActual, nodo_actual);

                resultado = ObtenerdistanciaTejadoEindexado(resultado, i, indexadoActual);
            }

            return resultado;
        }


        private static float ObtenerdistanciaTejadoEindexado(float resultado, int i, int indexado_actual)
        {
            if (indexado_actual == i + 0)
                return resultado;

            if (indexado_actual == i + 1 || indexado_actual == i + 3)
                resultado += factorcosto;
            else if (indexado_actual == i + 2 || indexado_actual == i + 4 || indexado_actual == i + 6)
                resultado += 2 * factorcosto;
            else if (indexado_actual == i + 5 || indexado_actual == i + 7)
                resultado += 3 * factorcosto;
            else if (indexado_actual == i + 8)
                resultado += 4 * factorcosto;
            return resultado;
        }

        private static int EncontrarIndexadoActual(int numeroGanado, PuzzleNodo corriente)
        {
            for (int j = 0; j < 9; j++)
            {
                if (corriente.Hilos[j] == numeroGanado)
                {
                    return j;
                }
            }

            return -1;
        }
    }

    public interface IGCalculador
    {
        float Executar(Nodo node);
    }

    public interface IHCalculador
    {
        float EjecutarSecuencia(Nodo NodoGanador, Nodo nodo);
    }

    public class BuscarUbicacion
    {
        private readonly IsucesorNodoGenerador _GeneradorNodosSucesores;
        private readonly IGCalculador _gNcalculador;
        private readonly IHCalculador _hNcalculador;

        public BuscarUbicacion(IsucesorNodoGenerador GeneradorNodoSucesores,
                          IGCalculador gCalculador,
                          IHCalculador hCalculador)
        {
            _GeneradorNodosSucesores = GeneradorNodoSucesores;
            _gNcalculador = gCalculador;
            _hNcalculador = hCalculador;
        }

        public int Ciclos { get; private set; }

        public Nodo Ejecutar(Nodo NodoInicial, Nodo NodoGanador)
        {
            Ciclos = 0;

            var Lista = new List<Nodo> { NodoInicial };
            var ListaCerrada = new List<Nodo>();

            while (Lista.Count > 0)
            {
                Ciclos++;
                Nodo NodoActual = ObtenerNodosENlista(Lista);

                Lista.Remove(NodoActual);
                ListaCerrada.Add(NodoActual);

                IEnumerable<Nodo> NodosSucesores =
                    _GeneradorNodosSucesores.Ejecutar(NodoActual);

                foreach (Nodo NodoSucesor in NodosSucesores)
                {
                    if (NodoSucesor.EstadoNodosIguales(NodoGanador))
                        return NodoSucesor;

                    NodoSucesor.Gn = _gNcalculador.Executar(NodoActual);
                    NodoSucesor.Hn = _hNcalculador.EjecutarSecuencia(NodoGanador, NodoSucesor);
                    NodoSucesor.Fn = NodoSucesor.Gn + NodoSucesor.Hn;

                    if (ListaMejorNodo(NodoSucesor, Lista))
                        continue;

                    Lista.Add(NodoSucesor);
                }
            }

            return null;
        }

        private static Nodo ObtenerNodosENlista(IEnumerable<Nodo> Lista)
        {
            return Lista.OrderBy(n => n.Fn).First();
        }

        private static bool ListaMejorNodo(Nodo Sucesor, IEnumerable<Nodo> lista)
        {
            return lista.FirstOrDefault(n => n.Gn.Equals(Sucesor.Gn)
                    && n.Fn < Sucesor.Fn) != null;
        }
    }

    public class PuzzleNodo : Nodo
    {
        private int _HiloVacio;

        public PuzzleNodo()
        {
            _HiloVacio = -1;
        }

        public int[] Hilos { get; set; }

        public int HiloVacio
        {
            get
            {
                if (_HiloVacio == -1)
                    _HiloVacio = ObtenerPosicionVaciaHilo(this);

                return _HiloVacio;
            }
        }

        public float Fn { get; set; }
        public float Gn { get; set; }
        public float Hn { get; set; }

        public Nodo Padre { get; set; }

        public bool EstadoNodosIguales(Nodo nodo)
        {
            var ProbarNodo = nodo as PuzzleNodo;
            return ProbarNodo != null && Hilos.SequenceEqual(ProbarNodo.Hilos);
        }

        private static int ObtenerPosicionVaciaHilo(PuzzleNodo node)
        {
            int HiloVacio = -1;

            for (int i = 0; i < 9; i++)
            {
                if (node.Hilos[i] == 0)
                {
                    HiloVacio = i;
                    break;
                }
            }

            return HiloVacio;
        }
    }

    public class CalculadorDeBasesNodosSUcesores : NodoSucesorCalcularReglas
    {

        public virtual IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            return null;
        }

        public virtual bool Encontrado(Nodo nodo)
        {
            return false;
        }

        protected static void AgregarSuccesor(PuzzleNodo nodo,
                                           ICollection<Nodo> resultado,
                                           int HiloIntercambio)
        {
            var nuevoestado = nodo.Hilos.Clone() as int[];
            if (nuevoestado == null) return;
            nuevoestado[nodo.HiloVacio] = nuevoestado[HiloIntercambio];
            nuevoestado[HiloIntercambio] = 0;

            if (!EstadoPadreIgual(nodo.Padre, nuevoestado))
                resultado.Add(new PuzzleNodo { Hilos = nuevoestado, Padre = nodo });
        }

        private static bool EstadoPadreIgual(Nodo node, IEnumerable<int> state)
        {
            return node != null && state.SequenceEqual(((PuzzleNodo)node).Hilos);
        }
    }

    public class SucesorNodosGenerador : IsucesorNodoGenerador
    {
        
        public IEnumerable<Nodo> Ejecutar(Nodo currentNode)
        {
            try
            {
                var node = currentNode as PuzzleNodo;

                var NodoSucesorReglasDeljuego =
                    new List<NodoSucesorCalcularReglas>
                    {
                        new SucesorsHilovacioCero(),
                        new SucesorsHilovacioUno(),
                        new SucesorsHilovacioDos(),
                        new SucesorsHilovacioTres(),
                        new SucesorsHilovacioCuatro(),
                        new SucesorsHilovaciocinco(),
                        new SucesorsHilovacioSeis(),
                        new SucesorsHilovacioSiete(),
                        new SucesorsHilovacioOcho()
                    };

                return NodoSucesorReglasDeljuego
                    .Single(r => r.Encontrado(node))
                    .GetSucesor(node);
            }
            catch { return null; }
        
        }

    }

    public class SucesorsHilovacioOcho : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 5);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 7);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 8;
        }
    }

    public class SucesorsHilovaciocinco : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 2);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 4);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 8);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 5;
        }
    }

    public class SucesorsHilovacioCuatro : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 1);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 3);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 5);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 7);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 4;
        }
    }

    public class SucesorsHilovacioUno : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 0);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 2);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 4);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 1;
        }
    }

    public class SucesorsHilovacioSiete : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 4);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 6);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 8);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 7;
        }
    }

    public class SucesorsHilovacioSeis : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 3);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 7);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 6;
        }
    }

    public class SucesorsHilovacioTres : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 0);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 4);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 6);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 3;
        }
    }

    public class SucesorsHilovacioDos : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 1);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 5);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 2;
        }
    }

    public class SucesorsHilovacioCero : CalculadorDeBasesNodosSUcesores
    {
        public override IEnumerable<Nodo> GetSucesor(Nodo nodo)
        {
            var resultado = new List<Nodo>();

            AgregarSuccesor((PuzzleNodo)nodo, resultado, 1);
            AgregarSuccesor((PuzzleNodo)nodo, resultado, 3);

            return resultado;
        }

        public override bool Encontrado(Nodo node)
        {
            return ((PuzzleNodo)node).HiloVacio == 0;
        }
    }

    public interface NodoSucesorCalcularReglas
    {
        IEnumerable<Nodo> GetSucesor(Nodo nodo);
        bool Encontrado(Nodo nodo);
    }

    public interface IsucesorNodoGenerador
    {
        IEnumerable<Nodo> Ejecutar(Nodo nodo);
    }

#endregion
}



