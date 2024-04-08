using RealEstateLoanApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Arguments arguments = new Arguments();
            (int, int, double) parameters = arguments.Parse(args);
            Calculator(parameters.Item1, parameters.Item2, parameters.Item3);
            using TextWriter writer = new StreamWriter("MyRealEstateLoan.csv");
            CsvFileGenerator csvFileGenerator = new(writer);
            Console.WriteLine("The file MyRealEstateLoan.csv has been created successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}