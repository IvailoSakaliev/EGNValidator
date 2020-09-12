using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckEGN
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckEGN();
            
        }

        private static void CheckEGN()
        {
            Console.WriteLine("Please enter EGN of persone: ");
            string eng = Console.ReadLine();
            if (ValidateEGN(eng))
            {
                CheckAlgo model = new CheckAlgo(eng);
                if (model.EGN())
                {
                    Console.WriteLine("The EGN:{0} is valid!", eng);
                }
                else
                {
                    Console.WriteLine("The EGN:{0} is not valid!", eng);
                }
            }
            Console.WriteLine("Please press enter to continue or any another button for exit");
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                CheckEGN();
            }
        }
        
        private static bool ValidateEGN(string eng)
        {
            if (eng.Length == 10)
            {
                Regex regex = new Regex(@"^\d+$");
                if (regex.IsMatch(eng))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
