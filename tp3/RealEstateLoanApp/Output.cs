using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLoanApp
{
    public class Output
    {
        public void ShowSuccessMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File generated.");
            Console.ResetColor();
        }

        public void ShowErrorMessage(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + e.Message);
            Console.ResetColor();
        }

        public void simulateLoading()
        {
            Console.WriteLine("File generation progress...");
            Thread.Sleep(1000);
        }
    }
}
