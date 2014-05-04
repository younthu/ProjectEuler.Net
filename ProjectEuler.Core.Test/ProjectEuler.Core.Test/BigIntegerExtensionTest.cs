using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Core.Test
{
    [TestClass]
    public class BigIntegerExtensionTest
    {
         [TestMethod]
        public void TestBigIntegerReverse() {
            Assert.AreEqual(0, (new BigInteger(0)).Reverse());
            Assert.AreEqual(1, (new BigInteger(1)).Reverse());
            Assert.AreEqual(21, (new BigInteger(12)).Reverse());
            Assert.AreEqual(321, (new BigInteger(123)).Reverse());
            Assert.AreEqual(-321, (new BigInteger(-123)).Reverse());
            Assert.AreEqual(101, (new BigInteger(101)).Reverse());
            Assert.AreEqual(123456789, (new BigInteger(987654321)).Reverse());
            Assert.AreEqual(-123456789, (new BigInteger(-987654321)).Reverse());
        }

         [TestMethod]
         public void IsPrimeTest() {

             for (BigInteger i = 0; i < 100000; i++)
             {
                 Assert.AreEqual(i.IsPrime(), i.IsPrime(false), String.Format("Failed at {0}",i));
             }
         }

         [TestMethod]
         public void IsPrimeWithBoost() {
             Boolean isPrime = false;
             for (BigInteger i = 0; i < 10000000; i++)
             {
                 isPrime = i.IsPrime();
             }
         }

         [TestMethod]
         public void IsPrimeWithNoBoost()
         {
             Boolean isPrime = false;
             for (BigInteger i = 0; i < 100000; i++)
             {
                 isPrime = i.IsPrime(false);
             }
         }

         #region ProjectEuler extensions tests

        [TestMethod]
         public void IsLychrel()
         {
             Assert.IsTrue(!(new BigInteger(47)).IsLychrel(50));
             Assert.IsTrue((new BigInteger(196)).IsLychrel(50));
             Assert.IsTrue((new BigInteger(10677)).IsLychrel(50));
             Assert.IsTrue(!(new BigInteger(10677)).IsLychrel(55));
             Assert.IsTrue((new BigInteger(4994)).IsLychrel(50));
         }
         #endregion
    }
}
