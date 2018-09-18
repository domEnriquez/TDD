using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class Tennis
    {
        private const int REQ_MIN_POINTS = 4;
        private const int REQ_POINTS_ADVANTAGE = 2;
        private const int FIRST_DEUCE_POINT = REQ_MIN_POINTS - 1;

        private Player firstPlayer;
        private Player secondPlayer;
        private Player winner;

        private Dictionary<int, string> scoreMap = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "15" },
            {2, "30" },
            {3, "40" }
        };

        public Tennis()
        {
        }

        public Tennis(string p1Name, string p2Name)
        {
            firstPlayer = new FirstPlayer(p1Name);
            secondPlayer = new SecondPlayer(p2Name);
        }

        public string GetName(int player)
        {
            if (player == 1)
                return firstPlayer.Name;
            else if (player == 2)
                return secondPlayer.Name;

            return string.Empty;
        }

        public bool PlayersReady()
        {
            return firstPlayer != null && secondPlayer != null;
        }

        public void PlayerScores(int player)
        {
            if(winner == null)
            {
                if (player == 1)
                    incrementScore(firstPlayer);
                else
                    incrementScore(secondPlayer);
            }
        }

        private void incrementScore(Player player)
        {
            player.incrementScore();
            Player opponent = player is FirstPlayer ? secondPlayer : firstPlayer;

            if (playerWon(player.Score, opponent.Score))
                winner = player;
        }

        private bool playerWon(int plScore, int oppScore)
        {
            if (scoredAfterDeuce())
                return scoreMetReqAdvantage(plScore, oppScore);
            else
            {
                if (plScore == REQ_MIN_POINTS && scoreMetReqAdvantage(plScore, oppScore))
                    return true;
                else
                    return false;
            }
        }

        private static bool scoreMetReqAdvantage(int plScore, int oppScore)
        {
            return plScore >= oppScore + REQ_POINTS_ADVANTAGE;
        }

        public string ShowGameStatus()
        {
            if (winner != null)
                return "Winner: " + winner.Name;
            else if (scoredAfterDeuce())
                return "Advantage " + leadingPlayer().Name;
            else if (deuce())
                return "Deuce";
            else
                return scoreMap[firstPlayer.Score] + "-" + scoreMap[secondPlayer.Score];
        }

        private bool deuce()
        {
            if (pastFirstDeuce())
                if (firstPlayer.Score == secondPlayer.Score)
                    return true;

            return firstPlayer.Score == FIRST_DEUCE_POINT && secondPlayer.Score == FIRST_DEUCE_POINT;
        }

        private bool scoredAfterDeuce()
        {
            if(pastFirstDeuce())
                if (firstPlayer.Score != secondPlayer.Score)
                    return true;

            return false;
        }

        private bool pastFirstDeuce()
        {
            return firstPlayer.Score >= REQ_MIN_POINTS || secondPlayer.Score >= REQ_MIN_POINTS;
        }

        private Player leadingPlayer()
        {
            if (firstPlayer.Score == secondPlayer.Score)
                return Player.NULL;

            return firstPlayer.Score > secondPlayer.Score ? firstPlayer : secondPlayer;
        }
    }
}
