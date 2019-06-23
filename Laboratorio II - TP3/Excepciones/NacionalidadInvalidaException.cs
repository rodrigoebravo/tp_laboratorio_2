using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base("Error, nacionalidad inválida")
        {
        }
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
    }
}
