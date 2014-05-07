using ProjectEuler.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Core.Test
{
    
    
    /// <summary>
    ///This is a test class for DigitsReplacementTransformerTest and is intended
    ///to contain all DigitsReplacementTransformerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DigitsReplacementTransformerTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAllTransformersForInteger
        ///</summary>
        [TestMethod()]
        public void GetAllTransformersForIntegerTest()
        {
            //DigitsReplacementTransformer target = new DigitsReplacementTransformer(); // TODO: Initialize to an appropriate value
            //BigInteger value = new BigInteger(100); // TODO: Initialize to an appropriate value
            //IEnumerable<DigitsReplacementTransformer> expected = null; // TODO: Initialize to an appropriate value
            //IEnumerable<DigitsReplacementTransformer> actual;
            //actual = DigitsReplacementTransformer.GetAllTransformersForInteger(value);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
            var result = DigitsReplacementTransformer.GetAllTransformersForInteger(123).ToArray();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod()]
        public void TransformToSmallestTest()
        {
            DigitsReplacementTransformer tran = new DigitsReplacementTransformer(new BigInteger[]{10,1000});
            BigInteger target = new BigInteger(12345678);
            Assert.AreEqual(12340608, tran.TransformToSmallest(target));

        }

        [TestMethod()]
        public void TransformIntegerTest() {

            DigitsReplacementTransformer tran = new DigitsReplacementTransformer(new BigInteger[] { 10, 1000 });
            BigInteger target = new BigInteger(12345678);

            foreach (BigInteger item in tran.TransformInteger(target))
            {
                Console.WriteLine(item);
            }
        }
    }
}
