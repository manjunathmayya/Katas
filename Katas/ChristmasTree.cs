using NUnit.Framework;
using System;

namespace Katas
{
    [TestFixture]
    public class ChristmasTreeTest
    {
        [TestCase(5, 1, "    x")]
        [TestCase(5, 2, "   xxx")]
        [TestCase(5, 3, "  xxxxx")]
        [TestCase(5, 4, " xxxxxxx")]
        [TestCase(5, 5, "xxxxxxxxx")]
        [TestCase(5, 6, "    |")]
        public void TestTree(int height, int currentLevel, string output)
        {
            Assert.AreEqual(output, ChristmasTree(height, currentLevel));
        }

        //Just printing the tree to console/output. No testing done here.
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void TestPrintTree(int height)
        {
            PrintChristmasTree(height);
        }

        private void PrintChristmasTree(int height)
        {
            for (int currentLevel = 1; currentLevel <= height + 1; currentLevel++)
            {
                Console.WriteLine(ChristmasTree(height, currentLevel));
            }
        }

        private string ChristmasTree(int height, int currentLevel)
        {
            string spaces = "";
            string xes = "";

            if (isBaseOfTree(height, currentLevel))
            {
                spaces = get_characters(' ', height - 1);
                return spaces + "|";
            }

            int numberOfSpaces = height - currentLevel;
            int numberOfXes = (2 * (currentLevel - 1) + 1);

            spaces = get_characters(' ', numberOfSpaces);
            xes = get_characters('x', numberOfXes);

            return spaces + xes;
        }

        private bool isBaseOfTree(int height, int currentLevel)
        {
            return currentLevel == height + 1;
        }

        private string get_characters(char character, int count)
        {
            string chars = "";
            for (int index = 0; index < count; index++)
                chars = chars + character;
            return chars;
        }
    }
}