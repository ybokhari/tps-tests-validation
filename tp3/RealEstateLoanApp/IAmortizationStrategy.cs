using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RealEstateLoanApp
{
    internal interface IAmortizationStrategy
    {
        int loanAmount { get; set; }
        int duration { get; set; }
        float nominalRate { get; set; }

        float CalculateTotalCost();

        float CalculateMonthlyPayment();
    }
}
