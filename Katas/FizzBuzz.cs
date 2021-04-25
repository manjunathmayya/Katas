using System;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    class FizzBuzzTest
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        public void TestFizzBuzz(int year, string result)
        {
            Assert.AreEqual(result, FizzBuzz(year));
        }

        [Test]
        public void PrintFizzBuzz()
        {
            for (var number = 1; number <= 100; number++)
            {
                Console.WriteLine(FizzBuzz(number));
            }
        }

        private string FizzBuzz(int value)
        {
            if (IsFizz(value) && IsBuzz(value))
            {
                return "FizzBuzz";
            }
            if (IsFizz(value))
            {
                return "Fizz";
            }
            if (IsBuzz(value))
            {
                return "Buzz";
            }
            return value.ToString();
        }

        private static bool IsBuzz(int value)
        {
            return value % 5 == 0;
        }

        private static bool IsFizz(int value)
        {
            return value % 3 == 0;
        }
    }


}
