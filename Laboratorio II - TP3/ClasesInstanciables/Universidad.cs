using Archivos;
using Excepciones;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public List<Profesor> Profesores { get { return this.profesores; } set { this.profesores = value; } }
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Jornada> Jornadas { get { return this.jornadas; } set { this.jornadas = value; } }
        public Jornada this[int i] { get { return this.Jornadas[i]; } set { this.Jornadas[i] = value; } }
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Profesores = new List<Profesor>();
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string path = $@"{Directory.GetCurrentDirectory()}\Universidad.xml";
            return xml.Guardar(path, uni);
        }
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad u = new Universidad();
            string path = $@"{Directory.GetCurrentDirectory()}\Universidad.xml";
            xml.Leer(path, out u);
            return u;
        }
        /// <summary>
        /// Serán distintos una universidad y un Alumno si el alumno no existe en la lista alumnos de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Serán iguales una universidad y un Alumno si el alumno existe en la lista alumnos de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno al in g.Alumnos)
            {
                if (a == al)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Profesor prof in g.Profesores)
            {
                if (p == prof)
                    return true;
            }
            return false;
        }
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p != clase)
                    return p;
            }
            return null;
        }
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            bool hayProfesor = false;
            foreach (Profesor p in g.Profesores)
            {
                if (p == clase)
                {
                    hayProfesor = true;
                    Jornada j = new Jornada(p, clase);
                    List<Alumno> alumnosAux = new List<Alumno>();
                    
                    foreach (Alumno a in g.Alumnos)
                    {
                        if (a == clase)
                            j.Alumnos.Add(a);
                    }
                    //foreach (Alumno al in alumnosAux)
                    //    g.Alumnos.Add(al);
                    g.Jornadas.Add(j);
                    break;
                }
            }
            if (!hayProfesor)
                throw new SinProfesorException();


            return g;
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g.Alumnos.Add(a);
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
                g.Profesores.Add(p);
            return g;
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in universidad.Jornadas)
            {
                sb.AppendLine(j.ToString());
                sb.AppendLine("<---------------------------------------------->");
            }

            //foreach (Profesor p in universidad.Profesores)
            //    sb.AppendLine(p.ToString());
            //
            //foreach (Alumno a in universidad.Alumnos)
            //    sb.AppendLine(a.ToString());

            return sb.ToString();
        }
    }
}
