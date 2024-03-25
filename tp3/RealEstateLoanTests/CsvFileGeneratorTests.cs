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
        private CsvFileGenerator csvFileGenerator;

        public CsvFileGeneratorTests()
        {
            csvFileGenerator = new CsvFileGenerator();
        }

        [Theory]
        [InlineData(50000, 108, 0.012)]
        [InlineData(100000, 108, 0.015)]
        [InlineData(200000, 180, 0.032)]
        [InlineData(500000, 240, 0.0367)]
        [InlineData(1000000, 300, 0.012)]
        public void GenerateFileTest(int loanAmount, int duration, double nominalRate)
        {
            ConstantAmortization constantAmortization = new ConstantAmortization(loanAmount, duration, nominalRate);
            double totalCost = constantAmortization.CalculateTotalCost();
            double monthlyPayment = constantAmortization.CalculateMonthlyPayment();

            csvFileGenerator.GenerateFile(constantAmortization);
            string[] lines = File.ReadAllLines("MyRealEstateLoan.csv");

            Assert.True(File.Exists("test.csv"));
            // Check the line of the total cost
            Assert.Equal($"Total cost of real estate loan; {totalCost}", lines[0]);
            // Check the line of headers
            Assert.Equal("Monthly payment number; Capital repaid; Capital outstanding", lines[1]);
            // Check the first line of amortization
            Assert.Equal($"1; {monthlyPayment}; {Math.Round(totalCost - monthlyPayment, 2)}", lines[2]);
            // Check the last line of amortization
            Assert.Equal($"{duration}; {totalCost}; 0", lines[duration + 1]);
        }
    }
}
