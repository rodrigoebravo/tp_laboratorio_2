using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base("Hubo un problema al intentar procesar archivo", innerException)
        {

        }
    }
}
