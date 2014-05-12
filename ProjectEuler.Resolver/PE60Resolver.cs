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
    /// Assume the five primes are under 100,000
    /// Check all possible combinations
    /// </summary>
    [TestClass]
    public class PE60Resolver
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Get all primes under 100,000
            List<BigInteger> primes = new List<BigInteger>();

            for (int i = 0; i < 10000; i++)
            {
                BigInteger bi = i;
                if (bi.IsPrime())
                {
                    primes.Add(i);
                }
            }
            BigInteger result = Int32.MaxValue;
            bool found = false;
            for (int p1 = 0; p1 < primes.Count; p1++)
            {
                if (found) break;
                for (int p2 = p1 + 1; p2 < primes.Count; p2++)
                {
                    if (found) break;
                    BigInteger p1p2 = BigIntegerExtensions.Concatenate(primes[p1], primes[p2]);
                    if (!p1p2.IsPrime())
                    {
                        continue;
                    }
                    BigInteger p2p1 = BigIntegerExtensions.Concatenate(primes[p2], primes[p1]);
                    if (!p2p1.IsPrime())
                    {
                        continue;
                    }
                    for (int p3 = p2 + 1; p3 < primes.Count; p3++)
                    {
                        if (found) break;
                        BigInteger p1p3 = BigIntegerExtensions.Concatenate(primes[p1], primes[p3]);
                        if (!p1p3.IsPrime())
                        {
                            continue;
                        }
                        BigInteger p3p1 = BigIntegerExtensions.Concatenate(primes[p3], primes[p1]);
                        if (!p3p1.IsPrime())
                        {
                            continue;
                        }
                        BigInteger p2p3 = BigIntegerExtensions.Concatenate(primes[p2], primes[p3]);
                        if (!p2p3.IsPrime())
                        {
                            continue;
                        }
                        BigInteger p3p2 = BigIntegerExtensions.Concatenate(primes[p3], primes[p2]);
                        if (!p3p2.IsPrime())
                        {
                            continue;
                        }

                        for (int p4 = p3+1; p4 < primes.Count; p4++)
                        {
                            if (found) break;
                            BigInteger p1p4 = BigIntegerExtensions.Concatenate(primes[p1], primes[p4]);
                            if (!p1p4.IsPrime())
                            {
                                continue;
                            }
                            BigInteger p4p1 = BigIntegerExtensions.Concatenate(primes[p4], primes[p1]);
                            if (!p4p1.IsPrime())
                            {
                                continue;
                            }
                            BigInteger p2p4 = BigIntegerExtensions.Concatenate(primes[p2], primes[p4]);
                            if (!p2p4.IsPrime())
                            {
                                continue;
                            }
                            BigInteger p4p2 = BigIntegerExtensions.Concatenate(primes[p4], primes[p2]);
                            if (!p4p2.IsPrime())
                            {
                                continue;
                            }
                            BigInteger p3p4 = BigIntegerExtensions.Concatenate(primes[p3], primes[p4]);
                            if (!p3p4.IsPrime())
                            {
                                continue;
                            }
                            BigInteger p4p3 = BigIntegerExtensions.Concatenate(primes[p4], primes[p3]);
                            if (!p4p3.IsPrime())
                            {
                                continue;
                            }



                            for (int p5 = p4 + 1; p5 < primes.Count; p5++)
                            {
                                if (found) break;
                                BigInteger p1p5 = BigIntegerExtensions.Concatenate(primes[p1], primes[p5]);
                                if (!p1p5.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p5p1 = BigIntegerExtensions.Concatenate(primes[p5], primes[p1]);
                                if (!p5p1.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p2p5 = BigIntegerExtensions.Concatenate(primes[p2], primes[p5]);
                                if (!p2p5.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p5p2 = BigIntegerExtensions.Concatenate(primes[p5], primes[p2]);
                                if (!p5p2.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p3p5 = BigIntegerExtensions.Concatenate(primes[p3], primes[p5]);
                                if (!p3p5.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p5p3 = BigIntegerExtensions.Concatenate(primes[p5], primes[p3]);
                                if (!p5p3.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p4p5 = BigIntegerExtensions.Concatenate(primes[p4], primes[p5]);
                                if (!p4p5.IsPrime())
                                {
                                    continue;
                                }
                                BigInteger p5p4 = BigIntegerExtensions.Concatenate(primes[p5],primes[p4]);
                                if (!p5p4.IsPrime())
                                {
                                    continue;
                                }

                                BigInteger sum = primes[p1] + primes[p2] + primes[p3] + primes[p4]+ primes[p5];
                                if (sum < result)
                                {
                                    result = sum;
                                    Console.WriteLine("{0}+{1}+{2}+{3}+{4}={5}", primes[p1], primes[p2], primes[p3], primes[p4], primes[p5], sum);
                                    found = true;
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
