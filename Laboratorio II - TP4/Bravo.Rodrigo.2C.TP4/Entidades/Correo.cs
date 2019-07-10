using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        /// <summary>
        /// Contructor inicial de Correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }
        /// <summary>
        /// Cierra los hilos contenidos en mockPaquetes para la instancia.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t != null)
                    t.Abort();
            }
        }
        /// <summary>
        /// Muestra los datos de la lista de paquetes para la instancia de Correo
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in this.Paquetes)
                sb.AppendFormat(p.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Añade un nuevo paquete a la instancia de correo que se recibe por parametro e inicia un nuevo hilo por paquete añadido
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p == paquete)
                    throw new TrackingIdRepetidoException($"El Tracking ID {p.TrackingID} ya figura en la lista de envíos");
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
    }
}
