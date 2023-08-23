using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace PracticaExtensionMethods.Tests
{
    [TestClass()]
    public class MetodosTests
    {

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCeroTest()
        {
            //arrange
            int num = 4;

            //act
            Metodos.Division(num);

            //no puse assert porque, según entendí por el ppt, no es necesario en este casoespecífico.
        }

        [TestMethod()]

        public void DivisionTest()
        {
            //Arrange

            float dividendo = 8;
            float divisor = 4;
            float respuestaEsperada = 2;
            float resultado ;
            Metodos metodos = new Metodos();

            //act
            resultado = Metodos.Division(dividendo, divisor);

            //assert
            Assert.AreEqual(respuestaEsperada, resultado);
        }
    }
}