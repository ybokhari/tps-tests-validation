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

        public Calculator(IAmortizationStrategy amortizationStrategy, IFileGenerator fileGenerator)
        {
            _amortizationStrategy = amortizationStrategy;
            _fileGenerator = fileGenerator;
        }

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
            _fileGenerator.GenerateFile("MyRealEstateLoan.csv");
        }
    }
}
