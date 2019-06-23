using System;

namespace Excepciones
{
    public class DniIvalidoException : Exception
    {
        public DniIvalidoException() : base("Error, Dni inválido")
        {
        }
        public DniIvalidoException(Exception e) : base("Error, Dni inválido", e)
        {
        }
        public DniIvalidoException(string message) : base(message)
        {
        }
        public DniIvalidoException(string message, Exception e) : base(message, e)
        {
        }
    }
}
