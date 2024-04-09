using RealEstateLoanApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Arguments arguments = new Arguments();
            (int, int, decimal) parameters = arguments.Parse(args);
            Calculator.loanAmount = parameters.Item1;
            Calculator.duration = parameters.Item2;
            Calculator.nominalRate = parameters.Item3;
            using TextWriter writer = new StreamWriter("MyRealEstateLoan.csv");
            CsvFileGenerator csvFileGenerator = new(writer);
            csvFileGenerator.GenerateFile();
            Console.WriteLine("The file MyRealEstateLoan.csv has been created successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}