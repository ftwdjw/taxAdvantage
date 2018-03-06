using System;
using System.IO;

namespace taxAdvantage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i, maxYears = 34;
            //assume $1 for both investments
            //double investment = 1.0;
            //double investmentTaxable = 1.0;
            double taxRate = 0.20;
            double returnRate = .06;
            double taxableReturnRate = returnRate*(1 - taxRate);
            double exemptAccount, nonExempt,gain;
            string[] outputFile = new string[maxYears];


            for (i = 0; i < maxYears; i++)
            {
                
                exemptAccount = Math.Pow(1 + returnRate, i+1);
                nonExempt = Math.Pow(1 + taxableReturnRate, i + 1);
                gain = (exemptAccount - nonExempt)/nonExempt;
                outputFile[i] = string.Format("{0:#},{1:C},{2:C},{3:P}", 
                                              i+1, exemptAccount,nonExempt, gain);

                Console.WriteLine("year = {0:#} exempt Account={1:C}", 
                                  i+1, exemptAccount);
                Console.WriteLine("year = {0:#} non exempt Account={1:C}",
                                  i+1, nonExempt);
                Console.WriteLine("year = {0:#} gain={1:P}", i+1, gain);

            }

            File.WriteAllLines("gain.csv",outputFile);
            Console.WriteLine("have written csv file in bin directory");
            Console.ReadLine();
        }
    }
}
