using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeNumbers
{
    /// <summary>
    /// this class takes a users input and creates a multiplication table based on prime numbers
    /// </summary>
    public class PrimeNumberGenerator
    {
        #region Member Variables
        #endregion

        public PrimeNumberGenerator()
        {
        }

        #region Public Methods
        /// <summary>
        /// Validates that the data entered by the user is a whole number greater than or equal to zero
        /// </summary>
        /// <remarks>If the returned value is -1, then the data entered by the user is either text, a ngeative number or an exeption occured. 
        /// Otherwise an integer between 1 and 50 will be returned.</remarks>
        /// <param name="userInput">user input from the console</param>
        /// <returns>the number of primes to find</returns>
        public int ValidateUserInput(string userInput)
        {
            int numberofPrimes = -1;
            try
            {
                int userNumber = Convert.ToInt32(userInput);
                // setting the max number of primes to calculate for first out to 50
                // gives enough data to validate algorithm without overloading console app
                if (userNumber >= 0 && userNumber <= 50)
                {
                    numberofPrimes = userNumber;
                }
                else
                {
                    Console.WriteLine("The value entered is outwith the accepted integer range");
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("The value entered was not an integer");
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("The value entered is outwith the accepted integer range");
            }
            return numberofPrimes;
        }

        /// <summary>
        /// Generates the first N prime numbers
        /// </summary>
        /// <returns>a list of prime numbers</returns>
        public List<int> GeneratePrimeNumbers(int primesToFind)
        {
            List<int> primeNumbers = new List<int>();
            
            if (primesToFind > 0)
            {
                //first prime number is 2 and it is the only even prime number
                primeNumbers.Add(2);

                int nextPossiblePrime = 3;
                while (primeNumbers.Count < primesToFind)
                {
                    int sqrt = (int)Math.Sqrt(nextPossiblePrime);

                    bool isPrimeNumber = true;
                    //only a prime number if not divisible by any of the primes found so far up to the square root of the test number 
                    for (int i = 0; i < primeNumbers.Count && primeNumbers[i] <= sqrt; ++i)
                    {
                        if (nextPossiblePrime % primeNumbers[i] == 0)
                        {
                            isPrimeNumber = false;
                            break;
                        }
                    }

                    if (isPrimeNumber)
                    {
                        primeNumbers.Add(nextPossiblePrime);
                    }

                    nextPossiblePrime += 2;
                }
            }

            return primeNumbers;
        }

        /// <summary>
        /// Generates a list of table rows that can be displayed by the console applciation
        /// </summary>
        /// <param name="primeNumbers">a list of prime numbers</param>
        /// <returns>a list of table rows</returns>
        public List<string> GenerateConsoleDisplay(List<int> primeNumbers)
        {
            // setup the max width of the table so that we can dynamically alter column width depending on the size of the number
            int maxColumnWidth = (primeNumbers.Max() * primeNumbers.Max()).ToString().Length + 1;
            int numberofRows = primeNumbers.Count + 1;
            
            List<string> displayStrings = new List<string>();
            
            for (int row = 0; row< numberofRows; row ++)
            { 
                List<string> rowData = new List<string>();
                if (row == 0)
                {
                    rowData.Add("");
                    foreach (int number in primeNumbers)
                    {
                        rowData.Add(number.ToString());
                    }
                }
                else
                {
                    rowData.Add(primeNumbers.ElementAt(row-1).ToString());
                    foreach (int number in primeNumbers)
                    {
                        rowData.Add((number * primeNumbers.ElementAt(row-1)).ToString());
                    }
                }
                
                displayStrings.Add(FormatRow(rowData, maxColumnWidth));
            }
            return displayStrings;
        }
        #endregion

        #region Private Members
        private string FormatRow(List<string> columns, int maxWidth)
        {
            StringBuilder output = new StringBuilder("|");
            foreach (string column in columns)
            {
                output.Append(column.PadLeft(maxWidth));
                output.Append(" |");
            }
            return output.ToString();
        }
        #endregion
    }
}
