using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestPres
{
    public class SimpleExample
    {
        public double CalcRefund(double purchasePrice)
        {
            if (purchasePrice > 1000)
            {
                double reStockingFeePercent = 0.01; //1% restocking fee

                double restockingFee = purchasePrice * reStockingFeePercent;
                return purchasePrice - restockingFee;
            }
            return purchasePrice;
        }

    }
}
