using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Resolver
{
    /// <summary>
    /// s' = 1 + 1/(1 + s)
    /// </summary>
    [TestClass]
    public class PE57Resolver
    {
        [TestMethod]
        public void PE57()
        {
            // assume n = 1 + 1/(1 + n0) = (1 + n0 + 1)/( 1 + n0) = (2n0d + n0n)/ (n0d + n0n)
            // nn = 2n0d +n0n = 2*(n0d+n0n) - n0n, nd=n0d+n0n
            BigInteger nn = 3, nd = 2;
            int count = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (nn.DigitalNumber() > nd.DigitalNumber())
                {
                    count++;
                }
                nd = nd + nn;
                nn = nd + nd - nn;
            }
            Console.WriteLine("The result is {0}. Last nn={1}, Last nd={2}", count,nn,nd);
        }
    }
}
