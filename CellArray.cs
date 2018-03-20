using System;

namespace Game2048
{
    public class CellArray
    {
        private Cell[,] cells;

        public int Dimension { get; }
        public CellArray(int boardDimension)
        {
            Dimension = boardDimension;
            cells = new Cell[Dimension, Dimension];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    cells[i, j] = new Cell(i,j);
                }
            }
        }

        public Cell this[int row, int col]
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
    }

    public class Cell : IComparable<Cell>
    {
        public int Value;
        public int X;
        public int Y;

        public Cell()
        {
        }

        public Cell(int i, int j)
        {
            X = i;
            Y = j;
        }

        public int CompareTo(Cell that)
        {
            if (this.Value > that.Value) return -1;
            if (this.Value == that.Value) return 0;
            return 1;
        }
        public bool HasValue
        {
            get
            {
                return Value > 0;
            }
        }

        public void SetEmpty()
        {
            Value = 0;
        }
    }
}