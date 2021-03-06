﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClasesInstanciables
{

    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }
        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public Jornada(Profesor instructor, Universidad.EClases clase) : this()
        {
            this.Instructor = instructor;
            this.Clase = clase;
        }
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Retornará los datos de la Jornada como texto
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            return this.ToString();
        }
        /// <summary>
        /// Guarda los datos de la jornada en el directorio donde se esta ejecutando la aplicacion
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                string file = Directory.GetCurrentDirectory();
                var archivo = Path.Combine(file, "ArchivoJornada.txt");
                if (!File.Exists(archivo))
                    File.Create(archivo);
                using (StreamWriter stw = new StreamWriter(archivo))
                {
                    stw.WriteLine(jornada.ToString());
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Operador que checkea que el alumno no se encuentre en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Operador que checkea que el alumno se encuentre en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (var al in j.alumnos)
            {
                if (a == al)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Operador que agrega el alumno de no existir en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// Devuelve los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("JORNADA:");
            sb.AppendLine();
            sb.Append("CLASE DE ");
            switch (this.Clase)
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
            sb.AppendFormat(" POR {0}", this.Instructor.ToString());

            if (this.Alumnos.Count > 0)
            {
                sb.AppendLine("ALUMNOS:");
                foreach (Alumno item in this.Alumnos)
                {
                    sb.AppendLine(item.ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
