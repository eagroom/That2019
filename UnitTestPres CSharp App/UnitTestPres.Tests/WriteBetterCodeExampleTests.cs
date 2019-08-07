using NUnit.Framework;
using UnitTestPres;
using Telerik.JustMock;
using System.Reflection;


namespace UnitTestPres.Tests
{
    public class WriteBetterCodeExampleTests
    {
        #region AddTax
        [Test]
        public void AddTax_overOneHundred()
        {
            //Arrange
            WriteBetterCodeExample process = new WriteBetterCodeExample();

            //Act
            double result = process.AddTax(100);

            //Asert
            Assert.AreEqual(107.00, result);
        }

        [Test]
        public void AddTax_PurchasePrice_Zero()
        {
            //Arrange
            WriteBetterCodeExample process = new WriteBetterCodeExample();

            //Act
            double result = process.AddTax(0);

            //Asert
            Assert.AreEqual(0, result);
        }
        #endregion
    }
}
