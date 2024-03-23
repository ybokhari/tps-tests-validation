using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class CsvFileGenerator : IFileGenerator
    {
        private IAmortizationStrategy _amortizationStrategy;

        public CsvFileGenerator(IAmortizationStrategy amortizationStrategy)
        {
            _amortizationStrategy = amortizationStrategy;
        }

        public void GenerateFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                double totalCost = Math.Round(_amortizationStrategy.CalculateTotalCost(), 2);
                double capitalRepaid = 0;
                double capitalOutstanding = totalCost;

                writer.WriteLine("Total cost of real estate loan; " + totalCost);
                writer.WriteLine("Monthly payment number; Capital repaid; Capital outstanding");

                for (int i = 1; i <= _amortizationStrategy.duration; i++)
                {
                    double monthlyPayment = _amortizationStrategy.CalculateMonthlyPayment();
                    capitalRepaid = Math.Round(capitalRepaid + monthlyPayment, 2);
                    capitalOutstanding = Math.Round(capitalOutstanding - monthlyPayment, 2);

                    writer.WriteLine($"{i}; {capitalRepaid}; {capitalOutstanding}");
                }
            }
        }
    }
}
