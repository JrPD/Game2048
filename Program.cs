using System;
using System.Collections.Generic;
using Game2048.Command;
using Game2048.Paint;

namespace Game2048 {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            var creator = new CommandCreator ();
            var handler = new CommandHandler ();
            var painter = new Painter ();
            var boadrDim = 4;
            var game = new Game (creator, handler, painter, boadrDim);
            // game.Start();

            var Board = new CellArray (boadrDim);
            handler.Board = Board;
            painter.Board = Board;
            handler.Painter = painter;
            TestLeft (creator, handler, painter, boadrDim, Board);

            Console.ReadKey (true);

        }

        private static void TestLeft (CommandCreator creator, CommandHandler handler, Painter painter, int boadrDim, CellArray Board) {
            Board[0, 0].Value = 4;
            Board[1, 0].Value = 8;
            Board[2, 0].Value = 16;
            Board[3, 0].Value = 0;

            Board[0, 1].Value = 4;
            Board[1, 1].Value = 8;
            Board[2, 1].Value = 0;
            Board[3, 1].Value = 32;

            Board[0, 2].Value = 8;
            Board[1, 2].Value = 8;
            Board[2, 2].Value = 0;
            Board[3, 2].Value = 32;

            Board[0, 3].Value = 8;
            Board[1, 3].Value = 8;
            Board[2, 3].Value = 16;
            Board[3, 3].Value = 0;

            handler.HandleCommand (Command.Command.Down);
            painter.Draw ();
            Console.WriteLine ();
        }

    }

}