using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        private Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, int dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
            //Codigo necesario para que los resultados por pantalla sean iguales a la salida por pantalla del TP
            //if (id == 1)
            //{
            //    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
            //    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
            //}
            //if (id == 2)
            //{
            //    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
            //    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
            //}
        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }
        protected override string MostrarDatos()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASES DEL DIA:");
            sb.AppendLine();
            foreach (Universidad.EClases item in clasesDelDia)
            {
                switch (item)
                {
                    case Universidad.EClases.Programacion:
                        sb.AppendFormat("Programación");
                        break;
                    case Universidad.EClases.Laboratorio:
                        sb.AppendFormat("Laboratorio");
                        break;
                    case Universidad.EClases.Legislacion:
                        sb.AppendFormat("Legislación");
                        break;
                    case Universidad.EClases.SPD:
                        sb.AppendFormat("SPD");
                        break;
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
