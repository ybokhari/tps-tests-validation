using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class FileGeneratorFactory
    {
        public IFileGenerator CreateFileGenerator(string fileType, IAmortizationStrategy amortizationStrategy)
        {
            switch (fileType)
            {
                case "csv":
                    return new CsvFileGenerator(amortizationStrategy);
                default:
                    throw new Exception("Invalid file type");
            }
        }
    }
}
