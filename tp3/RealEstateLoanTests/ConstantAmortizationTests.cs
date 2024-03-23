using RealEstateLoanApp;

namespace RealEstateLoanTests
{
    public class ConstantAmortizationTests
    {
        [Theory]
        [InlineData(50000, 108, 0.012, 488.64)]
        [InlineData(100000, 108, 0.015, 990.41)]
        [InlineData(200000, 180, 0.032, 1400.48)]
        [InlineData(500000, 240, 0.0367, 2943.67)]
        [InlineData(1000000, 300, 0.012, 3859.95)]
        public void CalculateMonthlyPayment(int loanAmount, int duration, double nominalRate, double monthlyRate)
        {
            var strategy = new ConstantAmortization(loanAmount, duration, nominalRate);

            double result = strategy.CalculateMonthlyPayment();

            Assert.Equal(monthlyRate, result);
        }

        [Theory]
        [InlineData(50000, 108, 0.012, 52773.12)]
        [InlineData(100000, 108, 0.015, 106964.28)]
        [InlineData(200000, 180, 0.032, 252086.40)]
        [InlineData(500000, 240, 0.0367, 706480.80)]
        [InlineData(1000000, 300, 0.012, 1157985)]
        public void CalculateTotalCost(int loanAmount, int duration, double nominalRate, double totalCost)
        {
            var strategy = new ConstantAmortization(loanAmount, duration, nominalRate);

            double result = strategy.CalculateTotalCost();

            Assert.Equal(totalCost, result);
        }
    }
}