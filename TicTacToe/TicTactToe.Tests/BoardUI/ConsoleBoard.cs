using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Boundaries;

namespace BoardUI
{
    public class ConsoleBoard : IBoard
    {
        private const char EMPTY_CELL = '\0';


        public void displayBoard(char[,] board, int dimensions)
        {
            for(int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    Console.Write(cellContent(board[i, j]) + " | ");
                }

                Console.WriteLine();
            }
        }
        public void displayWinner(char winner)
        {
            Console.WriteLine(winner + " wins.");
        }

        public string getUserMove()
        {
            return Console.ReadLine();
        }

        private string cellContent(char boardEl)
        {
            if (boardEl == EMPTY_CELL)
                return string.Empty;
            else
                return boardEl.ToString();
        }
    }
}
