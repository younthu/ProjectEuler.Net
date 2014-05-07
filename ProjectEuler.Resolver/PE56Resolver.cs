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
    public class PE56Resolver
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[ ] sums = new int[10000];

            for (int i = 0; i < 10000; i++)
            {
                sums[i] = 0;
            }

            // Compute all sums
            for (int i = 0; i < 99; i++)
            {
                BigInteger power = i+1;
                for (int j = 0; j < 99; j++)
                {
                    sums[i * 100 + j] = power.DigitalSum();
                    power *= i + 1;
                }
            }

            int biggest = 0;
            for (int i = 0; i < 10000; i++)
            {
                if (biggest < sums[i])
                {
                    biggest = sums[i];
                }
            }
            Console.WriteLine(biggest);
        }
    }
}
