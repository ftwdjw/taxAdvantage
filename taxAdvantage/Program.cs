using System;
using System.IO;

namespace taxAdvantage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i, maxYears = 34;
            double investment = 1.0;
            double investmentTaxable = 1.0;
            double taxRate = 0.20;
            double returnRate = .06;
            double taxableReturnRate = returnRate*(1 - taxRate);
            double exemptAccount, nonExempt,gain;
            string[] outputFile = new string[maxYears];


            for (i = 0; i < maxYears; i++)
            {

                exemptAccount = investment * (1 + returnRate);
                nonExempt = investmentTaxable * (1 + taxableReturnRate);
                gain = (exemptAccount - nonExempt);
                outputFile[i] = string.Format("{0:#},{1:C},{2:C},{3:P}", i+1, exemptAccount,nonExempt, gain);

                Console.WriteLine("year = {0:#} exempt Account={1:C}", i+1, exemptAccount);
                Console.WriteLine("year = {0:#} non exempt Account={1:C}", i+1, nonExempt);
                Console.WriteLine("year = {0:#} gain={1:P}", i+1, gain);

                investment = exemptAccount;
                investmentTaxable = nonExempt;
            }

            File.WriteAllLines("gain.csv",outputFile);
            Console.WriteLine("have written csv file in bin directory");
            Console.ReadLine();
        }
    }
}
