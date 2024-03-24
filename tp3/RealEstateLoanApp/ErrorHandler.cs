using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class ErrorHandler
    {
        public bool IsLoanAmountValid(int loanAmount)
        {
            if (loanAmount < 50000)
            {
                return false;
            }
            return true;
        }

        public bool IsDurationValid(int duration)
        {
            if (duration < 108 || duration > 300)
            {
                return false;
            }
            return true;
        }
    }
}
