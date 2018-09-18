using BoardUI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace TicTactToe.Tests
{
    [TestFixture]
    public class TicTacToeUnitTests
    {
        private Game game;
        private StringWriter _stringWriter;

        [SetUp]
        public void SetUp()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            game = new Game(new ConsoleBoard(), new CommaSeparatedCoordinatesDecoder());
        }

        [Test]
        public void placeXinPosition00()
        {
            game.PlaceXIn(0, 0);
            Assert.AreEqual('X', game.GetValueIn(0, 0));
        }

        [Test]
        public void placeOinPosition00()
        {
            game.PlaceOIn(0, 0);
            Assert.AreEqual('O', game.GetValueIn(0, 0));
        }

        [Test]
        public void winVertically()
        {
            game.PlaceXIn(0, 0);
            game.PlaceXIn(1, 0);
            game.PlaceXIn(2, 0);

            Assert.IsTrue(game.someoneWon());
        }

        [Test]
        public void detectIfColIsNotFilled()
        {
            game.PlaceXIn(0, 0);
            game.PlaceXIn(1, 0);
            game.PlaceXIn(2, 1);

            Assert.IsFalse(game.someoneWon());
        }


        [Test]
        public void winHorizontally()
        {
            game.PlaceXIn(0, 0);
            game.PlaceXIn(0, 1);
            game.PlaceXIn(0, 2);

            Assert.IsTrue(game.someoneWon());
        }

        [Test]
        public void detectIfRowIsNotFilled()
        {
            game.PlaceXIn(0, 0);
            game.PlaceXIn(0, 2);
            game.PlaceXIn(2, 1);

            Assert.IsFalse(game.someoneWon());
        }

        [Test]
        public void winDiagonallyRight()
        {
            game.PlaceXIn(0, 2);
            game.PlaceXIn(1, 1);
            game.PlaceXIn(2, 0);

            Assert.IsTrue(game.someoneWon());
        }

        [Test]
        public void winDiagonallyLeft()
        {
            game.PlaceXIn(0, 0);
            game.PlaceXIn(1, 1);
            game.PlaceXIn(2, 2);

            Assert.IsTrue(game.someoneWon());
            Assert.AreEqual('X', game.getWinner());
        }

        [Test]
        public void emptyBoardOnNewGame()
        {
            Assert.IsTrue(game.boardIsEmpty());
        }

        [Test]
        public void notEmptyBoardWhenAMoveIsMade()
        {
            game.PlaceOIn(0, 0);
            Assert.IsFalse(game.boardIsEmpty());
        }

        [Test]
        public void X_wins()
        {
            game.PlaceXIn(0, 0);
            game.PlaceOIn(0, 1);
            game.PlaceXIn(1, 0);
            game.PlaceOIn(0, 2);
            game.PlaceXIn(2, 0);

            Assert.IsTrue(game.someoneWon());
            Assert.AreEqual('X', game.getWinner());
        }

        [Test]
        public void O_wins()
        {
            wonByOScenario();

            Assert.IsTrue(game.someoneWon());
            Assert.AreEqual('O', game.getWinner());
        }

        [Test]
        public void throwInvalidMoveErrorWhenAMoveIsMadeAfterSomeoneWon()
        {
            wonByOScenario();

            Assert.That(() => game.PlaceXIn(2, 2), Throws.TypeOf<Game.InvalidMoveException>());
        }

        [Test]
        public void throwInvalidMoveExceptionWhenPlacingAMoveInAnOccupiedCell()
        {
            game.PlaceOIn(0, 0);

            Assert.That(() => game.PlaceXIn(0, 0), Throws.TypeOf<Game.InvalidMoveException>());
        }

        [Test]
        public void placeXInUIBoard()
        {
            string expected = "X| | |" + Environment.NewLine +
                              " | | |" + Environment.NewLine +
                              " | | |" + Environment.NewLine; 

            game.PlaceXIn(0, 0);
            game.displayBoard();

            Assert.AreEqual(expected.Replace(" ", ""), _stringWriter.ToString().Replace(" ", ""));
        }

        [Test]
        public void placeOInUIBoard()
        {
            string expected = "O| | |" + Environment.NewLine +
                              " | | |" + Environment.NewLine +
                              " | | |" + Environment.NewLine;

            game.PlaceOIn(0, 0);
            game.displayBoard();

            Assert.AreEqual(expected.Replace(" ", ""), _stringWriter.ToString().Replace(" ", ""));
        }

        [Test]
        public void placeMultipleInputsInUIBoard()
        {
            string expected = "O|X|O|" + Environment.NewLine +
                              " |X| |" + Environment.NewLine +
                              " |O| |" + Environment.NewLine;

            game.PlaceOIn(0, 0);
            game.PlaceXIn(0, 1);
            game.PlaceOIn(0, 2);
            game.PlaceXIn(1, 1);
            game.PlaceOIn(2, 1);
            game.displayBoard();

            Assert.AreEqual(expected.Replace(" ", ""), _stringWriter.ToString().Replace(" ", ""));
        }

        [Test]
        public void displayWinner()
        {
            string expected = string.Format("O wins.{0}", Environment.NewLine);
            wonByOScenario();

            game.displayWinner();

            Assert.AreEqual(expected, _stringWriter.ToString());
        }

        [Test]
        public void getRowCoodinateFromUserInput()
        {
            CommaSeparatedCoordinatesDecoder d = new CommaSeparatedCoordinatesDecoder();
            Assert.AreEqual(0, d.DecodeRow("0,1"));
        }

        [Test]
        public void getColCoordinateFromUserInput()
        {
            CommaSeparatedCoordinatesDecoder d = new CommaSeparatedCoordinatesDecoder();
            Assert.AreEqual(1, d.DecodeCol("0,1"));
        }

        [Test]
        public void getUserInput()
        {
            string expectedInput = "0,0";
            using (StringReader sr = new StringReader(expectedInput))
            {
                Console.SetIn(sr);

                string actualInput = game.getUserMove();

                Assert.AreEqual(expectedInput, actualInput);
            }
        }

        [Test]
        public void actualGameWhereXWins()
        {
            using(StringReader sr = new StringReader(string.Format("0,0{0}0,1{0}1,0{0}0,2{0}2,0", Environment.NewLine)))
            {
                Console.SetIn(sr);

                game.execute();

                Assert.AreEqual('X', game.getWinner());
            }
        }

        [Test]
        public void actualGameWhereOWins()
        {
            using (StringReader sr = new StringReader(string.Format("0,0{0}0,1{0}1,0{0}1,1{0}0,2{0}2,1", Environment.NewLine)))
            {
                Console.SetIn(sr);

                game.execute();

                Assert.AreEqual('O', game.getWinner());
            }
        }

        private void wonByOScenario()
        {
            game.PlaceOIn(0, 0);
            game.PlaceXIn(0, 1);
            game.PlaceOIn(1, 0);
            game.PlaceXIn(0, 2);
            game.PlaceOIn(2, 0);
        }

        private string boardWithXAt00()
        {
            return "X| | |" + Environment.NewLine +
                   " | | |" + Environment.NewLine +
                   " | | |" + Environment.NewLine;
        }

    }
}
 