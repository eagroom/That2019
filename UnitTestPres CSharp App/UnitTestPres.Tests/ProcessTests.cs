using NUnit.Framework;
using UnitTestPres;
using Telerik.JustMock;
using System.Reflection;

namespace Tests
{
    public class ProcessTests
    {
        ILogger mockLogger;

        [SetUp]
        public void setup()
        {
            mockLogger = Mock.Create<ILogger>();
        }

        #region CalcRefund
        [Test]
        public void CalcRefund_WithRestockingFee()
        {
            //Arrange
            Process process = new Process(mockLogger);

            //Act
            double result = process.CalcRefund(25000);

            //Asert
            Assert.AreEqual(24750.00, result);
            Mock.Assert(() => mockLogger.errMessage(Arg.AnyString), Occurs.Never());
        }

        [Test]
        public void CalcRefund_WithOutRestockingfee()
        {
            //Arrange
            Process process = new Process(mockLogger);

            //Act
            double result = process.CalcRefund(250.06);

            //Asert
            Assert.AreEqual(250.06, result);
            Mock.Assert(() => mockLogger.errMessage(Arg.AnyString), Occurs.Never());
        }

        [Test]
        public void CalcRefund_PurchasePrice_Zero()
        {
            //Arrange
            Process process = new Process(mockLogger);

            //Act
            double result = process.CalcRefund(0);

            //Asert
            Assert.AreEqual(0, result);
            Mock.Assert(() => mockLogger.errMessage("Invalid Purchase Price"), Occurs.Once());
            Mock.Assert(() => mockLogger.errMessage(Arg.AnyString), Occurs.Once());
        }
        #endregion

        #region AddTax
        [Test]
        public void AddTax_overOneHundred()
        {
            //Arrange
            Process process = new Process(mockLogger);

            //Act
            double result = process.AddTax(100);

            //Asert
            Assert.AreEqual(107.00, result);
            Mock.Assert(() => mockLogger.errMessage(Arg.AnyString), Occurs.Never());
        }
        #endregion

        #region ValidateZipCode
        [Test]
        public void ValidateZipCode()
        {
            Process process = new Process(mockLogger);

            Assert.IsTrue((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345" }));
            Assert.IsTrue((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345-1234" }));

            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "123456-1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345-12345" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "123456" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345-123" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "1234-1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "123a5" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "123a5-1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345-123a" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345--1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345 1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "1234 -1234" }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "1234 " }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { "12345-123 " }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { " " }));
            Assert.IsFalse((bool)process.GetType().GetMethod("ValidateZipCode", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(process, new object[] { null }));
        }
        #endregion
    }
}