using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Boundaries;

namespace TicTacToe
{
    public class Game
    {
        private const int SIZE = 3;
        private const int MAX_TURNS = 9;
        private const char EMPTY_CELL = '\0';


        private char[,] board;
        private char lastMove;
        private IBoard boardUI;
        private ICoordinateDecoder decoder;

        public Game(IBoard bUI, ICoordinateDecoder d)
        {
            board = new char[SIZE, SIZE];
            boardUI = bUI;
            decoder = d;
        }

        public void execute()
        {
            for(int i = 0; i < MAX_TURNS; i++)
            {
                PlaceMove('X');

                if (someoneWon())
                    break;

                PlaceMove('O');

                if (someoneWon())
                    break;
            }
        }

        private void PlaceMove(char charMove)
        {
            string input = getUserMove();

            if (charMove == 'X')
                PlaceXIn(decoder.DecodeRow(input), decoder.DecodeCol(input));
            else
                PlaceOIn(decoder.DecodeRow(input), decoder.DecodeCol(input));

            displayBoard();
        }

        public void PlaceXIn(int row, int col)
        {
            if (invalidMove(row,col))
                throw new InvalidMoveException();

            lastMove = 'X';
            board[row, col] = 'X';
        }

        public void PlaceOIn(int row, int col)
        {
            if (invalidMove(row, col))
                throw new InvalidMoveException();

            lastMove = 'O';
            board[row, col] = 'O';
        }

        private bool invalidMove(int row, int col)
        {
            if (someoneWon() || board[row, col] != EMPTY_CELL)
                return true;
            else
                return false;
        }

        public char GetValueIn(int row, int col)
        {
            return board[row, col];
        }

        public bool someoneWon()
        {
            bool result = false;

            result = aColumnIsFilled() || aRowIsFilled() || diagonalIsFilled();

            return result;
        }

        private bool diagonalIsFilled()
        {
            if (board[1, 1] == EMPTY_CELL)
                return false;

            if (rightDiagonalIsFilled() || leftDiagonalIsFilled())
                return true;
            else
                return false;
        }
        private bool rightDiagonalIsFilled()
        {
            return (board[0, 2] == board[1, 1]) && (board[0, 2] == board[2, 0]);
        }

        private bool leftDiagonalIsFilled()
        {
            return ((board[0, 0] == board[1, 1]) && (board[0, 0] == board[2, 2]));
        }

        private bool aRowIsFilled()
        {
            for(int i = 0; i < SIZE; i++)
            {
                if (board[i, 0] == EMPTY_CELL)
                    continue;

                if (rowFilled(i))
                    return true;
            }

            return false;
        }

        private bool rowFilled(int rowNum)
        {
            if ((board[rowNum, 0] == board[rowNum, 1])
                && (board[rowNum, 0] == board[rowNum, 2]))
                return true;
            else
                return false;
        }

        private bool aColumnIsFilled()
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (board[0, i] == EMPTY_CELL)
                    continue;

                if (colFilled(i))
                    return true;
            }

            return false;
        }

        private bool colFilled(int colNum)
        {
            if ((board[0, colNum] == board[1, colNum])
                && (board[0, colNum] == board[2, colNum]))
                return true;
            else
                return false;
        }

        public bool boardIsEmpty()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (board[i, j] != EMPTY_CELL)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public char getWinner()
        {
            if(someoneWon())           
                return lastMove;
             else
                return EMPTY_CELL;
        }

        public void displayBoard()
        {
            boardUI.displayBoard(board, SIZE);
        }

        public void displayWinner()
        {
            boardUI.displayWinner(getWinner());
        }

        public string getUserMove()
        {
            return boardUI.getUserMove();
        }


        public class InvalidMoveException : ApplicationException
        {
        }
    }
}
