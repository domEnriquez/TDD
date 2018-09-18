using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Boundaries;

namespace BoardUI
{
    public class CommaSeparatedCoordinatesDecoder : ICoordinateDecoder
    {
        public int DecodeRow(string commaSeparatedCoord)
        {
            return int.Parse(splitByComma(commaSeparatedCoord)[0]);
        }

        public int DecodeCol(string commaSeparatedCoord)
        {
            return int.Parse(splitByComma(commaSeparatedCoord)[1]);
        }

        private string[] splitByComma(string s)
        {
            return s.Replace(" ", "").Split(',');
        }

    }
}
