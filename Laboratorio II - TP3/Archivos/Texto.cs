using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Constructor necesario al instanciar Texto que implementa IArchivo<string>
        /// </summary>
        public Texto()
        {
        }
        /// <summary>
        /// Guardará en la ruta indicada como "archivo" los datos ingresados como "datos"
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);
            try
            {
                sw.WriteLine(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();
            }
            return true;
        }
        /// <summary>
        /// Leerá de la ruta indicada en el parametro "archivo" y se grabaran en el out string "datos"
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                    datos = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
    }
}
