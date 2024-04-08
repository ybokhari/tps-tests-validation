using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class Calculator
    {
        public static int loanAmount { get; set; }
        public static int duration { get; set; }
        public static double nominalRate { get; set; }

        public Calculator(int loanAmount, int duration, double nominalRate)
        {
            Calculator.loanAmount = loanAmount;
            Calculator.duration = duration;
            Calculator.nominalRate = nominalRate;
        }

        public static double CalculateMonthlyPayment()
        {
            double monthlyRate = nominalRate / 12;
            if (monthlyRate == 0)
            {
                return Math.Round((double)loanAmount / duration, 2);
            }
            return Math.Round((loanAmount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -duration)), 2);
        }

        public static double CalculateTotalCost()
        {
            return Math.Round((CalculateMonthlyPayment() * duration) - loanAmount, 2);
        }

        public static IEnumerable<(int monthlyPaymentNumber, double capitalRepaid, double capitalOutstanding)> CalculateAmortizationTable()
        {
            double monthlyPayment = CalculateMonthlyPayment();
            double capitalOutstanding = loanAmount;
            for (int i = 1; i <= duration; i++)
            {
                double interest = capitalOutstanding * nominalRate / 12;
                double capitalRepaid = monthlyPayment - interest;
                capitalOutstanding -= capitalRepaid;
                yield return (i, capitalRepaid, capitalOutstanding);
            }
        }
    }
}
