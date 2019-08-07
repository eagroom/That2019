using NUnit.Framework;
using UnitTestPres;

namespace Tests
{
    public class FullNameTests_NotGood
    {
        Person person = new Person();
        
        [SetUp]
        public void setup() 
        {
            person.FirstName = "Thomas";
            person.LastName = "Smith";
            person.CompanyName = "Bright House";
        }

        [TearDown]
        public void tearDown()
        {

        }

        [Test]
        public void FullNameHappyCase()
        {
            Assert.AreEqual("Bright House", person.GetFullName());
        }

        [Test]
        public void WitoutCompanyName()
        {
            person.CompanyName = null;

            Assert.AreEqual("Smith, Thomas", person.GetFullName()); 
        }

        [Test]
        public void WithMiddleName() //dosn't mater that you set middle name the setup still setup the company
        {
            person.MiddleName = "Kevin";
            Assert.AreEqual("Smith K, Thomas", person.GetFullName());
        }

    }
}