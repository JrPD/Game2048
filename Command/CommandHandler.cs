using System;

namespace Game2048.Command {
    public interface ICommandHandler {
        void HandleCommand (Command command);
    }
    public class CommandHandler : ICommandHandler {
        public int[, ] Board { get; internal set; }

        public void HandleCommand (Command command) {
            switch (command) {
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

        private void HandleRight () {
            throw new NotImplementedException ();
        }

        private void HandleLeft () {
            throw new NotImplementedException ();
        }

        private void HandleDown () {
            for (int j = 0; j <Board.GetLength(0); j++) {
                for (int i = Board.GetLength (1) - 1; i >= 0; i--) {
                    if (Board[i, j] != 0 && Board[i, j] == Board[i - 1, j]) {
                        Board[i, j] = Board[i - 1, j] * 2;
                        Board[i - 1, j] = 0;
                    }
                }
                MoveDown (j);
            }
        }

        private void HandleUp () {
            for (int j = 0; j < Board.GetLength (0) - 1; j++) {
                for (int i = 0; i < Board.GetLength (1) - 1; i++) {
                    if (Board[i, j] != 0 && Board[i, j] == Board[i + 1, j]) {
                        Board[i, j] = Board[i + 1, j] * 2;
                        Board[i + 1, j] = 0;
                    }
                }
                MoveUp (j);
            }
        }

        private void MoveUp (int col) {
            for (int i = 0; i < Board.GetLength (0); i++) {
                if (Board[i, col] == 0) {
                    continue;
                }
                MoveToTop (i, col);
            }
        }
        private void MoveDown (int col) {
            for (int i =Board.GetLength (0)-1; i >= 0; i--) {
                if (Board[i, col] == 0) {
                    continue;
                }
                MoveToDown (i, col);
            }
        }

        private void MoveToTop (int i, int col) {
            while (i > 0 && Board[i - 1, col] == 0) {
                Board[i - 1, col] = Board[i, col];
                Board[i, col] = 0;
                i--;
            }
        }

        private void MoveToDown (int i, int col) {
            while (i < Board.GetLength (0)-1 && Board[i+1, col] == 0) {
                Board[i+1, col] = Board[i, col];
                Board[i, col] = 0;
                i++;
            }
        }
    }
}