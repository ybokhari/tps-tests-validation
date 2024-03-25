using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanTests
{
    internal class ArgumentsTests
    {
        [Theory]
        [InlineData("50000", "108", "0.012")]
        [InlineData("100000", "108", "0.015")]
        [InlineData("200000", "180", "0.032")]
        public void ParseTest(string loanAmount, string duration, string nominalRate)
        {
            string[] args = new string[] { loanAmount, duration, nominalRate };

            var result = Arguments.Parse(args);

            Assert.AreEqual(100000, result.LoanAmount);
            Assert.AreEqual(240, result.Duration);
            Assert.AreEqual(0.03, result.NominalRate);
        }
    }
}
