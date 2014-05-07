using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Specialized;
using Kw.Combinatorics;

namespace ProjectEuler.Core
{
    /// <summary>
    /// 通过替换数字的某一位或者几位，把该数字转换成另外一个数字
    /// 例如，123通过替换最低位，可以得到120,121,122,123,124,125,126,127,128,129
    /// </summary>
    public class DigitsReplacementTransformer : ITransformer
    {
        public IEnumerable<BigInteger> Steps { get { return steps; } }
        private List<BigInteger> steps = new List<BigInteger>();
        public int DigitsNumToBeReplaced { get { return steps.Count; } }
        public String Name { get { throw new NotImplementedException(); } }

        public override string ToString()
        {
            return String.Join<BigInteger>(",", steps);
        }
        public DigitsReplacementTransformer(BigInteger[] steps) {
            this.steps = steps.ToList();
        }
        public DigitsReplacementTransformer() { }
        public BigInteger TransformToSmallest(BigInteger origin) {
            BigInteger preprocessed = origin;

            // Clear transform digits to zero
            foreach (BigInteger step in this.steps)
            {
                System.Diagnostics.Debug.Assert(1 == step.Reverse());

                preprocessed -= (origin - origin % step - origin / (step * 10) * step * 10);
            }

            return preprocessed;
        }
        public IEnumerable<BigInteger> TransformInteger(System.Numerics.BigInteger origin)
        {
            return TransformWithSteps(this.TransformToSmallest(origin), this.steps.ToArray());
        }

        private static IEnumerable<BigInteger> TransformWithSteps(BigInteger origin, BigInteger[] steps) {
            System.Diagnostics.Debug.Assert(0 < steps.Count());
            if (steps.Count() == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    yield return origin + steps[0] * i;
                }
            }
            else
            {
                BigInteger step = steps.Last();
                List<BigInteger> trimmed = steps.ToList();
                trimmed.RemoveAt(trimmed.Count - 1);

                for (int i = 0; i < 10; i++)
                {
                    foreach (var item in TransformWithSteps(origin + step * i, trimmed.ToArray()))
                    {
                        yield return item;
                    }
                }
            }

        }
        public static IEnumerable<DigitsReplacementTransformer> GetAllTransformersForInteger(BigInteger value)
        {


            if (value < 0)
            {
                value = -value;
            }
            if (value < 10)
            {
                DigitsReplacementTransformer tran = new DigitsReplacementTransformer();
                tran.steps.Add(1);
                yield return tran;

            }
            else
            {
                List<BigInteger> possibleSteps = new List<BigInteger>();
                possibleSteps.Add(1);
                BigInteger step = 10;
                while (value / step > 0)
                {
                    possibleSteps.Add(step);
                    step *= 10;
                }

                // Get all possible combinations
                Combination combination = new Combination(possibleSteps.Count);
                foreach (Combination com in combination.GetRowsForAllPicks())
                {
                    DigitsReplacementTransformer transformer = new DigitsReplacementTransformer();
                    for (int i = 0; i < com.Picks; i++)
                    {
                        transformer.steps.Add(possibleSteps[com[i]]);
                    }
                    yield return transformer;
                }
            }
        }
    }
}
