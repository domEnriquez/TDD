using Minesweeper;
using NUnit.Framework;
using System;
using System.IO;

namespace MinesweeperTests
{
    [TestFixture]
    public class MinesweeperTest
    {
        private void assertGridContains(string gridElements)
        {
            string expGrid = string.Join("", splitGridElements(gridElements)); 

            int count = 0;
            for (int i = 0; i < mw.Grid.RowSize(); i++)
                for (int j = 0; j < mw.Grid.ColSize(); j++)
                    Assert.AreEqual(expGrid[count++], mw.Grid.GetElementAt(i, j));
        }

        private string[] splitGridElements(string gridElements)
        {
            return gridElements.Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }

        MinesweeperApp mw;

        [SetUp]
        public void GivenANewMinesweeper()
        {
            mw = new MinesweeperApp(new MultiArrayGrid());
        }

        [Test]
        public void WhenCreatingNewMinesweeper_ThenZeroGridRowAndColSize()
        {
            Assert.AreEqual(0, mw.Grid.RowSize());
            Assert.AreEqual(0, mw.Grid.ColSize());
        }

        [Test]
        public void WhenSettingGridDimensionWithEmptyString_ThenZeroGridRowAndColSize()
        {
            mw.Grid.SetDimensions(string.Empty);

            Assert.AreEqual(0, mw.Grid.RowSize());
            Assert.AreEqual(0, mw.Grid.ColSize());
        }

        [Test]
        public void WhenSettingGridDimensionWithNull_ThenZeroGridRowAndColSize()
        {
            mw.Grid.SetDimensions(null);

            Assert.AreEqual(0, mw.Grid.RowSize());
            Assert.AreEqual(0, mw.Grid.ColSize());
        }

        [Test]
        public void WhenSettingGridWithValidDimensions_thenCreateGrid()
        {
            mw.Grid.SetDimensions("2 3");

            Assert.IsNotNull(mw.Grid);
            Assert.AreEqual(2, mw.Grid.RowSize());
            Assert.AreEqual(3, mw.Grid.ColSize());
        }

        [Test]
        public void WhenSettingGridWithDimensionsExtraSpaces_ThenSetGridRowAndColSize()
        {
            mw.Grid.SetDimensions("   2   1   ");

            Assert.AreEqual(2, mw.Grid.RowSize());
            Assert.AreEqual(1, mw.Grid.ColSize());
        }

        [Test]
        public void WhenBuildingGridWithNullElements_ThenThrowInvalidGridElementException()
        {
            Assert.Throws<Grid.InvalidGridElementException>(() => mw.Grid.PopulateWith(null));
        }

        [Test]
        public void WhenBuildingGridWithEmptyElements_ThenThrowInvalidGridElementException()
        {
            Assert.Throws<Grid.InvalidGridElementException>(() => mw.Grid.PopulateWith(string.Empty));
        }

        [Test]
        public void WhenBuildingGridWithAllSafeFields_ThenPopulateGridWithSafeFields()
        {
            mw.Grid.SetDimensions("2 2");
            string gridElements = ". ." + ". .";

            mw.Grid.PopulateWith(gridElements);

            assertGridContains(gridElements);
        }

        [Test]
        public void WhenBuildingGridWithAMineField_ThenPlaceMineFieldInGrid()
        {
            mw.Grid.SetDimensions("2 2");

            string gridElements = ". *" + ". .";
            mw.Grid.PopulateWith(gridElements);
            assertGridContains(gridElements);

            gridElements = ". ." + "* *";
            mw.Grid.PopulateWith(gridElements);
            assertGridContains(gridElements);
        }

        [Test]
        public void WhenBuildingGridWithElementsExceedingColSize_ThenThrowGridSizeOverflowException()
        {
            mw.Grid.SetDimensions("2 2");
            string gridElements = ". ." + ". . .";

            Assert.Throws<Grid.GridSizeOverflowException>(() => mw.Grid.PopulateWith(gridElements));
        }

        [Test]
        public void WhenBuildingGridWithElementsExceedingRowSize_ThenThrowGridSizeOverflowException()
        {
            mw.Grid.SetDimensions("2 2");
            string gridElements = ". ." + ". ." + ". .";

            Assert.Throws<Grid.GridSizeOverflowException>(() => mw.Grid.PopulateWith(gridElements));
        } 

        [Test]
        public void WhenBuildingGridWithElementsHavingNoSpaceDivider_ThenContinueBuildingGrid()
        {
            mw.Grid.SetDimensions("2 2");
            string gridElements = ".." + "..";

            mw.Grid.PopulateWith(gridElements);

            assertGridContains(gridElements);
        }

        [Test]
        public void WhenBuildingGridWithElementsHavingExtraSpaces_ThenContinueBuildingGrid()
        {
            mw.Grid.SetDimensions("2 2");
            string gridElements = " .   ." + " .. ";

            mw.Grid.PopulateWith(gridElements);

            assertGridContains(gridElements);
        }

        [Test]
        public void WhenMineSweepGridWithAllSafeFields_ThenGridElemsAreAll0()
        {
            mw.Grid.SetDimensions("2 2");
            string gridElements = ".." + "..";
            mw.Grid.PopulateWith(gridElements);

            mw.Grid.MineSweep();

            for (int i = 0; i < mw.Grid.RowSize(); i++)
                for (int j = 0; j < mw.Grid.ColSize(); j++)
                    Assert.AreEqual('0', mw.Grid.GetElementAt(i, j));
        }

        [Test]
        public void WhenMineSweepGridWithAllMines_ThenGridElemsAreAllMines()
        {
            mw.Grid.SetDimensions("1 2");
            string gridElements = "* *";
            mw.Grid.PopulateWith(gridElements);

            mw.Grid.MineSweep();

            Assert.AreEqual('*', mw.Grid.GetElementAt(0, 0));
            Assert.AreEqual('*', mw.Grid.GetElementAt(0, 1));
        }

        [Test]
        public void WhenMineSweepGrid_ThenUpdateSafeFieldsWithAdjacentMinesCount()
        {
            mw.Grid.SetDimensions("3 3");
            string gridElements = "* . ." + "* * *" + ". . *";
            mw.Grid.PopulateWith(gridElements);

            mw.Grid.MineSweep();

            Assert.AreEqual('*', mw.Grid.GetElementAt(0, 0));
            Assert.AreEqual('4', mw.Grid.GetElementAt(0, 1));
            Assert.AreEqual('2', mw.Grid.GetElementAt(0, 2));
            Assert.AreEqual('*', mw.Grid.GetElementAt(1, 0));
            Assert.AreEqual('*', mw.Grid.GetElementAt(1, 1));
            Assert.AreEqual('*', mw.Grid.GetElementAt(1, 2));
            Assert.AreEqual('2', mw.Grid.GetElementAt(2, 0));
            Assert.AreEqual('4', mw.Grid.GetElementAt(2, 1));
            Assert.AreEqual('*', mw.Grid.GetElementAt(2, 2));
        }
    }
}
