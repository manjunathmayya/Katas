using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

/*
 
 Your task is to process a sequence of integer numbers to determine the following statistics:

    o) minimum value
    o) maximum value
    o) number of elements in the sequence
    o) average value

For example: [6, 9, 15, -2, 92, 11]

    o) minimum value = -2
    o) maximum value = 92
    o) number of elements in the sequence = 6
    o) average value = 21.833333

 */
namespace Katas
{
    [TestFixture]
    class CalcStatsTests
    {
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 10 ,1 }, 1)]
        [TestCase(new int[] { 10 ,111, 123, 444, 10000 }, 10)]
        public void test_minimum_of_array(int[] elements, int expectedMinValue)
        {
            Assert.AreEqual(expectedMinValue, CalcStats.GetMinimum(elements));
        }

        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 10, 1 }, 10)]
        [TestCase(new int[] { 10, 111, 123, 444, 10000 }, 10000)]
        public void test_maximum_of_array(int[] elements, int expectedMaxValue)
        {
            Assert.AreEqual(expectedMaxValue, CalcStats.GetMaximum(elements));
        }


        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 10, 1 }, 2)]
        [TestCase(new int[] { 10, 111, 123, 444, 10000 }, 5)]
        public void test_number_of_elements(int[] elements, int expectedLength)
        {
            Assert.AreEqual(expectedLength, CalcStats.GetLength(elements));
        }

        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 10, 1 }, 5.5)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, 35)]
        public void test_average(int[] elements, double expectedAverage)
        {
            Assert.AreEqual(expectedAverage, CalcStats.GetAverage(elements));
        }
    }
    class CalcStats
    {
        public static int GetMinimum(int[] elements)
        {
            return elements.Min();
        }

        public static int GetMaximum(int[] elements)
        {
            return elements.Max();
        }

        public static int GetLength(int[] elements)
        {
            return elements.Length;
        }

        public static double GetAverage(int[] elements)
        {
            return elements.Average();
        }
    }
}
