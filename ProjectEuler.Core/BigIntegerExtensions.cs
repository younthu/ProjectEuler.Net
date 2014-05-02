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
        public static bool IsPrime(this BigInteger bi) {
            if (bi < 2)
            {
                return false;
            }
            if (2 == bi)
            {
                return true;
            }

            for (BigInteger i = 3; i < bi / 2; i+=2) {
                if (0 == bi%i)
                {
                    return true;
                }
            }
            return false;
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

        #endregion
    }
}
