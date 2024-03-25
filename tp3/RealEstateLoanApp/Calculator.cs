using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class Calculator
    {
        private IAmortizationStrategy _amortizationStrategy;
        private IFileGenerator _fileGenerator;

        public void SetRealEstateLoanStrategy(IAmortizationStrategy amortizationStrategy)
        {
            this._amortizationStrategy = amortizationStrategy;
        }

        public void SetFileGenerator(IFileGenerator fileGenerator)
        {
            this._fileGenerator = fileGenerator;
        }

        public void CalculateRealEstateLoan()
        {
            Console.WriteLine("File generation in progress...");

            try
            {
                _fileGenerator.GenerateFile(_amortizationStrategy);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File generated.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
                return;
            }
        }
    }
}
