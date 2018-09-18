using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisGame;

namespace TennisGameTests
{
    [TestFixture]
    public class TennisGameTest
    {
        public class TennisGameWithInvalidPlayerNameInputs
        {
            [Test]
            public void givenNewTennisGame_whenEmptyFirstPlayerName_setDefaultFirstPlayerName()
            {
                Tennis g = new Tennis("", "p2");
                Assert.AreEqual("Player 1", g.GetName(1));
            }

            [Test]
            public void givenNewTennisGame_whenEmptySecPlayerName_setDefaultSecPlayerName()
            {
                Tennis g = new Tennis("p1", "");
                Assert.AreEqual("Player 2", g.GetName(2));
            }
        }

        public class TennisGameWithValidCustomPlayerNames
        {
            private void firstPlayerScores(int score)
            {
                for (int i = 0; i < score; i++)
                    game.PlayerScores(1);
            }

            private void secondPlayerScores(int score)
            {
                for (int i = 0; i < score; i++)
                    game.PlayerScores(2);
            }

            private void deuceGame()
            {
                secondPlayerScores(3);
                firstPlayerScores(3);
            }

            Tennis game;

            [SetUp]
            public void GivenANewTennisGame()
            {
                game = new Tennis("p1", "p2");
            }

            [Test]
            public void whenNewGameCreated_thenPlayersInititialized()
            {
                Assert.IsTrue(game.PlayersReady());
            }

            [Test]
            public void whenPlayersHasNoScore_thenShowLoveLove()
            {
                Assert.AreEqual("Love-Love", game.ShowGameStatus());
            }

            [Test]
            public void whenGameNotInDeuce_thenShowBothPlayersScore()
            {
                firstPlayerScores(1);
                secondPlayerScores(1);
                Assert.AreEqual("15-15", game.ShowGameStatus());

                firstPlayerScores(2);
                Assert.AreEqual("40-15", game.ShowGameStatus());

                secondPlayerScores(1);
                Assert.AreEqual("40-30", game.ShowGameStatus());
            }

            [Test]
            public void whenDeuceGame_thenShowDeuce()
            {
                deuceGame();

                Assert.AreEqual("Deuce", game.ShowGameStatus());
            }

            [Test]
            public void whenFirstPlayerScoredWhileDeuce_thenShowAdvantageFirstPlayer()
            {
                deuceGame();
                firstPlayerScores(1);

                Assert.AreEqual("Advantage p1", game.ShowGameStatus());
            }

            [Test]
            public void whenSecPlayerScoredWhileDeuce_thenShowAdvantageSecPlayer()
            {
                deuceGame();
                secondPlayerScores(1);

                Assert.AreEqual("Advantage p2", game.ShowGameStatus());
            }

            [Test]
            public void whenBackToDeuceAfterAdvantage_thenShowDeuce()
            {
                deuceGame();
                firstPlayerScores(1);
                secondPlayerScores(1);

                Assert.AreEqual("Deuce", game.ShowGameStatus());
            }

            [Test]
            public void whenAlternatingScoresAfterDeuce_thenShowAlternatingAdvantageAndDeuce()
            {
                deuceGame();
                Assert.AreEqual("Deuce", game.ShowGameStatus());

                firstPlayerScores(1);
                Assert.AreEqual("Advantage p1", game.ShowGameStatus());

                secondPlayerScores(1);
                Assert.AreEqual("Deuce", game.ShowGameStatus());

                secondPlayerScores(1);
                Assert.AreEqual("Advantage p2", game.ShowGameStatus());

                firstPlayerScores(1);
                secondPlayerScores(1);
                Assert.AreEqual("Advantage p2", game.ShowGameStatus());
            }

            [Test]
            public void whenFirstPlayerGetsReqMinPointsAndPointsAdvantage_thenFirstPlayerWins()
            {
                firstPlayerScores(2);
                secondPlayerScores(2);
                firstPlayerScores(2);

                Assert.AreEqual("Winner: p1", game.ShowGameStatus());
            }

            [Test]
            public void whenSecPlayerGetsReqMinPointsAndPointsAdvantage_thenSecPlayerWins()
            {
                secondPlayerScores(2);
                firstPlayerScores(2);
                secondPlayerScores(2);

                Assert.AreEqual("Winner: p2", game.ShowGameStatus());
            }

            [Test]
            public void whenFirstPlayerGetsReqPointsAdvantageAfterDeuce_thenShowFirstPlayerWins()
            {
                deuceGame();
                firstPlayerScores(2);

                Assert.AreEqual("Winner: p1", game.ShowGameStatus());
            }

            [Test]
            public void whenSecPlayerGetsReqPointsAdvantageAfterDeuce_thenShowSecPlayerWins()
            {
                deuceGame();
                secondPlayerScores(2);

                Assert.AreEqual("Winner: p2", game.ShowGameStatus());
            }

            [Test]
            public void whenSomeoneWins_thenDoNotIncrementPlayersScoreAnymore()
            {
                firstPlayerScores(4);
                secondPlayerScores(6);

                Assert.AreEqual("Winner: p1", game.ShowGameStatus());
            }
        }

    }
}
