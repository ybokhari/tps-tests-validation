using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLoanApp;

namespace RealEstateLoanTests
{
    public class CsvFileGeneratorTests
    {
        [Theory]
        [InlineData(50000, 108, 0.012)]
        [InlineData(200000, 180, 0.032)]
        [InlineData(500000, 240, 0.0367)]
        [InlineData(1000000, 300, 0.012)]
        public void GenerateFileTest(int loanAmount, int duration, decimal nominalRate)
        {
            StringBuilder sb = new();
            using TextWriter writer = new StringWriter(sb);
            CsvFileGenerator csvFileGenerator = new(writer);
            Calculator.loanAmount = loanAmount;
            Calculator.duration = duration;
            Calculator.nominalRate = nominalRate;
            decimal totalCost = Calculator.CalculateTotalCost();
            var amortizationTable = Calculator.CalculateAmortizationTable();

            csvFileGenerator.GenerateFile();
            string[] lines = sb.ToString().Split(Environment.NewLine);

            // Check the line of the total cost
            Assert.Equal($"Total cost of real estate loan; {totalCost}", lines[0]);
            // Check the line of headers
            Assert.Equal("Monthly payment number; Capital repaid; Capital outstanding", lines[1]);
            // Check each line of the amortization table
            foreach (var (monthlyPaymentNumber, capitalRepaid, capitalOutstanding) in Calculator.CalculateAmortizationTable())
            {
                Assert.Equal($"{monthlyPaymentNumber}; {capitalRepaid}; {capitalOutstanding}", lines[monthlyPaymentNumber + 1]);
            }
        }
    }
}
