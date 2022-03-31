using System;
using System.Text.RegularExpressions;
using System.IO;

namespace week9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialization
            string input;
            string line;
            StreamReader sr;
            var pathChecker = new Regex(@"^[A-Z]:[\\/\w\s]+.\w+");
            // wordChecker isn't perfect, but it serves its function aight
            var wordChecker = new Regex(@"\w+");
            MatchCollection matches;

            // Input
            Console.WriteLine("Enter a file path: ");
            input = Console.ReadLine();

            // Calculations
            matches = wordChecker.Matches(input);
            if (pathChecker.IsMatch(input))
            {
                Console.WriteLine("File path is valid");
                try
                {
                    sr = new StreamReader(input);
                }
                catch
                {
                    Console.WriteLine("Unfortunately, that file does not exist");
                    Environment.Exit(2);
                }
            }
            else
            {
                Console.WriteLine("Not a valid file path!");
                Environment.Exit(1);
            }

            Console.WriteLine("Opening the file...");
            
            sr = new StreamReader(input);
            do
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
            } while (line != null);

            // Output
            Console.WriteLine("There are {0} words in the file", matches.Count);
        }
    }
}
