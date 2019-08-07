using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestPres
{
    public class WriteBetterCodeExample
    {
        public double AddTax(double purchasePrice)
        {
            var tax = 0.07;
            return Math.Round(purchasePrice * 1 + tax, 2);
        }

    }
}
