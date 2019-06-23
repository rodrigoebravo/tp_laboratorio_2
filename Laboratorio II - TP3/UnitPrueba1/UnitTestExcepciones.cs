using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestUniversidad
{
    [TestClass]
    public class UnitTestUniversidad
    {
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            //Alumno alum = new Alumno(12, "rodrigo", "bravo", 372561, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //int c = a / b;
            //Alumno alum2 = null;
            //Assert.AreEqual(5, c);
            try
            {
                Universidad gim1 = new Universidad();
                gim1 += new Profesor(100, "Juan", "Lopez", 12234456, EntidadesAbstractas.Persona.ENacionalidad.Argentino);
                gim1 += new Profesor(110, "Roberto", "Juarez", 32234456, EntidadesAbstractas.Persona.ENacionalidad.Argentino);
                List<Universidad.EClases> clasesNoExistentes = new List<Universidad.EClases>();
                clasesNoExistentes.Add(Universidad.EClases.Programacion);
                clasesNoExistentes.Add(Universidad.EClases.Laboratorio);
                clasesNoExistentes.Add(Universidad.EClases.Legislacion);
                clasesNoExistentes.Add(Universidad.EClases.SPD);
                List<Universidad.EClases> clasesExistentes = new List<Universidad.EClases>();
                foreach (Profesor p in gim1.Profesores)
                {
                    foreach (Universidad.EClases item in clasesNoExistentes)
                    {
                        if (p == item)
                            clasesExistentes.Add(item);
                    }
                }
                foreach (Universidad.EClases c in clasesExistentes)
                {
                    clasesNoExistentes.Remove(c);
                }

                if (clasesNoExistentes.Count == 0)
                {
                    throw new SinProfesorException();
                }

                foreach (Universidad.EClases claseNoExiste in clasesNoExistentes)
                {
                    gim1 += claseNoExiste;
                    break;
                }
            }
            catch (SinProfesorException e)
            {
                throw e;
            }

            //Assert.IsNotNull(alum, "ERROR");
        }
        [TestMethod]
        [ExpectedException(typeof(DniIvalidoException))]
        public void DniIvalidoExceptionException()
        {
            try
            {
                Alumno alumno = new Alumno(33, "Rodrigo", "Bravo", 359762879, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (DniIvalidoException e)
            {
                throw new DniIvalidoException(e);
            }
        }
        [TestMethod]
        public void TestNumerico()
        {
            Alumno alumno1 = new Alumno(33, "Rodrigo", "Bravo", 35976287, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno alumno2 = new Alumno(31, "Luis", "Armendil", 35976287, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsTrue(alumno1==alumno2);
        }
        [TestMethod]
        public void TestValorNullEnAtributo()
        {
            int id=33;
            string nombre="";
            string apellido="";
            int dni=359762;
            Persona.ENacionalidad nacionalidad= Persona.ENacionalidad.Argentino;
            Universidad.EClases claseQueToma=Universidad.EClases.SPD;
            Alumno alumno1 = new Alumno(id, nombre, apellido,dni,nacionalidad,claseQueToma);
            Assert.IsNotNull(alumno1.Apellido);
            Assert.IsNotNull(alumno1.DNI);
            Assert.IsNotNull(alumno1.Legajo);
            Assert.IsNotNull(alumno1.Nacionalidad);
            Assert.IsNotNull(alumno1.Nombre);
        }
    }
}
