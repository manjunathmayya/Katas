using System;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    class TennisTest
    {
        [TestCase(0,0, "Love-Love")]
        [TestCase(1,0, "15-Love")]
        [TestCase(2,0, "30-Love")]
        [TestCase(3,0, "40-Love")]
        [TestCase(0,1, "Love-15")]
        [TestCase(0,2, "Love-30")]
        [TestCase(0,3, "Love-40")]
        [TestCase(1,1, "15-15")]
        [TestCase(2,2, "30-30")]
        [TestCase(3,3, "Deuce")]
        [TestCase(1,3, "15-40")]
        [TestCase(2,3, "30-40")]
        [TestCase(3,1, "40-15")]
        [TestCase(3,2, "40-30")]
        [TestCase(4,4, "Deuce")]
        [TestCase(5,4, "Advantage Player 1")]
        [TestCase(15,14, "Advantage Player 1")]
        [TestCase(4,5, "Advantage Player 2")]
        [TestCase(44,45, "Advantage Player 2")]
        [TestCase(6, 4, "Win Player 1")]
        [TestCase(4, 6, "Win Player 2")]

        public void TestTennis(int player1Points, int player2Points, string result)
        {
            Assert.AreEqual(result, Tennis(player1Points, player2Points));
        }


        private string Tennis(int player1Points, int player2Points)
        {
            //check if player 1 won
            if (PlayerWon(player1Points,  player2Points))
                return "Win Player 1";
            
            //check if player 2 won
            if (PlayerWon(player2Points , player1Points))
                return "Win Player 2";

            if (IsDeuce(player1Points, player2Points))
                return "Deuce";

            if (BothPlayerHasMoreThan3Points(player1Points, player2Points))
            {
                if (PlayerAdvantage(player1Points , player2Points ))
                    return "Advantage Player 1";
                if (PlayerAdvantage(player2Points, player1Points))
                    return "Advantage Player 2";
            }

            return Score(player1Points)+ "-" + Score(player2Points);
        }

        private static bool PlayerAdvantage(int playerPoints, int otherPlayerPoints)
        {
            return (playerPoints - otherPlayerPoints == 1);
        }

        private static bool BothPlayerHasMoreThan3Points(int player1Points, int player2Points)
        {
            return player1Points > 3 && player2Points > 3;
        }

        private static bool PlayerWon(int playerPoints, int otherPlayerPoints)
        {
            return (playerPoints - otherPlayerPoints >= 2 && playerPoints >= 4);
        }

        private static bool IsDeuce(int player1Points, int player2Points)
        {
            return player1Points == player2Points && player1Points >= 3;
        }

        private string Score(int playerPoints)
        {
            string points = "";
            if (playerPoints == 0)
                points = "Love";
            else if (playerPoints == 1)
                points = "15";
            else if (playerPoints == 2)
                return "30";
            else if (playerPoints == 3)
                return "40";

            return points;

        }
    }

}