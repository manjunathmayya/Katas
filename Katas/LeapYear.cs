using NUnit.Framework;

namespace Katas
{
    class LeapYear
    {
        static void Main(string[] args)
        {
        }
    }

    [TestFixture]
    public class LeapYearTest
    {
        [TestCase( 2020, true)]
        [TestCase( 2021, false)]
        [TestCase( 2024, true)]
        [TestCase( 1900, false)]
        [TestCase( 2000, true)]
        [TestCase( 1800, false)]
        public void testLeapYear(int year, bool result)
        {
            Assert.AreEqual(result, isLeapYear(year));
        }

        private bool isLeapYear(int year)
        {
            if (IsDivisibleBy400(year))
                return true;
            if (IsDivisibleBy4(year) && !IsDivisibleBy100(year))
                return true;
            return false;
        }

        private static bool IsDivisibleBy4(int year)
        {
            return year % 4 == 0;
        }

        private static bool IsDivisibleBy400(int year)
        {
            return year % 400 == 0;
        }

        private static bool IsDivisibleBy100(int year)
        {
            return (year % 100 == 0);
        }
    }
}
