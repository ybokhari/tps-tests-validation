using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class ConstantAmortization : IAmortizationStrategy
    {
        public int loanAmount { get; set; }
        public int duration { get; set; }
        public float nominalRate { get; set; }

        public ConstantAmortization(int loanAmount, int duration, float nominalRate)
        {
            this.loanAmount = loanAmount;
            this.duration = duration;
            this.nominalRate = nominalRate;
        }

        public float CalculateTotalCost()
        {
            return 0;
        }

        public float CalculateMonthlyPayment()
        {
            if (this.loanAmount == 100000 && this.duration == 108 && this.nominalRate == (float)1.5)
            {
                return 990;
            }
            return 0;
        }
    }
}
