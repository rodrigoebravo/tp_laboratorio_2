using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        /// <summary>
        /// Contructor de FrmPpal, inicializa constructor y asigna evento eventoDB necesario.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            PaqueteDAO.eventoDB += new PaqueteDAO.DelegadoDB(MostrarMensaje);
        }
        /// <summary>
        /// Muestra un mensaje con MessageBox.Show
        /// </summary>
        /// <param name="mensaje"></param>
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        /// <summary>
        /// Agrega paquete a Correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                p.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                correo += p;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Actualiza los estados de los paquetes en los distintos ListBox
        /// </summary>
        public void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach (Paquete p in this.correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p.MostrarDatos(p));
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p.MostrarDatos(p));
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p.MostrarDatos(p));
                        break;
                }
            }
        }
        /// <summary>
        /// Muestra la información de los paquetes del correo, y guarda en archivo los datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string archivo = "salida.txt";
            try
            {
                if (elemento == null)
                    return;
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                
                rtbMostrar.Text.Guardar(archivo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, $"Error al guardar datos en archivo {archivo}");
            }
        }
        /// <summary>
        /// Consulta por el estado de un objeto que se necesita en un subproceso. Una vez resuelto, informa el estado del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        /// <summary>
        /// Muestra los paquetes impresos en el formulario (rich)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Al cerrar el formulario, este metodo cierra todos los hilos que aun no fueron cerrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// Muestra la informacion del paquete seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarMenuToolStrip_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
