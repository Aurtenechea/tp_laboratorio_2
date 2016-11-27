using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Excepciones;
using EntidadesInstanciables;

namespace TestExcepciones
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDni()
        {
            try
            {
                Alumno a1 = new Alumno(4000, "Juan", "Lopez", "1aaqq456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.MesPrueba);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void TestNombreApellido()
        {
            try
            {
                Alumno a1 = new Alumno(4000, "#$%#$^", "asf", "1351546", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.MesPrueba);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message == "Nombre invalido.");
            }
        }

        [TestMethod]
        public void TestValoresNull()
        {
            Alumno a1 = new Alumno(4000, "qwersd", "werwg", "1351546", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.MesPrueba);
            Assert.AreNotEqual(null, a1.Nombre);
            Assert.AreNotEqual(null, a1.Apellido);
            Assert.AreNotEqual(null, a1.DNI);
            Assert.AreNotEqual(null, a1.Nacionalidad);
            Assert.AreNotEqual(null, a1.ClaseQueToma);
            Assert.AreNotEqual(null, a1.EstadoCuenta);
        }

        [TestMethod]
        public void InstanciaObjetos()
        {
            Gimnasio gim = new Gimnasio();
            Assert.AreNotEqual(null, gim.LsAlumno);
            Assert.AreNotEqual(null, gim.LsInstr);
            Assert.AreNotEqual(null, gim.LsJorn);
        }



    }
}
