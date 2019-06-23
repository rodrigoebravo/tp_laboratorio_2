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
        /// <summary>
        /// Agrega a las clases del dia del profesor una clase random
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Arma un string de la clase que pertenece esta instancia de alumno.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Operador que checkea que el profesor no tenga asignada esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i==clase);
        }

        /// <summary>
        /// Operador que checkea que el profesor tenga asignada esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Devuelve los datos del profesor como string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
