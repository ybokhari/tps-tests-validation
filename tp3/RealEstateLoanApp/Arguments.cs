using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class Arguments
    {
        public (int, int, decimal) Parse(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("The calculator accept only 3 parameters");
            }

            // Make the method work with both dot and comma as decimal separators
            args[2] = args[2].Replace('.', ',');
            if (!int.TryParse(args[0], out var loanAmount) ||
                !int.TryParse(args[1], out var duration) ||
                !decimal.TryParse(args[2], out var nominalRate))
            {
                throw new ArgumentException("The calculator accept only numbers");
            }

            // Convert nominal rate to percentage
            nominalRate = Math.Round(nominalRate / 100, 2);

            // Validate the arguments
            Validate((loanAmount, duration, nominalRate));

            return (loanAmount, duration, nominalRate);
        }

        public void Validate((int, int, decimal) arguments)
        {
            Validator validator = new Validator();

            if (!validator.IsLoanAmountValid(arguments.Item1))
            {
                throw new ArgumentException("The loan amount must be at least 50 000.");
            }
            if (!validator.IsDurationValid(arguments.Item2))
            {
                throw new ArgumentException("The duration must be between 108 and 300 months.");
            }
            if (!validator.IsNominalRateValid(arguments.Item3))
            {
                throw new ArgumentException("The nominal rate must be between 0 and 1.");
            }
        }
    }
}
