// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;
using System.Collections.Generic;

namespace Katas
{
    public class ProverbTests
    {
        [Fact]
        public void Zero_pieces()
        {
            var strings = new string[] { };
            var expected = new string[] { };
            Assert.Equal(expected, Proverb.Recite(strings));
        }

        [Fact]
        public void One_piece()
        {
            var strings = new[]
            {
                "nail"
            };
            var expected = new[]
            {
                "And all for the want of a nail."
            };
            Assert.Equal(expected, Proverb.Recite(strings));
        }

        [Fact]
        public void Two_pieces()
        {
            var strings = new[]
            {
                "nail",
                "shoe"
            };
            var expected = new[]
            {
                "For want of a nail the shoe was lost.",
                "And all for the want of a nail."
            };
            Assert.Equal(expected, Proverb.Recite(strings));
        }

        [Fact]
        public void Three_pieces()
        {
            var strings = new[]
            {
                "nail",
                "shoe",
                "horse"
            };
            var expected = new[]
            {
                "For want of a nail the shoe was lost.",
                "For want of a shoe the horse was lost.",
                "And all for the want of a nail."
            };
            Assert.Equal(expected, Proverb.Recite(strings));
        }

        [Fact]
        public void Full_proverb()
        {
            var strings = new[]
            {
                "nail",
                "shoe",
                "horse",
                "rider",
                "message",
                "battle",
                "kingdom"
            };
            var expected = new[]
            {
                "For want of a nail the shoe was lost.",
                "For want of a shoe the horse was lost.",
                "For want of a horse the rider was lost.",
                "For want of a rider the message was lost.",
                "For want of a message the battle was lost.",
                "For want of a battle the kingdom was lost.",
                "And all for the want of a nail."
            };
            Assert.Equal(expected, Proverb.Recite(strings));
        }

        [Fact]
        public void Four_pieces_modernized()
        {
            var strings = new[]
            {
                "pin",
                "gun",
                "soldier",
                "battle"
            };
            var expected = new[]
            {
                "For want of a pin the gun was lost.",
                "For want of a gun the soldier was lost.",
                "For want of a soldier the battle was lost.",
                "And all for the want of a pin."
            };
            Assert.Equal(expected, Proverb.Recite(strings));
        }
    }

    public static class Proverb
    {
        public static string[] Recite(string[] subjects)
        {
            List<string> strings = new List<string>();

            for (int index = 0; index < subjects.Length; index++)
            {
                if (index + 1 >= subjects.Length)
                {
                    strings.Add("And all for the want of a " + subjects[0] + ".");
                }
                else
                {
                    strings.Add("For want of a " + subjects[index] + " the " + subjects[index + 1] + " was lost.");
                }
            }

            //if (subjects.Length == 1)
            //{
            //    strings.Add("And all for the want of a " + subjects[0] + ".");
            //}

            return strings.ToArray();
        }
    }
}