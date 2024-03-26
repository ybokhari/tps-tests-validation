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
        private Output _output;

        public Calculator(IAmortizationStrategy amortizationStrategy, IFileGenerator fileGenerator, Output output)
        {
            _amortizationStrategy = amortizationStrategy;
            _fileGenerator = fileGenerator;
            _output = output;
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
            _output.simulateLoading();

            try
            {
                _fileGenerator.GenerateFile(_amortizationStrategy);

                _output.ShowSuccessMessage();
            }
            catch (Exception e)
            {
                _output.ShowErrorMessage(e);
                return;
            }
        }
    }
}
