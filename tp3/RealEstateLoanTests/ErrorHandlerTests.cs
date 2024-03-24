using RealEstateLoanApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanTests
{
    public class ErrorHandlerTests
    {
        private ErrorHandler errorHandler;

        public ErrorHandlerTests()
        {
            errorHandler = new ErrorHandler();
        }

        [Theory]
        [InlineData(-70500)]
        [InlineData(0)]
        [InlineData(49999)]
        public void LoanAmountIsLessThanMinTest(int loanAmount)
        {
            bool result = errorHandler.IsLoanAmountValid(loanAmount);

            Assert.False(result);
        }

        [Theory]
        [InlineData(50000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void LoanAmountIsGreaterThanMinTest(int loanAmount)
        {
            bool result = errorHandler.IsLoanAmountValid(loanAmount);

            Assert.True(result);
        }

        [Theory]
        [InlineData(-50)]
        [InlineData(0)]
        [InlineData(107)]
        public void DurationIsLessThanMinTest(int duration)
        {
            bool result = errorHandler.IsDurationValid(duration);

            Assert.False(result);
        }

        [Theory]
        [InlineData(301)]
        [InlineData(525)]
        [InlineData(1000)]
        public void DurationIsGreaterThanMaxTest(int duration)
        {
            bool result = errorHandler.IsDurationValid(duration);

            Assert.False(result);
        }

        [Theory]
        [InlineData(108)]
        [InlineData(204)]
        [InlineData(300)]
        public void DurationIsBetweenMinAndMaxTest(int duration)
        {
            bool result = errorHandler.IsDurationValid(duration);

            Assert.True(result);
        }
    }
}
