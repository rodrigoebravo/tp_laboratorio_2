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

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine();
            sb.AppendFormat("LEGAJO NÚMERO: {0}", this.Legajo.ToString());
            sb.AppendLine();
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.Legajo == pg2.Legajo || pg1.DNI == pg2.DNI);
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
