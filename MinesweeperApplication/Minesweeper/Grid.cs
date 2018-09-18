using System;

namespace Minesweeper
{
    public abstract class Grid
    {
        public abstract void SetDimensions(string dimensions);

        public abstract int RowSize();

        public abstract int ColSize();

        public abstract void PopulateWith(string gridElements);

        public abstract char GetElementAt(int i, int j);

        public abstract void MineSweep();

        public class InvalidGridElementException : ApplicationException
        {
        }
        public class GridSizeOverflowException : ApplicationException
        {
        }
    }
}
