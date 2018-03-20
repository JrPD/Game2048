using System;
using Game2048.Command;
using Game2048.Paint;

namespace Game2048 {
    public class Game {
        private CellArray gameBoard;
        private CommandCreator creator;
        private CommandHandler handler;
        private Painter painter;

        public Game () {

        }

        public Game (CommandCreator creator, CommandHandler handler, Painter painter, int boadrDim) {
            this.painter = painter;
            this.creator = creator;
            this.handler = handler;
            BoardDim = boadrDim;
            gameBoard = new CellArray(BoardDim);
        }

        public int BoardDim { get; internal set; }

        public void Start () {
            while (true) {
                Console.WriteLine ("Enter command: ");
                var value = Console.ReadKey ();

                var cmd = creator.GetCommand (value);
                handler.Board = gameBoard;
                handler.HandleCommand (cmd);
                painter.Draw ();

                Console.WriteLine ("You entered: {value}");
            }
        }
    }


}