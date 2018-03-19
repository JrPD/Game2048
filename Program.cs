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

            var Board = new int[1, 4];
            Board[0, 0] = 4;
            Board[0, 1] = 8;
            Board[0, 2] = 8;
            Board[0, 3] = 4;
            handler.Board = Board;
            painter.Board = Board;
            handler.HandleCommand (Command.Command.Left);
            painter.Draw ();
            Console.WriteLine();
            
            // handler.HandleCommand (Command.Command.Up);
            // painter.Draw ();
            // Console.WriteLine();

            // handler.HandleCommand (Command.Command.Down);
            // painter.Draw ();
            // Console.WriteLine();

            Console.ReadKey ();

        }
    }

}