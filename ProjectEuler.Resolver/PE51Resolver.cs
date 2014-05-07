using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Resolver
{
    using System.Diagnostics;

    /// <summary>
    /*  By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values:
     * 13, 23, 43, 53, 73, and 83, are all primes
     * By replacing the 3rd and 4th digits of 56**3 with the same digit, 
     * this 5-digit number is the first example having seven primes among the ten generated numbers,
     * yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, 
     * being the first member of this family, is the smallest prime with this property.
     * Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit,
     * is part of an eight prime value family.
    */

    /***************** Solution
     *  Given that the answer is below 1000,000, we do believe:
     *  1, The last digit of that number could not be replaced, because the by replacing the last digit, 
     *     we will get 5 odd numbers at least, to get 8 primes we need 8 odds at least.
     *  
     * 2,Should have 2 digits been replaced at least, otherwise, there should be 3 numbers can be divided by 3 at least. 
     * 0,1,2,3,4,5,6,7,8,9, considering the sum of all digits divided by 3, 3 numbers not work at least
     * 
     *  3,The step should not be 11,
     *  0,11(2),22(1),33(0),44(2),55(1),66(0),77(2),88(1),99(0), with the same analysis as in step 2, 11 won't work.
     *  
     * 4, The step should not be 101,
     * 0, 101(2), 202(1), 303(0), 404(2), 505(1), 606(0), 707(2), 808(1), 909(0)
     * 
     * 5, The step can be 111
     * 0, 111(0),222(0),333(0),444(0),555(0),666(0),777(0),888(0),999(0)
     * 
     * 6, The step can be 1001(No),1011(Yes),1101(Y),1111(N),10001(N),10011(Y),10101(Y),11001(Y)
     * 
     * Above all, we can constrict step in range below:
     * [1110,
     * 10110,11010,11100,
     * 100110,101100,110100,111000]
     *  
     * Let's try to find it under 1000000
     */
    /// </summary>
    [TestClass]
    public class PE51Resolver
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigInteger result = Int64.MaxValue;
            int nonPrimeCount = 0;

            bool leadingZero = true;
            for (int d8 = 0; d8 < 10; d8++)
            {
                leadingZero = (0 == d8);
                int step8 = 0 == d8 ? 10000000:0;

                for (int d7 = 0; d7 < 10; d7++)
                {
                    leadingZero = (0 == d8) && (0 == d7);
                    int z7 = leadingZero? 0:( 0==d7 ? 1:0 );
                    int step7 = 0 == d7? 1000000:0;
                    
                    for (int d6 = 0; d6 < 10; d6++)
                    {
                        leadingZero = (0 == d8) && (0 == d7) && (0 == d6);
                        int z6 = leadingZero? 0:(0==d6? z7 + 1: z7);
                        int step6 = 0 == d6? 100000:0;

                        for (int d5 = 0; d5 < 10; d5++)
                        {
                            leadingZero = (0 == d8) && (0 == d7) && (0 == d6) && (0 == d5) ;
                            int z5 = leadingZero ? 0 : (0 == d5 ? z6 + 1 : z6);
                            int step5 = 0 == d5? 10000:0;

                            if (leadingZero)
                            {
                                break;
                            }

                            for (int d4 = 0; d4 < 10; d4++)
                            {
                                if (0 != d4  && 0 == z5)// there is no enough digits to form three digits
                                {
                                    break;
                                }
                                int z4 = 0 == d4 ? z5 + 1: z5;
                                int step4 = 0 == d4? 1000:0;

                                for (int d3 = 0; d3 < 10; d3++)
                                {
                                    if (0 != d3 && 1 >= z4) // we need 3 empty digits at least
                                    {
                                        break;
                                    }
                                    int step3 = 0 == d3? 100:0;
                                    int z3 = 0 == d3 ? z4 + 1 : z4;
                                    for (int d2 = 0; d2 < 10; d2++)
                                    {
                                        if (0 != d2 && 2 >= z3)
                                        {
                                            break;
                                        }
                                        int step2 = 0 == d2? 10:0;
                                        int step = step2 + step3 + step4 + step5 + step6 + step7 + step8;
                                        int v = d2 * 10 + d3 * 100 + d4 * 1000 + d5 * 10000 + d6 * 100000 + d7 * 1000000 + d8 * 10000000;
                                        if (v > result)
                                        {
                                            break;
                                        }
                                        for (int d1 = 1; d1 < 10; d1+=2)
                                        {
                                            // get step
                                            int value = d1 + v;
                                             nonPrimeCount = 0;
                                             int smallestPrime = int.MaxValue;
                                            for (int i = 0; i < 10; i++)
                                            {
                                                value += step;
                                                BigInteger bi = value;

                                                if (!bi.IsPrime() )
                                                {
                                                    nonPrimeCount++;
                                                    if (3<=nonPrimeCount)
                                                    {
                                                        break;   
                                                    }
                                                }
                                                else
                                                {
                                                    if (smallestPrime > value)
                                                    {
                                                        smallestPrime = value;
                                                    }
                                                }
                                            }

                                            if (nonPrimeCount < 3 && result > smallestPrime)
                                            {
                                                result = smallestPrime;
                                                Console.WriteLine(result);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
