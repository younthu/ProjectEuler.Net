using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Core;

namespace ProjectEuler.Core.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PEMathTest
    {
        public PEMathTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PrimeNumbersInRangeTest()
        {
            BigInteger sum = 0;
            List<BigInteger> pris = new List<BigInteger>();
            foreach (BigInteger prime in PEMath.PrimeNumbersInRange(1,100))
            {
                sum += prime;
                pris.Add(prime);
            }
            BigInteger[] primes = { 2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97};
            BigInteger expectedSum = 0;
            foreach (BigInteger item in primes)
            {
                expectedSum += item;
            }
            Assert.AreEqual(expectedSum, sum);
            Console.WriteLine(pris.Count);
            Console.WriteLine(primes.Count());
        }

       
    }
}
