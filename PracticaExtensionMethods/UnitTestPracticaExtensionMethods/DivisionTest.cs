using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExtensionMethods;
using System;

namespace UnitTestPracticaExtensionMethods
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void TestDivision()
        {
            // Arrange
            float num1 = 10;
            float num2 = 2;

            // Act
            float result = Extensions.Division(num1, num2);

            // Assert
            Assert.AreEqual(5, result); // Verifica que el resultado sea el esperado
        }

        [TestMethod]
        public void TestDivisionByZero()
        {
            // Arrange
            float num1 = 8;
            float num2 = 0;

            // Act
            float result = Extensions.Division(num1, num2);

            // Assert
            Assert.AreEqual(0, result); // Verifica que el resultado sea el esperado
        }
    }
}