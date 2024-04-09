using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLoanApp;

namespace RealEstateLoanTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(50000, 108, 0.012, 488.64)]
        [InlineData(100000, 108, 0.015, 990.41)]
        [InlineData(200000, 180, 0.032, 1400.48)]
        [InlineData(500000, 240, 0.0367, 2943.67)]
        [InlineData(1000000, 300, 0.012, 3859.95)]
        public void CalculateMonthlyPaymentTest(int loanAmount, int duration, decimal nominalRate, decimal monthlyRate)
        {
            Calculator.loanAmount = loanAmount;
            Calculator.duration = duration;
            Calculator.nominalRate = nominalRate;

            decimal result = Calculator.CalculateMonthlyPayment();

            Assert.Equal(monthlyRate, result);
        }

        [Theory]
        [InlineData(50000, 108, 0.012, 2773.12)]
        [InlineData(100000, 108, 0.015, 6964.28)]
        [InlineData(200000, 180, 0.032, 52086.40)]
        [InlineData(500000, 240, 0.0367, 206480.80)]
        [InlineData(1000000, 300, 0.012, 157985)]
        public void CalculateTotalCostTest(int loanAmount, int duration, decimal nominalRate, decimal totalCost)
        {
            Calculator.loanAmount = loanAmount;
            Calculator.duration = duration;
            Calculator.nominalRate = nominalRate;

            decimal result = Calculator.CalculateTotalCost();

            Assert.Equal(totalCost, result);
        }
    }
}
