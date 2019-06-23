using Excepciones;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        private string nombre;

        public string Apellido { get { return this.apellido; } set { this.apellido = ValidarNombreApellido(value); } }
        public string Nombre { get { return this.nombre; } set { this.nombre = ValidarNombreApellido(value); } }
        public int DNI { get { return this.dni; } set { this.StringToDNI = value.ToString(); } }
        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }
        public enum ENacionalidad { Argentino, Extranjero }

        public string StringToDNI { set { this.dni = ValidarDni(this.nacionalidad, value); } }
        /// <summary>
        /// Validará dni como string de acuerdo a la nacionalidad indicada
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniAux;
            if (dato.Length > 8 || !int.TryParse(dato, out dniAux))
                throw new DniIvalidoException();
            dniAux = ValidarDni(nacionalidad, dniAux);
            return dniAux;
        }
        /// <summary>
        /// Validará dni como int de acuerdo a la nacionalidad indicada
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (this.Nacionalidad == Persona.ENacionalidad.Argentino && (dato > 89999999 || dato < 1))
                throw new NacionalidadInvalidaException();
            if (this.Nacionalidad == Persona.ENacionalidad.Extranjero && (dato > 99999999 || dato < 90000000))
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            return dato;
        }

        /// <summary>
        /// Validará nombre y apellido del dato proporcionado
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato.Length < 30)
                return dato;
            return string.Empty;
        }

        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Armará una cadena de string con los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {1}, {0}", this.Nombre, this.Apellido);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad);
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
