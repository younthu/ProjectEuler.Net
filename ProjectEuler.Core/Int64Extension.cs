using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Core
{
    public static class Int64Extension
    {
        public static bool IsPrime(this int value, bool boostUp = true) {
            throw new NotImplementedException();
        }
        public static bool IsPrime(this Int64 value, bool boostUp = true) {
            if (value < 2)
            {
                return false;
            }
            if (2 == value)
            {
                return true;
            }
            if (0 == value % 2)
            {
                return false;
            }

            for (Int64 i = 3; i < value / 2; i += 2)
            {
                if (0 == value % i)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
