using System;

namespace Game2048.Command
{
    public interface ICommandHandler
    {
        void HandleCommand(Command command);
    }
    public class CommandHandler : ICommandHandler
    {
        public int[,] Board { get; internal set; }

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

        private void HandleUp()
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                SummarizeRowValuesUp(j);
                MoveUpRowValues(j);
            }
        }
        private void SummarizeRowValuesUp(int j)
        {
            for (int i = 0; i < Board.GetLength(0) - 2; i++)
            {
                AddVerticalCells(j, i, true);
            }
        }

        private void MoveUpRowValues(int col)
        {
            int empty = -1;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                CheckEmptyAndSwipe(col, ref empty, i, true, true);
            }
        }
        private void HandleDown()
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                SummarizeRowValuesDown(j);
                MoveDownRowValues(j);
            }
        }
        private void SummarizeRowValuesDown(int j)
        {
            for (int i = Board.GetLength(0) - 1; i > 0; i--)
            {
                AddVerticalCells(j, i, false);
            }
        }
        private void MoveDownRowValues(int col)
        {
            int empty = -1;

            for (int i = Board.GetLength(0) - 1; i >= 0; i--)
            {
                CheckEmptyAndSwipe(col, ref empty, i, false, false);
            }
        }
        private void HandleRight()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                SummarizeRowValuesRight(i);
                MoveRightRowValues(i);
            }
        }
        private void SummarizeRowValuesRight(int i)
        {
            for (int j = Board.GetLength(1) - 1; j > 0; j--)
            {
                AddHorizontalCells(i, j, false);
            }
        }
        private void MoveRightRowValues(int col)
        {
            int empty = -1;

            for (int j = Board.GetLength(1) - 1; j >= 0; j--)
            {
                CheckEmptyAndSwipe(col, ref empty, j, false, true);
            }
        }
        private void HandleLeft()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                SummarizeRowValuesLeft(i);
                MoveLeftRowValues(i);
            }
        }
        private void SummarizeRowValuesLeft(int i)
        {
            for (int j = 0; j < Board.GetLength(1) - 1; j++)
            {
                AddHorizontalCells(i, j, true);
            }
        }

        private void MoveLeftRowValues(int col)
        {
            int empty = -1;

            for (int j = 0; j < Board.GetLength(1); j++)
            {
                CheckEmptyAndSwipe(j, ref empty, col, true, true);
            }
        }

        private void AddHorizontalCells(int i, int j, bool right)
        {
            int direction = right ? 1 : -1;

            if (Board[i, j] != 0 && Board[i, j] == Board[i, j + 1 * direction])
            {
                Board[i, j] = Board[i, j + 1 * direction] * 2;
                Board[i, j + 1 * direction] = 0;
            }
        }

        private void AddVerticalCells(int j, int i, bool up)
        {
            int direction = up ? 1 : -1;

            if (Board[i, j] != 0 && Board[i, j] == Board[i + 1 * direction, j])
            {
                Board[i, j] = Board[i + 1 * direction, j] * 2;
                Board[i + 1 * direction, j] = 0;
            }
        }

        private void CheckEmptyAndSwipe(int col, ref int empty, int row, bool up, bool horizontal)
        {
            if (Board[row, col] == 0 && empty < 0)
            {
                empty = horizontal ? col : row;
                return;
            }
            if (empty >= 0 && Board[row, col] != 0)
            {
                // TODO fix issue when swipe right/left
                Swipe(row, col, empty, col);
                empty = up ? empty + 1 : empty - 1;
            }
        }

        public void Swipe(int i, int col1, int empty, int col2)
        {
            var temp = Board[empty, col2];
            Board[empty, col2] = Board[i, col1];
            Board[i, col1] = temp;
        }

    }
}