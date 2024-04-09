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
        public static decimal nominalRate { get; set; }

        public static decimal CalculateMonthlyPayment()
        {
            decimal monthlyRate = nominalRate / 12;
            if (monthlyRate == 0)
            {
                return Math.Round((decimal)loanAmount / duration, 2);
            }
            return Math.Round((loanAmount * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -duration)), 2);
        }

        public static decimal CalculateTotalCost()
        {
            return Math.Round((CalculateMonthlyPayment() * duration) - loanAmount, 2);
        }

        public static IEnumerable<(int monthlyPaymentNumber, decimal capitalRepaid, decimal capitalOutstanding)> CalculateAmortizationTable()
        {
            decimal monthlyPayment = CalculateMonthlyPayment();
            decimal capitalOutstanding = loanAmount;
            for (int i = 1; i <= duration; i++)
            {
                decimal interest = Math.Round(capitalOutstanding * nominalRate / 12, 2);
                decimal capitalRepaid = i == duration ? capitalOutstanding : Math.Round(monthlyPayment - interest, 2);
                capitalOutstanding = Math.Round(capitalOutstanding - capitalRepaid, 2);
                yield return (i, capitalRepaid, capitalOutstanding);
            }
        }
    }
}
