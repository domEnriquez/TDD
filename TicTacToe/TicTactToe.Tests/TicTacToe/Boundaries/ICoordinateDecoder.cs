using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Boundaries
{
    public interface ICoordinateDecoder
    {
        int DecodeRow(string input);
        int DecodeCol(string input);

    }
}
