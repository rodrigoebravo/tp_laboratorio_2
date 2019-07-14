using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodPaqueteNotNull()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestMethodSinPaqueteRepetido()
        {
            Correo c = new Correo();
            c += new Paquete("Mendoza", "33555991");
            c += new Paquete("Cordoba Capital", "33555991");
        }

    }
}
