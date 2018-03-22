using System;

namespace Game2048.Command
{
    public interface ICommandHandler
    {
        void HandleCommand(Command command);
    }
    public class CommandHandler : ICommandHandler
    {
        public CommandHandler() { }
        public CellArray Board { get; internal set; }
        public Paint.Painter Painter { get; internal set; }

        public void HandleCommand(Command command)
        {
            switch (command)
            {
                case Command.Up:
                    HandleUp();
                    break;
                case Command.Down:
                    HandleDown();
                    break;
                case Command.Left:
                    HandleLeft();
                    break;
                case Command.Right:
                    HandleRight();
                    break;
            }
        }
        #region UP

        private void HandleUp()
        {
            Console.WriteLine("Start handle UP");
            for (int j = 0; j < Board.Dimension; j++)
            {
                Console.WriteLine("Summarize row:" + j);
                SummarizeRowValuesUp(j);

                Console.WriteLine("Move row:" + j);
                MoveUpRowValues(j);
                Painter.Draw();
            }
            Console.WriteLine("End handle  UP");
        }
        private void SummarizeRowValuesUp(int j)
        {
            for (int i = 0; i < Board.Dimension - 1; i++)
            {
                AddVerticalCells(j, ref i, true);
                Painter.Draw();
            }
        }

        private void MoveUpRowValues(int col)
        {
            int empty = -1;
            for (int i = 0; i < Board.Dimension; i++)
            {
                CheckEmptyAndSwipe(col, ref empty, i, true, false);
                Painter.Draw();
            }
        }
        #endregion
       
        #region DOWN
        private void HandleDown()
        {
            Console.WriteLine("Start handle down");
            for (int j = 0; j < Board.Dimension; j++)
            {
                Console.WriteLine("Summarize row:" + j);
                SummarizeRowValuesDown(j);
                Console.WriteLine("Move row:" + j);
                MoveDownRowValues(j);
            }
            Console.WriteLine("End handle down");
        }
        private void SummarizeRowValuesDown(int j)
        {
            for (int i = Board.Dimension - 1; i > 0; i--)
            {
                AddVerticalCells(j, ref i, false);
                Painter.Draw();
            }
        }
        private void MoveDownRowValues(int col)
        {
            int empty = -1;

            for (int i = Board.Dimension - 1; i >= 0; i--)
            {
                CheckEmptyAndSwipe(col, ref empty, i, false, false);
                Painter.Draw();

            }
        }
        #endregion
       
        #region RIGHT
        private void HandleRight()
        {
            Console.WriteLine("Start handle right");
            for (int i = 0; i < Board.Dimension; i++)
            {
                Console.WriteLine("Summarize column:" + i);
                SummarizeRowValuesRight(i);
                Console.WriteLine("Move column:" + i);
                MoveRightRowValues(i);
            }
            Console.WriteLine("End handle right");
        }
        private void SummarizeRowValuesRight(int i)
        {
            for (int j = Board.Dimension - 1; j > 0; j--)
            {
                AddHorizontalCells(i, ref j, false);
                Painter.Draw();
            }
        }
        private void MoveRightRowValues(int row)
        {
            int empty = -1;

            for (int j = Board.Dimension - 1; j >= 0; j--)
            {
                CheckEmptyAndSwipe(j, ref empty, row, false, true);
                Painter.Draw();

            }

        }
        #endregion
       
        #region LEFT
        private void HandleLeft()
        {
            Console.WriteLine("Start handle left");
            for (int i = 0; i < Board.Dimension; i++)
            {
                Console.WriteLine("Summarize column:" + i);
                SummarizeRowValuesLeft(i);

                Console.WriteLine("Move column:" + i);
                MoveLeftRowValues(i);
            }
            Console.WriteLine("End handle left");

        }
        private void SummarizeRowValuesLeft(int i)
        {
            for (int j = 0; j < Board.Dimension - 1; j++)
            {
                AddHorizontalCells(i, ref j, true);
                Painter.Draw();

            }
        }

        private void MoveLeftRowValues(int row)
        {
            int empty = -1;

            for (int j = 0; j < Board.Dimension; j++)
            {
                CheckEmptyAndSwipe(j, ref empty, row, true, true);
                Painter.Draw();
            }
        }
        #endregion

        #region Methods
        private void AddHorizontalCells(int row, ref int col, bool up)
        {
            int k = 0;
            var next = col + 1 * (up ? 1 : -1);

            // find next not null cell
            while (!Board[row, next + k].HasValue && (next + k != 0) && (next + k != Board.Dimension - 1))
            {
                k = up ? k + 1 : k - 1;
            }

            // add cells values, clear second
            if (Board[row, col].HasValue && Board[row, col] == Board[row, next + k])
            {
                Board[row, col].Value = Board[row, next + k].Value * 2;
                Board[row, next + k].SetEmpty();
                col++;
            }
            // move through empty cells
            col += k;
        }

        private void AddVerticalCells(int col, ref int row, bool up)
        {
            int k = 0;
            var next = row + 1 * (up ? 1 : -1);

            // find next not null cell
            while (!Board[next + k, col].HasValue && (next + k != 0) && (next + k != Board.Dimension - 1))
            {
                k = up ? k + 1 : k - 1;
            }

            // add cells values, clear second
            if (Board[row, col].HasValue && Board[row, col] == Board[next + k, col])
            {
                Board[row, col].Value = Board[next + k, col].Value * 2;
                Board[next + k, col].SetEmpty();
                row++;
            }
            // move through empty cells
            row += k;
        }

        private void CheckEmptyAndSwipe(int col, ref int empty, int row, bool up, bool horizontal)
        {
            if (!Board[row, col].HasValue && empty < 0)
            {
                empty = horizontal ? col : row;
                // return if empty
                return;
            }
            if (empty >= 0 && Board[row, col].HasValue)
            {
                Swipe(row, col, horizontal ? row : empty, horizontal ? empty : col);
                empty = up ? empty + 1 : empty - 1;
            }
        }

        public void Swipe(int row1, int col1, int row2, int col2)
        {
            var temp = Board[row2, col2].Value;
            Board[row2, col2].Value = Board[row1, col1].Value;
            Board[row1, col1].Value = temp;
        }
        #endregion
    }
}