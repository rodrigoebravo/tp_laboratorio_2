using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public partial class FormCalculadora : System.Windows.Forms.Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento usado para habilitar el ingreso de datos al textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumeroUno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = HabilitarIngreso(sender, e);
        }

        /// <summary>
        /// Evento usado para habilitar el ingreso de datos al textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumeroDos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = HabilitarIngreso(sender, e);
        }

        /// <summary>
        /// Metodo para habilitar el ingreso de un caracter en los componentes de ingreso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool HabilitarIngreso(object sender, KeyPressEventArgs e)
        {
            bool valorRet = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                valorRet = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                valorRet = true;
            }
            var texto = (sender as TextBox);
            if (e.KeyChar == '-')
            {
                if (texto.Text.Length >= 1)
                {
                    valorRet = true;
                }
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                valorRet = true;
            }
            return valorRet;
        }
        /// <summary>
        /// Boton que limpia todos los datos de la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroUno.Text = string.Empty;
            txtNumeroDos.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = "0";
        }
        /// <summary>
        /// Boton que finaliza la ejecucion del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        /// <summary>
        /// Boton que ejecuta la operacion entre los dos numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            txtNumeroUno.Text = FormatearNumeroEntrada(txtNumeroUno.Text);
            txtNumeroDos.Text = FormatearNumeroEntrada(txtNumeroDos.Text);
            lblResultado.Text = Calculadora.Operar(new Numero(txtNumeroUno.Text), new Numero(txtNumeroDos.Text), cmbOperador.Text).ToString();

        }
        /// <summary>
        /// /// Boton que onvierte de decimal a binario el resultado que se encuentra en lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (new Numero(lblResultado.Text)).DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// Boton que onvierte de binario a decimal el resultado que se encuentra en lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (new Numero(lblResultado.Text)).BinarioDecimal(lblResultado.Text);
        }
        /// <summary>
        /// Formatea los numeros ingresados por el usuario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        private string FormatearNumeroEntrada(string numero)
        {
            string ret = numero;
            if (string.IsNullOrEmpty(ret))
                return "0";
            if (ret[0].Equals('.'))
                ret = string.Format("0{0}", ret);
            if (ret[0].Equals('-') && ret[1].Equals('.'))
                ret = string.Format("-0.{0}", ret.Substring(2));
            if (ret[ret.Length - 1].Equals('.'))
                ret = string.Format("{0}0", ret);
            var prueba = double.Parse(ret);
            if (prueba == 0)
                ret = "0";
            return ret;
        }
        /// <summary>
        /// Inicializa variables y carga componentes principales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
            cmbOperador.SelectedItem = null;
            cmbOperador.SelectedText = "+";
            lblResultado.Text = "0";

        }
    }
}