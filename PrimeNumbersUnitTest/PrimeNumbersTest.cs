using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using PrimeNumbers;


namespace PrimeNumbersUnitTest
{
    /// <summary>
    /// Class used by NUnit to test the PrimeNumberGenerator class
    /// </summary>
    [TestFixture]
    public class PrimeNumbersTest
    {
        #region Member Variables
        public PrimeNumberGenerator primeNumberGenerator;
        int[] validationPrimes = new int[50]{ 2,3,5,7,11,13,17,19,23,29,
                                              31,37,41,43,47,53,59,61,67,71,
                                              73,79,83,89,97,101,103,107,109,113,
                                              127,131,137,139,149,151,157,163,167,173,
                                              179,181,191,193,197,199,211,223,227,229};
        #endregion

        #region SetUp and TearDown
        /// <summary>
        /// Test setup procedure for class.
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            primeNumberGenerator = new PrimeNumberGenerator();
        }

        /// <summary>
        /// Tear down procedure for the class.
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
           
        }

        [SetUp]
        public void TestSetup()
        {
        }

        [TearDown]
        public void TestTearDown()
        {
        }
        #endregion SetUp and TearDown

        #region NUnit Tests

        #region User Input Tests
        /// <summary>
        /// Tests that a value less than 0 returns false
        /// </summary>
        [Test]
        public void T01_UserInputLess0()
        {
            Assert.AreEqual(-1, primeNumberGenerator.ValidateUserInput("-1"));
        }

        /// <summary>
        /// Tests that a value greater than 50 returns false
        /// </summary>
        [Test]
        public void T02_UserInputGreater50()
        {
            Assert.AreEqual(-1, primeNumberGenerator.ValidateUserInput("51"));
        }

        /// <summary>
        /// Tests that a non-numerical input returns false
        /// </summary>
        [Test]
        public void T03_UserInputText()
        {
            Assert.AreEqual(-1, primeNumberGenerator.ValidateUserInput("morning"));
        }

        /// <summary>
        /// Tests that a non-numerical input returns false
        /// </summary>
        [Test]
        public void T04_UserInputGreaterThanInt()
        {
            Assert.AreEqual(-1, primeNumberGenerator.ValidateUserInput("38848858577673"));
        }

        /// <summary>
        /// Tests that 0 returns true
        /// </summary>
        [Test]
        public void T05_UserInputIs0()
        {
            Assert.AreEqual(0, primeNumberGenerator.ValidateUserInput("0"));
        }
        #endregion

        #region Prime Generation Tests
        /// <summary>
        /// Tests getting a list of prime numbers based on a selection of valid values between 1 and 50
        /// </summary>
        [Test]
        public void T06_GeneratePrimes()
        {
            List<int> results = primeNumberGenerator.GeneratePrimeNumbers(1);
            Assert.AreEqual(1, results.Count);
        
            for (int i=0; i < results.Count; i++)
            {
                Assert.AreEqual(validationPrimes[i], results[i]);
            }

            results = primeNumberGenerator.GeneratePrimeNumbers(8);
            Assert.AreEqual(8, results.Count);

            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual(validationPrimes[i], results[i]);
            }

            results = primeNumberGenerator.GeneratePrimeNumbers(50);
            Assert.AreEqual(50, results.Count);

            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual(validationPrimes[i], results[i]);
            }
        }

        /// <summary>
        /// Tests that entering a value below 1 will return an empty list
        /// </summary>
        [Test]
        public void T07_GeneratePrimesInvalidInput()
        {
            List<int> results = primeNumberGenerator.GeneratePrimeNumbers(0);
            Assert.AreEqual(0, results.Count);

            results = primeNumberGenerator.GeneratePrimeNumbers(-1);
            Assert.AreEqual(0, results.Count);
        }
        #endregion
                
        #region Display Tests
        /// <summary>
        /// Tests getting a list of prime numbers based on a selection of valid values between 1 and 50
        /// </summary>
        [Test]
        public void T08_DisplayTableForN1()
        {
            List<int> results = primeNumberGenerator.GeneratePrimeNumbers(1);
            List<string> displayStrings = primeNumberGenerator.GenerateConsoleDisplay(results);
            Assert.AreEqual(2, displayStrings.Count);

            foreach (string row in displayStrings)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Tests that entering a value below 1 will return an empty list
        /// </summary>
        [Test]
        public void T09_DisplayTableForNRandom()
        {
            Random randomNumberGenerator = new Random();
            int randomPrimes = randomNumberGenerator.Next(1, 50);
            List<int> results = primeNumberGenerator.GeneratePrimeNumbers(randomPrimes);
            List<string> displayStrings = primeNumberGenerator.GenerateConsoleDisplay(results);
            Assert.AreEqual(randomPrimes+1, displayStrings.Count);

            foreach (string row in displayStrings)
            {
                Console.WriteLine(row);
            }
        }
        #endregion
        
        #endregion
    }
}
