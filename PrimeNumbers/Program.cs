using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumberGenerator primeNumberGenerator = new PrimeNumberGenerator();
            bool readyToExit = false;

            Console.WriteLine("Good morning and welcome....");
            Console.WriteLine("This application will display a prime number multiplication table based on a number of your choosing.");
                
            do
            {
                Console.WriteLine("Please enter a whole number between 1 and 50...");
                Console.WriteLine("(or if you want to exit, enter 0)");
                int userInput = primeNumberGenerator.ValidateUserInput(Console.ReadLine());

                if (userInput == 0)
                {
                    readyToExit = true;
                }
                else if (userInput > 0)
                {
                    List<int> primes = primeNumberGenerator.GeneratePrimeNumbers(userInput);
                    List<string> displayStrings = primeNumberGenerator.GenerateConsoleDisplay(primes);

                    Console.WriteLine("");
                    foreach (string row in displayStrings)
                    {
                        Console.WriteLine(row);
                    }
                    Console.WriteLine("");
                }

            } while (!readyToExit);
        }
    }
}
