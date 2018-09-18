using System;

namespace Minesweeper
{
    public class MinesweeperApp
    {
        public Grid Grid { get; set; }

        public MinesweeperApp(Grid grid)
        {
            Grid = grid;
        }
    }
}