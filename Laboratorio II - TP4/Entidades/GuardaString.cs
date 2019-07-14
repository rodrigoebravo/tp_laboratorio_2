using System;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extensión para "string" que guarda un texto en archivo dentro del directorio "Escritorio" local.
        /// Si existe el archivo, añade información, de lo contrario lo crea.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), archivo);

                using (StreamWriter sw = new StreamWriter(path, File.Exists(path)))
                {
                    sw.WriteLine(texto);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
