using NUnit.Framework;
using UnitTestPres;
using Telerik.JustMock;
using System.Reflection;

namespace Tests
{
    public class SimpleExampleTests
    {
 
        #region CalcRefund
        [Test]
        public void CalcRefund_WithRestockingFee()
        {
            //Arrange
            SimpleExample process = new SimpleExample();

            //Act
            double result = process.CalcRefund(25000);

            //Asert
            Assert.AreEqual(24750.00, result);
        }

        [Test]
        public void CalcRefund_WithOutRestockingfee()
        {
            //Arrange
            SimpleExample process = new SimpleExample();

            //Act
            double result = process.CalcRefund(250.06);

            //Asert
            Assert.AreEqual(250.06, result);
        }
        #endregion

    }
}