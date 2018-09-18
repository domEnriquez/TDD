using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Game game;
        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.roll(pins);
            }
        }
        private void rollSpare()
        {
            game.roll(5);
            game.roll(5);
        }
        private void rollStrike()
        {
            game.roll(10);
        }

        [TestInitialize]
        public void initialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void canRoll()
        {
            game.roll(0);
        }

        [TestMethod]
        public void gutterGame()
        {
            rollMany(20, 0);
            Assert.AreEqual(game.score(), 0);
        }


        [TestMethod]
        public void rollAllOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(game.score(), 20);
        }

        [TestMethod]
        public void oneSpare()
        {
            rollSpare();
            game.roll(3);
            rollMany(17, 0);
            Assert.AreEqual(16, game.score());
        }

        [TestMethod]
        public void oneStrike()
        {
            rollStrike();
            game.roll(3);
            game.roll(4);
            rollMany(16, 0);
            Assert.AreEqual(24, game.score());
        }

        [TestMethod]
        public void perfectGame()
        {
            rollMany(21, 10);
            Assert.AreEqual(300, game.score());
        }


    }
}
