using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    internal class Calculator
    {
        private IRealEstateLoanStrategy _realEstateLoanStrategy;

        public Calculator()
        { }

        public void SetRealEstateLoanStrategy(IRealEstateLoanStrategy realEstateLoanStrategy)
        {
            this._realEstateLoanStrategy = realEstateLoanStrategy;
        }

        public void CalculateRealEstateLoan(int loanAmount, int duration, float nominalRate)
        {
            this._realEstateLoanStrategy.CalculateRealEstateLoan(loanAmount, duration, nominalRate);
        }
    }
}
