using System;

namespace Minesweeper
{
    public class MultiArrayGrid : Grid
    {
        private char[,] grid;

        public MultiArrayGrid()
        {
            grid = new char[0, 0];
        }
        public override void SetDimensions(string dimensions)
        {
            if (string.IsNullOrEmpty(dimensions))
                return;

            string[] dimArray = splitBySpace(dimensions);

            grid = new char[int.Parse(dimArray[0]), int.Parse(dimArray[1])];
        }

        private string[] splitBySpace(string dimensions)
        {
            return dimensions.Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }

        public override char GetElementAt(int i, int j)
        {
            return grid[i, j];
        }
        
        public override int RowSize()
        {
            return grid.GetLength(0);
        }

        public override int ColSize()
        {
            return grid.GetLength(1);
        }

        public override void PopulateWith(string gridElements)
        {
            if (gridElements == null || gridElements.Length == 0)
                throw new InvalidGridElementException();

            string elems = string.Join("", splitBySpace(gridElements));

            if (elems.Length > RowSize() * ColSize())
                throw new GridSizeOverflowException();

            int x = 0;
            for (int i = 0; i < RowSize(); i++)
                for (int j = 0; j < ColSize(); j++)
                    grid[i, j] = elems[x++];
        }

        public override void MineSweep()
        {
            for (int i = 0; i < RowSize(); i++)
                for (int j = 0; j < ColSize(); j++)
                    if (grid[i, j] != '*')
                    {
                        int counter = 0;

                        if (topMinePresent(i, j)) counter++;
                        if (bottomMinePresent(i, j)) counter++;
                        if (leftMinePresent(i, j)) counter++;
                        if (rightMinePresent(i, j)) counter++;
                        if (upperRightMinePresent(i, j)) counter++;
                        if (upperLeftMinePresent(i, j)) counter++;
                        if (lowerLeftMinePresent(i, j)) counter++;
                        if (lowerRightMinePresent(i, j)) counter++;

                        grid[i, j] = Convert.ToChar(counter.ToString());
                    }
        }

        private bool lowerRightMinePresent(int i, int j)
        {
            return i < RowSize() - 1 && j < ColSize() - 1 && grid[i + 1, j + 1] == '*';
        }

        private bool lowerLeftMinePresent(int i, int j)
        {
            return i < RowSize() - 1 && j > 0 && grid[i + 1, j - 1] == '*';
        }

        private bool upperRightMinePresent(int i, int j)
        {
            return i > 0 && j < ColSize() - 1 && grid[i - 1, j + 1] == '*';
        }

        private bool upperLeftMinePresent(int i, int j)
        {
            return (i > 0 && j > 0 && grid[i - 1, j - 1] == '*');
        }

        private bool topMinePresent(int i, int j)
        {
            return (i > 0 && grid[i - 1, j] == '*');
        }

        private bool bottomMinePresent(int i, int j)
        {
            return (i < RowSize() - 1 && grid[i + 1, j] == '*');
        }

        private bool leftMinePresent(int i, int j)
        {
            return (j > 0 && grid[i, j - 1] == '*');
        }

        private bool rightMinePresent(int i, int j)
        {
            return (j < ColSize() - 1 && grid[i, j + 1] == '*');
        }
    }
}
