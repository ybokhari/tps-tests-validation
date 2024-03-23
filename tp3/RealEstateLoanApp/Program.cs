using RealEstateLoanApp;

class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();
        int loanAmount = 1;
        int duration = 1;
        float nominalRate = 1;

        calculator.SetRealEstateLoanStrategy(new ConstantAmortization(loanAmount, duration, nominalRate));
        calculator.CalculateRealEstateLoan(1, 2, (float)1.5);
    }
}