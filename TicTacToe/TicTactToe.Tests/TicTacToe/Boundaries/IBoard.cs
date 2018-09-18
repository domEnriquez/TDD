using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Boundaries
{
    public interface IBoard
    {
        void displayBoard(char[,] board, int dimensions);
        void displayWinner(char winner);
        string getUserMove();
    }
}
