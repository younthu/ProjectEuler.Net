using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Diagnostics;

namespace ProjectEuler.Core
{
    public static class BigIntegerExtensions
    {
        private static bool[] primePrecompute;

        static BigIntegerExtensions() {
            primePrecompute = new bool[100000];
            for (int i = 0; i < 100000; i++)
            {
                bool isPrime = true;
                int value = i * 2 + 3;

                for (int div = 3; div <= Math.Sqrt(value); div+=2)
                {
                    if (value % div == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                primePrecompute[i] = isPrime;
            }
        }
        public static bool IsPrime(this BigInteger bi, bool boostUp = true) {
            if (bi < 2)
            {
                return false;
            }
            if (2 == bi)
            {
                return true;
            }
            if (0 == bi % 2)
            {
                return false;
            }

            // For number under 100,000, speed up by looking up for static map
            if (boostUp && bi < primePrecompute.Length)
            {
                int index = (int)bi;
                return primePrecompute[(index >> 1) - 1];
            }

            if (boostUp &&
                (bi < ((Int64)primePrecompute.Length)*((Int64)primePrecompute.Length))
                ) // boost Way
            {
                Int64 bi64 = (Int64)bi;
                Double sqrt = Math.Sqrt(bi64);
                for (int i = 0, div = 3; div <= sqrt + 1; i++, div+=2)// for security, compute one more element after sqrt.
                {
                    if (primePrecompute[i] && (bi % div == 0))
                    {
                        return false;
                    }
                }
            }
            else // normal way
            {
                for (BigInteger i = 3; i < bi / 2; i += 2)
                {
                    if (0 == bi % i)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 回文数判断
        /// </summary>
        /// <param name="bi"></param>
        /// <returns></returns>
        public static bool IsPalindrome(this BigInteger bi) {
            return bi == bi.Reverse();
        }

        /// <summary>
        /// 翻转该数
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static BigInteger Reverse(this BigInteger origin)
        {
            BigInteger reversed = 0;
            BigInteger remain = origin;

            while (remain != 0)
            {
                reversed *= 10;
                reversed += remain % 10;
                remain /= 10;
            }
            return reversed;
        }

        /// <summary>
        /// Join two big integers like strings
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BigInteger Concatenate(this BigInteger left, BigInteger right) {
            if (right < 0)
            {
                right = -right;
            }

            int digitNum = right.DigitalNumber();
            left *= BigInteger.Pow(10, digitNum);
            if (left < 0)
            {
                return -(-left + right);
            }
            return left + right;
        }

        public static IEnumerable<BigInteger> Transform(this BigInteger origin, ITransformer transformer) {
            throw new NotImplementedException();
        }

        #region ProjectEuler related functions
        /// <summary>
        /// Problem 55
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="maxTries"></param>
        /// <returns></returns>
        public static bool IsLychrel(this BigInteger origin, int maxTries)
        {
            if (maxTries == 0)// for maxTries < 0, we will thought it to be unlimited search.
            {
                return !origin.IsPalindrome();
            }
            BigInteger next = origin + origin.Reverse();
            if (next.IsPalindrome())
            {
                return false;
            }
            return next.IsLychrel(--maxTries);
        }

        public static Int32 DigitalSum(this BigInteger value) {
            if (value < 0)
            {
                value = -value;
            }

            Int32 sum = 0;

            while (value > 0)
            {
                sum += (int)(value % 10);
                value /= 10;
            }
            return sum;
        }

        public static Int32 DigitalNumber(this BigInteger value) {
            if (value < 0)
            {
                value = -value;
            }
            if (value < 10)
            {
                return 1;
            }

            int result = 0;
            while (value > 0)
            {
                result++;
                value /= 10;
            }

            return result;
        }
        #endregion
    }
}
