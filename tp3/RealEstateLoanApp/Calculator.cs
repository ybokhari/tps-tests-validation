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

        public Calculator()
        { }

        public void SetRealEstateLoanStrategy(IAmortizationStrategy amortizationStrategy)
        {
            this._amortizationStrategy = amortizationStrategy;
        }

        public void CalculateRealEstateLoan(int loanAmount, int duration, float nominalRate)
        {
            /*
            numero_mensualite ++
            capital_rembourse = capital_rembourse + mensualite (au depart = 0)
            capital_restant = capital_restant - mensualite (au depart = montant du prêt)

            méthodes :
            - calculer le montant de la mensualité
            - calculer le coût total du crédit
             */
        }
    }
}
