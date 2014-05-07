using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Resolver
{
    [TestClass]
    public class PE58Resolver
    {
        [TestMethod]
        public void PE58()
        {
            // start n = 1, sidelen=3, we have
            // n4 = (2n + 1)*(2n + 1) , this could not be a prime.
            // n3 = n4 - 2 * n
            // n2 = n3 - 2 * n
            // n1 = n2 - 2 * n
            // side = 2 * n + 1;

            BigInteger n = 1, sidelen = 3, n4 = 9, n3 = 7, n2=5, n1=3, primeCount = 0;
            for (; n < 10000000000; n++)
            {
                sidelen = 2 * n + 1;
                n4 = sidelen * sidelen;
                n3 = n4 - sidelen + 1;
                n2 = n3 - sidelen + 1;
                n1 = n2 - sidelen + 1;

                if (n1.IsPrime())
                {
                    primeCount++;
                }
                if (n2.IsPrime())
                {
                    primeCount++;
                }
                if (n3.IsPrime())
                {
                    primeCount++;
                }
                if (primeCount * 10 < n * 4 + 1 )// n4 is equal to the total count of numbers in the matrix
                {
                    Console.WriteLine("We get the answer {0}", sidelen);
                    break;
                }

            }
        }
    }
}
