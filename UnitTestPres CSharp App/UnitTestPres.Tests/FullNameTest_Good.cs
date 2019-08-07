using NUnit.Framework;
using UnitTestPres;

namespace Tests
{
    public class FullNameTests_Good
    {
        [Test]
        public void GetFullName_WithCompanyName()
        {
            //Arrange
            Person person = new Person()
            {
                FirstName = "Thomas",
                LastName = "Smith",
                CompanyName = "Bright House"
            };

            //Act
            string fullName = person.GetFullName();

            //Assert
            Assert.AreEqual("Bright House", fullName);
        }

        [Test]
        public void GetFullName_WitoutCompanyName()
        {
            //Arrange
            Person person = new Person()
            {
                FirstName = "Thomas",
                LastName = "Smith",
                CompanyName = null
            };

            //Act
            string fullName = person.GetFullName();

            //Assert
            Assert.AreEqual("Smith, Thomas", fullName);
        }

        [Test]
        public void GetFullName_WithMiddleName()
        {
            //Arrange
            Person person = new Person()
            {
                FirstName = "Thomas",
                LastName = "Smith",
                MiddleName = "Kevin"
            };

            //Act
            string fullName = person.GetFullName();

            //Assert
            Assert.AreEqual("Smith K, Thomas", fullName);
        }
    }
}