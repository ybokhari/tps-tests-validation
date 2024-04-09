using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RealEstateLoanApp
{
    public class CsvFileGenerator(TextWriter writer)
    {
        private TextWriter Writer { get; } = writer;

        public void GenerateFile()
        {
            decimal totalCost = Calculator.CalculateTotalCost();

            Writer.WriteLine("Total cost of real estate loan; " + totalCost);
            Writer.WriteLine("Monthly payment number; Capital repaid; Capital outstanding");

            foreach (var (monthlyPaymentNumber, capitalRepaid, capitalOutstanding) in Calculator.CalculateAmortizationTable())
            {
                Writer.WriteLine($"{monthlyPaymentNumber}; {capitalRepaid}; {capitalOutstanding}");
            }
        }
    }
}
