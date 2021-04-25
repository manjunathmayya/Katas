using NUnit.Framework;

namespace Katas
{
    class TwoFerTest
    {
        [TestCase("Alice", "One for Alice, one for me.")]
        [TestCase("Bob", "One for Bob, one for me.")]
        [TestCase("", "One for you, one for me.")]
        public void TestTwoFer(string name, string result)
        {
            Assert.AreEqual(result, TwoFer(name));
        }

        public string TwoFer(string name)
        {
            if (name == "")
                name = "you";
            return "One for " + name + ", one for me.";
        }
    }
}
