using System;

namespace Game2048.Command
{
    public interface ICommandHandler
    {
        void HandleCommand (Command command);
    }
    public class CommandHandler : ICommandHandler
    {
        public CommandHandler () { }
        public CellArray Board { get; internal set; }
        public Paint.Painter Painter { get; internal set; }

        public void HandleCommand (Command command)
        {
            switch (command)
            {
                case Command.Up:
                    HandleUp ();
                    break;
                case Command.Down:
                    HandleDown ();
                    break;
                case Command.Left:
                    HandleLeft ();
                    break;
                case Command.Right:
                    HandleRight ();
                    break;
            }
        }

        private void HandleUp ()
        {
            Console.WriteLine ("Start handle up");
            for (int j = 0; j < Board.Dimension; j++)
            {
                Console.WriteLine ("Summarize column:" + j);
                SummarizeRowValuesUp (j);
                Console.WriteLine ("Move column:" + j);
                MoveUpRowValues (j);
                Painter.Draw ();
            }
            Console.WriteLine ("End handle  ");
        }
        private void SummarizeRowValuesUp (int j)
        {
            for (int i = 0; i < Board.Dimension - 1; i++)
            {
                AddVerticalCells (j, ref i, true);
                Painter.Draw ();
            }
        }

        private void MoveUpRowValues (int col)
        {
            int empty = -1;
            for (int i = 0; i < Board.Dimension; i++)
            {
                CheckEmptyAndSwipe (col, ref empty, i, true, false);
                Painter.Draw ();
            }
        }
        private void HandleDown ()
        {
            Console.WriteLine ("Start handle down");
            for (int j = 0; j < Board.Dimension; j++)
            {
                Console.WriteLine ("Summarize column:" + j);
                SummarizeRowValuesDown (j);
                Console.WriteLine ("Move column:" + j);
                MoveDownRowValues (j);
            }
            Console.WriteLine ("End handle down");
        }
        private void SummarizeRowValuesDown (int j)
        {
            for (int i = Board.Dimension - 1; i > 0; i--)
            {
                AddVerticalCells (j, ref i, false);
            }
        }
        private void MoveDownRowValues (int col)
        {
            int empty = -1;

            for (int i = Board.Dimension - 1; i >= 0; i--)
            {
                CheckEmptyAndSwipe (col, ref empty, i, false, false);
            }
        }
        private void HandleRight ()
        {
            Console.WriteLine ("Start handle right");
            for (int i = 0; i < Board.Dimension; i++)
            {
                Console.WriteLine ("Summarize column:" + i);
                SummarizeRowValuesRight (i);
                Console.WriteLine ("Move column:" + i);
                MoveRightRowValues (i);
            }
            Console.WriteLine ("End handle right");
        }
        private void SummarizeRowValuesRight (int i)
        {
            for (int j = Board.Dimension - 1; j > 0; j--)
            {
                AddHorizontalCells (i, ref j, false);
                Painter.Draw ();
            }
        }
        private void MoveRightRowValues (int row)
        {
            int empty = -1;

            for (int j = Board.Dimension - 1; j >= 0; j--)
            {
                CheckEmptyAndSwipe (j, ref empty, row, false, true);
                Painter.Draw ();

            }

        }
        private void HandleLeft ()
        {
            Console.WriteLine ("Start handle left");
            for (int i = 0; i < Board.Dimension; i++)
            {
                Console.WriteLine ("Summarize column:" + i);
                SummarizeRowValuesLeft (i);

                Console.WriteLine ("Move column:" + i);
                MoveLeftRowValues (i);
            }
            Console.WriteLine ("End handle left");

        }
        private void SummarizeRowValuesLeft (int i)
        {
            for (int j = 0; j < Board.Dimension - 1; j++)
            {
                AddHorizontalCells (i, ref j, true);
                Painter.Draw ();

            }
        }

        private void MoveLeftRowValues (int row)
        {
            int empty = -1;

            for (int j = 0; j < Board.Dimension; j++)
            {
                CheckEmptyAndSwipe (j, ref empty, row, true, true);
                Painter.Draw ();

            }
        }

        private void AddHorizontalCells (int row, ref int col, bool left)
        {
            int direction = left ? 1 : -1;
            int k = 0;
            Console.WriteLine (string.Format ("{0} {1}", Board[row, col].Value, Board[row, col + 1 * direction + k].Value));
            while (!Board[row, col + 1 * direction + k].HasValue && row < Board.Dimension)
            {
                k = left? k + 1 : k - 1;
                if (col + 1 * direction + k < 0 || col + 1 * direction + k > Board.Dimension - 1)
                {
                    k = 0;
                    break;
                }
            }
            if (Board[row, col].HasValue && Board[row, col] == Board[row, col + 1 * direction + k])
            {
                Board[row, col].Value = Board[row, col + 1 * direction + k].Value * 2;
                Board[row, col + 1 * direction + k].SetEmpty ();
            }
            col += k;
        }

        private void AddVerticalCells (int j, ref int i, bool up)
        {
            int direction = up ? 1 : -1;
            int k = 0;
            while (!Board[i + 1 * direction + k, j].HasValue && i < Board.Dimension)
            {
                k = up? k + 1 : k - 1;
                if (i + 1 * direction + k < 0 || i + 1 * direction + k > Board.Dimension - 1)
                {
                    k = 0;
                    break;
                }
            }
            if (Board[i, j].HasValue && Board[i, j] == Board[i + 1 * direction + k, j])
            {
                Board[i, j].Value = Board[i + 1 * direction + k, j].Value * 2;
                Board[i + 1 * direction + k, j].SetEmpty ();
            }
            i += k;
        }

        private void CheckEmptyAndSwipe (int col, ref int empty, int row, bool up, bool horizontal)
        {
            if (!Board[row, col].HasValue && empty < 0)
            {
                empty = horizontal ? col : row;
                return;
            }
            if (empty >= 0 && Board[row, col].HasValue)
            {
                Swipe (row, col, horizontal ? row : empty, horizontal ? empty : col);
                empty = up ? empty + 1 : empty - 1;
            }
        }

        public void Swipe (int i, int col1, int empty, int col2)
        {
            var temp = Board[empty, col2].Value;
            Board[empty, col2].Value = Board[i, col1].Value;
            Board[i, col1].Value = temp;
        }

    }
}