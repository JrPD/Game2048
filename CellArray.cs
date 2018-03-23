using System;
using System.Collections.Generic;

namespace Game2048
{
    public class CellArray
    {
        private Cell[, ] cells;

        public int Dimension { get; }
        public CellArray (int boardDimension)
        {
            Dimension = boardDimension;
            cells = new Cell[Dimension, Dimension];
            InitializeBoard ();
        }

        private void InitializeBoard ()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    cells[i, j] = new Cell (i, j);
                }
            }
        }

        public Cell this [int row, int col]
        {
            get
            {
                return cells[row, col];
            }
            set
            {
                cells[row, col] = value;
            }
        }
        public Cell[, ] Cells
        {
            get { return cells; }
        }

        public IEnumerable<Cell> Where (Func<Cell, bool> predicate)
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (predicate (cells[i, j]))
                        yield return cells[i, j];
                }
            }
        }
        public IEnumerable<Cell> GetEmpty ()
        {
			var emptyList = new List<Cell>();
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (!(cells[i, j]).HasValue)
						emptyList.Add(cells[i, j]);
                }
            }
			return emptyList;
        }
    }

    public class CellHelper
    {

    }
}