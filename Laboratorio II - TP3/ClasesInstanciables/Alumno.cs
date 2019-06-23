using EntidadesAbstractas;
using System.Text;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private Alumno.EEstadoCuenta estadoCuenta;
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, int dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, int dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, Alumno.EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("ESTADO DE CUENTA: Cuota al día"); break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("ESTADO DE CUENTA: Deudor"); break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("ESTADO DE CUENTA: Becado"); break;
                default:
                    break;
            }
            sb.Append(this.ParticiparEnClase());
            
            return sb.ToString();
        }


        protected override string ParticiparEnClase()
        {
            string ret = "TOMA CLASES DE";
            switch (this.claseQueToma)
            {
                case Universidad.EClases.Programacion:
                    return $"{ret} Programación";
                case Universidad.EClases.Laboratorio:
                    return $"{ret} Laboratorio";
                case Universidad.EClases.Legislacion:
                    return $"{ret} Legislación";
                case Universidad.EClases.SPD:
                    return $"{ret} SPD";
                default:
                    return string.Empty;
            }
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
