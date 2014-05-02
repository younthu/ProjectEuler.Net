using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using MathNet.Numerics;

namespace ProjectEuler.Core
{
    using System.Diagnostics;

    public class PEMath
    {
        public bool IsPrime(Int64 value) {
            BigInteger i = new BigInteger(value);
            
            throw new NotImplementedException();
        }

        public static IEnumerable<BigInteger> PrimeNumbersInRange(BigInteger start, BigInteger end)
        {
            Debug.Assert(start > 0 && end > 0);
            Debug.Assert(start < end);

            if (1 == start)
            {
                start++;
            }

            if (2 == start)
            {
                yield return start;
                start++;
            }else if (0 == start%2)
            {
                start++;
            }

            while (start < end)
            {
                bool isPrime = true;
                for (BigInteger i = 3; i < start/2; i+=2)
                {
                    if (0 == start % i)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return start;
                }

                start += 2;
            }

        }

    }
}
