using RealEstateLoanApp;

namespace RealEstateLoanTests
{
    public class ConstantAmortizationTests
    {
        [Fact]
        public void CalculateMonthlyPayment()
        {
            int loanAmount = 100000;
            int duration = 108;
            float nominalRate = (float)1.5;
            var strategy = new ConstantAmortization(loanAmount, duration, nominalRate);

            float result = strategy.CalculateMonthlyPayment();

            Assert.Equal(990, result);
        }
    }
}