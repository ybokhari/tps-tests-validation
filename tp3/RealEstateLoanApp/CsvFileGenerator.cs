using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class CsvFileGenerator : IFileGenerator
    {
        public void GenerateFile(IAmortizationStrategy amortizationStrategy)
        {
            using (StreamWriter writer = new StreamWriter("MyRealEstateLoan.csv"))
            {
                double totalCost = Math.Round(amortizationStrategy.CalculateTotalCost(), 2);
                double capitalRepaid = 0;
                double capitalOutstanding = totalCost;

                writer.WriteLine("Total cost of real estate loan; " + totalCost);
                writer.WriteLine("Monthly payment number; Capital repaid; Capital outstanding");

                for (int i = 1; i <= amortizationStrategy.duration; i++)
                {
                    double monthlyPayment = amortizationStrategy.CalculateMonthlyPayment();
                    capitalRepaid = Math.Round(capitalRepaid + monthlyPayment, 2);
                    capitalOutstanding = Math.Round(capitalOutstanding - monthlyPayment, 2);

                    writer.WriteLine($"{i}; {capitalRepaid}; {capitalOutstanding}");
                }
            }
        }
    }
}
