using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public interface IFileGenerator
    {
        void GenerateFile(IAmortizationStrategy amortizationStrategy);
    }
}
