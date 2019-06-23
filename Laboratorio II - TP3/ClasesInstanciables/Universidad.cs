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

        /// <summary>
        /// Guarda los datos de la universidad en formato XML en el directorio donde se ejecuta esta aplicacion. Archivo: Universidad.xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string path = $@"{Directory.GetCurrentDirectory()}\Universidad.xml";
            return xml.Guardar(path, uni);
        }
        /// <summary>
        /// Lee el archivo Universidad.xml del directorio donde se ejecuta esta aplicacion. 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Serán distintos una universidad y un Profesor si el profesor no existe en la lista profesores de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// Serán iguales una universidad y un Profesor si el profesor existe en la lista profesores de la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Profesor prof in g.Profesores)
            {
                if (p == prof)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Serán distintos una universidad y una clase si no existe profesor que pueda darla en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p != clase)
                    return p;
            }
            return null;
        }
        /// <summary>
        /// Serán distintos una universidad y una clase si existe profesor que pueda darla en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Sumará una clase a la universidad si existe profesor que pueda darla, posterior sumará alumnos a ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sumará alumno si no existe el alumno en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g.Alumnos.Add(a);
            return g;
        }
        /// <summary>
        /// Sumará profesor si no existe el profesor en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
                g.Profesores.Add(p);
            return g;
        }
        /// <summary>
        /// Mostrará los datos de la universidad, junto a sus jornadas, profesores y alumnos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Armará una cadena de string con los datos de la universidad,incluyendo a sus jornadas, profesores y alumnos.
        /// </summary>
        /// <param name="universidad"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in universidad.Jornadas)
            {
                sb.AppendLine(j.ToString());
                sb.AppendLine("<---------------------------------------------->");
            }

            return sb.ToString();
        }
    }
}
