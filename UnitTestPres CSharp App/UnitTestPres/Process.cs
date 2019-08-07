using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestPres
{
    public class Process
    {
        ILogger log;
        public Process()
        {
            log = new Logger();
        }


        public Process(ILogger theLog)
        {
            this.log = theLog;
        }

        public void Start()
        {
            // Good Exmaple for test fraility using Date time helper
            //Input from database or file
            //DateTime birthday = new DateTime(1981, 5, 1);
            //int age = CalcAge(birthday);

            double refund = CalcRefund(2500);
        }

        public double CalcRefund(double purchasePrice)
        {
            if (purchasePrice > 1000)
            {
                double reStockingFeePercent = 0.01; //1% restocking fee

                double restockingFee = purchasePrice * reStockingFeePercent;
                return purchasePrice - restockingFee;
            }
            else if (purchasePrice == 0)
            {
                log.errMessage("Invalid Purchase Price");
            }

            return purchasePrice;
        }

        public void DoItAll()  //SOLID PRINCIPLES
        {
            //Open the File
            //for each line calcuate the refund
            //write out to out pu file
            //write out to log
        }

        public double AddTax(double purchasePrice)
        {
            var tax = 0.07;
            return Math.Round(purchasePrice * 1 + tax, 2);
            //return Math.Round(purchasePrice * (1 + tax), 2);
        }

        private bool ValidateZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                return false;

            string pattern = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(zipCode);
        }
    }
}
