using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExtensionMethods;

namespace TestExtensionMethods
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void DivisionTest()
        {
            // Arrange
            float num1 = 10;
            float num2 = 2;

            // Act
            float result = Extensions.Division(num1, num2);

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
