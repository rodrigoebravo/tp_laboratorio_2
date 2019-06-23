using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public Texto()
        {
        }

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
