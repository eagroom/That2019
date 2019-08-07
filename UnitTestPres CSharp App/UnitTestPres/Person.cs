using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestPres
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string CompanyName;
        public string GetFullName()
        {
            if (!string.IsNullOrWhiteSpace(this.CompanyName))
                return CompanyName;

            return $"{this.LastName} {(string.IsNullOrWhiteSpace(this.MiddleName) ? "" : this.MiddleName.Substring(0, 1))}, {this.FirstName}";
        }
    }
}
