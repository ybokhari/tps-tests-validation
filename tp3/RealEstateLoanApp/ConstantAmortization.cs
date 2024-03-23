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
        public double nominalRate { get; set; }

        public ConstantAmortization(int loanAmount, int duration, double nominalRate)
        {
            this.loanAmount = loanAmount;
            this.duration = duration;
            this.nominalRate = nominalRate;
        }

        public double CalculateMonthlyPayment()
        {
            double monthlyRate = nominalRate / 12;
            double numerator = loanAmount * monthlyRate;
            double denominator = (1 - Math.Pow(1 + monthlyRate, -duration));
            return Math.Round(numerator / denominator, 2);
        }

        public double CalculateTotalCost()
        {
            return Math.Round(CalculateMonthlyPayment() * duration, 2);
        }
    }
}
