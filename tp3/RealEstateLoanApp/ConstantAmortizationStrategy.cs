using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class ConstantAmortizationStrategy : IRealEstateLoanStrategy
    {
        public void CalculateRealEstateLoan(int loanAmount, int duration, float nominalRate)
        {
            Console.WriteLine("CalculateRealEstateLoan");
        }
    }
}
