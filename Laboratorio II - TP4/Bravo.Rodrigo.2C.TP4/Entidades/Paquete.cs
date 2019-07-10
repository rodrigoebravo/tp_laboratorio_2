using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        #endregion

        #region Eventos - Delegados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        #endregion

        public enum EEstado { Ingresado, EnViaje, Entregado }

        /// <summary>
        /// Unico contructor para la instancia Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        /// <summary>
        /// Simula Ciclo de vida para el paquete de instancia.
        /// finalizado el ciclo de vida, guarda los datos en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            for (int i = 0; i < 3; i++)
            {
                this.Estado = (Paquete.EEstado)i;
                InformaEstado(this, new EventArgs());
                Thread.Sleep(4000);
            }
            try
            {
                PaqueteDAO.Insetar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Muestra los datos TrackingID y DireccionEntrega de la instancia
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} para {1}", TrackingID, DireccionEntrega);
            return sb.ToString();
        }
        /// <summary>
        /// Dos paquetes serán distintos cuando tengan distinto Tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Dos paquetes serán iguales cuando tengan el mismo Tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }
        /// <summary>
        /// Metodo sobreescrito ToString para retornar los datos de instancia, incluido el estado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}",this.MostrarDatos(this), this.Estado.ToString());
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
