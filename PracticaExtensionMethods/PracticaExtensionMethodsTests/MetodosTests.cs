using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExtensionMethods.Tests
{
    [TestClass()]
    public class MetodosTests
    {

        [TestMethod()]
        public void DivisionPorCeroTest()
        {
            //Arrange
            Assert.Fail();
        }

        [TestMethod()]
        public void DivisionTest()
        {
            //Arrange

            float dividendo = 8;
            float divisor = 4;
            float respuestaEsperada = 2;
            float resultado = 0;
            Metodos metodos = new Metodos();

            //act
            resultado = metodos.Division(dividendo, divisor);

            //assert
            Assert.AreEqual(respuestaEsperada, resultado);
        }

    }
}