using RealEstateLoanApp;

class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();

        calculator.SetRealEstateLoanStrategy(new ConstantAmortizationStrategy());
        calculator.CalculateRealEstateLoan(1, 2, (float)1.5);
    }
}