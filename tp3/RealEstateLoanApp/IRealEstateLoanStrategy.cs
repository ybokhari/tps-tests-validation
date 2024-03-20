using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RealEstateLoanApp
{
    internal interface IRealEstateLoanStrategy
    {
        void CalculateRealEstateLoan(int loanAmount, int duration, float nominalRate);
    }
}
