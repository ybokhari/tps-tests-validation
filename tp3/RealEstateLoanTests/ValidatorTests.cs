using RealEstateLoanApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanTests
{
    public class ValidatorTests
    {
        private Validator validator;

        public ValidatorTests()
        {
            validator = new Validator();
        }

        [Theory]
        [InlineData("150k")]
        [InlineData("Five")]
        [InlineData("#&%$K6523,")]
        [InlineData("Hello World!")]
        public void IsDoubleFalseTest(string input)
        {
            bool result = validator.IsDouble(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("-456")]
        [InlineData("0")]
        [InlineData("1.5")]
        [InlineData("3,25")]
        [InlineData("225")]
        [InlineData("150000")]
        public void IsDoubleTrueTest(string input)
        {
            bool result = validator.IsDouble(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData(-70500)]
        [InlineData(0)]
        [InlineData(49999)]
        public void LoanAmountIsLessThanMinTest(int loanAmount)
        {
            bool result = validator.IsLoanAmountValid(loanAmount);

            Assert.False(result);
        }

        [Theory]
        [InlineData(50000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void LoanAmountIsGreaterThanMinTest(int loanAmount)
        {
            bool result = validator.IsLoanAmountValid(loanAmount);

            Assert.True(result);
        }

        [Theory]
        [InlineData(-50)]
        [InlineData(0)]
        [InlineData(107)]
        [InlineData(301)]
        [InlineData(525)]
        [InlineData(1000)]
        public void DurationIsOutsideMinAndMaxTest(int duration)
        {
            bool result = validator.IsDurationValid(duration);

            Assert.False(result);
        }

        [Theory]
        [InlineData(108)]
        [InlineData(204)]
        [InlineData(300)]
        public void DurationIsBetweenMinAndMaxTest(int duration)
        {
            bool result = validator.IsDurationValid(duration);

            Assert.True(result);
        }

        [Theory]
        [InlineData(-0.001)]
        [InlineData(-65)]
        [InlineData(1.001)]
        [InlineData(8)]
        public void NominalRateIsOutside0And1(double nominalRate)
        {
            bool result = validator.IsNominalRateValid(nominalRate);

            Assert.False(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.001)]
        [InlineData(0.265)]
        [InlineData(0.999)]
        [InlineData(1)]
        public void NominalRateIsBetween0And1(double nominalRate)
        {
            bool result = validator.IsNominalRateValid(nominalRate);

            Assert.True(result);
        }
    }
}
