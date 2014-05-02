using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Resolver
{
    [TestClass]
    public class ProjectEuler1Resolver
    {
        [TestMethod]
        public void Resolver1()
        {
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (0 == i% 3 || 0 == i%5)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
