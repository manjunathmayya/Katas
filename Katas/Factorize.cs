using NUnit.Framework;
using System.Collections.Generic;

namespace Katas
{
    [TestFixture]
    public class FactorizeTest
    {
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [TestCase(4, "2,2")]
        [TestCase(9, "3,3")]
        [TestCase(12, "2,2,3")]
        [TestCase(15, "3,5")]
        public void test_factorize(int input, string expected)
        {
            // a simple example to start you off       
            Assert.AreEqual(expected, Factorize(input));
        }


        private string Factorize(int number)
        {
            List<int> prime_factors = new List<int>();
            string factors = "";

            int quotient = 0;

            while (number != 1)
            {
                if (number % 2 == 0)
                {
                    prime_factors.Add(2);
                    number = number / 2;
                    continue;
                }

                if (number % 3 == 0)
                {
                    prime_factors.Add(3);
                    number = number / 3;
                    continue;
                }

                if (number % 5 == 0)
                {
                    prime_factors.Add(5);
                    number = number / 5;
                    continue;
                }
            }

            foreach (int factor in prime_factors)
            {
                if (factors == "")
                    factors = factor.ToString();
                else
                    factors += "," + factor.ToString();
            }

            return factors;
        }
    }
}