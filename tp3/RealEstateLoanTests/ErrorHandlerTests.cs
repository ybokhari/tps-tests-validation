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
        [Theory]
        [InlineData(-70500)]
        [InlineData(0)]
        [InlineData(49999)]
        public void LoanAmountIsLessThanMinTest(int loanAmount)
        {
            ErrorHandler errorHandler = new ErrorHandler();

            bool result = errorHandler.IsLoanAmountValid(loanAmount);

            Assert.False(result);
        }

        [Theory]
        [InlineData(50000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void LoanAmountIsGreaterThanMinTest(int loanAmount)
        {
            ErrorHandler errorHandler = new ErrorHandler();

            bool result = errorHandler.IsLoanAmountValid(loanAmount);

            Assert.True(result);
        }
    }
}
