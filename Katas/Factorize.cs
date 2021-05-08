using NUnit.Framework;
using System.Collections.Generic;

namespace Katas
{
    [TestFixture]
    public class FactorizeTest
    {
        [TestCase(2, "[2]")]
        [TestCase(3, "[3]")]
        [TestCase(4, "[2,2]")]
        [TestCase(9, "[3,3]")]
        [TestCase(12, "[2,2,3]")]
        [TestCase(15, "[3,5]")]
        public void test_factorize(int input, string expected)
        {
            // a simple example to start you off       
            Assert.AreEqual(expected, Factorize(input));
        }

        private string Factorize(int input)
        {
            List<int> prime_factors = new List<int>();

            for (int factor = 2; factor <= input; factor++)
            {
                while (input % factor == 0 && input / factor >= 1)
                {
                    prime_factors.Add(factor);
                    input = input / factor;
                }
            }

            return "[" + string.Join(",", prime_factors) + "]";
        }
    }
}