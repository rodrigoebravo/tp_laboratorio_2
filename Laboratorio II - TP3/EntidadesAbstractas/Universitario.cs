using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        public int Legajo { get { return this.legajo; } set { this.legajo = value; } }
        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, int dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.Legajo = legajo;
        }
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Armará una cadena de string con los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine();
            sb.AppendFormat("LEGAJO NÚMERO: {0}", this.Legajo.ToString());
            sb.AppendLine();
            return sb.ToString();
        }
        /// <summary>
        /// Checkea si el objeto proporcionado es un Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        /// <summary>
        /// Checkeará si dos universitarios son iguales, si estos son del mismo tipo de dato y si tienen el mismo legajo o dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.Legajo == pg2.Legajo || pg1.DNI == pg2.DNI);
        }
        /// <summary>
        /// Checkeará si dos universitarios son distintos, si estos no son del mismo tipo de dato o si tienen el mismo legajo o dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
