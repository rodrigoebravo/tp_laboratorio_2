using Excepciones;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.Default);
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                writer.Close();
            }
            return true;
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }
            return true;
        }
    }
}
