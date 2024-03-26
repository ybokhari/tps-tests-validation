using RealEstateLoanApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanTests
{
    public class ArgumentsTests
    {
        private Arguments arguments;

        public ArgumentsTests()
        {
            arguments = new Arguments();
        }

        [Theory]
        [InlineData("50000", "108", "0.012")]
        [InlineData("200000", "180", "0,032")]
        public void ParseTest(string loanAmount, string duration, string nominalRate)
        {
            string[] args = new string[] { loanAmount, duration, nominalRate };

            var result = Record.Exception(() => arguments.Parse(args));

            Assert.Null(result);
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("50000", "", "")]
        [InlineData("50000", "108", "")]
        public void ParseTest_Only3Parameters(string loanAmount, string duration, string nominalRate)
        {
            string[] args = new string[] { loanAmount, duration, nominalRate };
            args = args.Where(arg => !string.IsNullOrEmpty(arg)).ToArray(); // Filter empty strings
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The calculator accept only 3 parameters";

            var result = Record.Exception(() => arguments.Parse(args));

            Assert.NotNull(result);
            Assert.IsType(exceptionType, result);
            Assert.Equal(expectedMessage, result.Message);
        }

        [Theory]
        [InlineData("", "108", "0.012")]
        [InlineData("50000", "", "0.012")]
        [InlineData("50000", "108", "")]
        [InlineData("50000", "108,0", "0.012")]
        [InlineData("50000,56", "108", "0.012")]
        [InlineData("Hello world!", "108", "0.012")]
        [InlineData("50000", "Hello world!", "0.012")]
        [InlineData("50000", "108", "Hello world!")]
        public void ParseTest_OnlyNumbers(string loanAmount, string duration, string nominalRate)
        {
            string[] args = new string[] { loanAmount, duration, nominalRate };
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The calculator accept only numbers";

            var result = Record.Exception(() => arguments.Parse(args));

            Assert.NotNull(result);
            Assert.IsType(exceptionType, result);
            Assert.Equal(expectedMessage, result.Message);
        }
    }
}
