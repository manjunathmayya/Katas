using System;
using System.Linq;
using Xunit;

namespace Katas
{
    public class HammingTests
    {
        [Fact]
        public void Empty_strands()
        {
            Assert.Equal(0, Hamming.Distance("", ""));
        }

        [Fact]
        public void Single_letter_identical_strands()
        {
            Assert.Equal(0, Hamming.Distance("A", "A"));
        }

        [Fact]
        public void Single_letter_different_strands()
        {
            Assert.Equal(1, Hamming.Distance("G", "T"));
        }

        [Fact]
        public void Long_identical_strands()
        {
            Assert.Equal(0, Hamming.Distance("GGACTGAAATCTG", "GGACTGAAATCTG"));
        }

        [Fact]
        public void Long_different_strands()
        {
            Assert.Equal(9, Hamming.Distance("GGACGGATTCTG", "AGGACGGATTCT"));
        }

        [Fact]
        public void Disallow_first_strand_longer()
        {
            Assert.Throws<ArgumentException>(() => Hamming.Distance("AATG", "AAA"));
        }

        [Fact]
        public void Disallow_second_strand_longer()
        {
            Assert.Throws<ArgumentException>(() => Hamming.Distance("ATA", "AGTG"));
        }

        [Fact]
        public void Disallow_left_empty_strand()
        {
            Assert.Throws<ArgumentException>(() => Hamming.Distance("", "G"));
        }

        [Fact]
        public void Disallow_right_empty_strand()
        {
            Assert.Throws<ArgumentException>(() => Hamming.Distance("G", ""));
        }
    }
    public static class Hamming
    {
        public static int Distance(string firstStrand, string secondStrand)
        {
            if (firstStrand.Length == secondStrand.Length)
                return GetDistance(firstStrand, secondStrand);
            else
                throw new ArgumentException();
        }

        private static int GetDistance(string firstStrand, string secondStrand)
        {
            var check = firstStrand.Zip(secondStrand, (first, second) => first == second);
            return check.Count(x => x == false);
        }
    }
}
