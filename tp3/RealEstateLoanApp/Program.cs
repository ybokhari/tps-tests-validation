using RealEstateLoanApp;

class Program
{
    static void Main(string[] args)
    {
        Arguments arguments = new Arguments();
        (int, int, double) parameters = arguments.Parse(args);
        arguments.Validate(parameters);

        Calculator calculator = new Calculator();
        calculator.SetRealEstateLoanStrategy(new ConstantAmortization(parameters.Item1, parameters.Item2, parameters.Item3));
        calculator.SetFileGenerator(new CsvFileGenerator());
        calculator.CalculateRealEstateLoan();
    }
}