using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler.Core
{
    public interface ITransformer
    {
        IEnumerable<BigInteger> TransformInteger(BigInteger origin);
    }
}
