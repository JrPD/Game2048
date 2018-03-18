using System;
using System.Collections.Generic;
using Game2048.Command;
using Game2048.Paint;

namespace Game2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var creator = new CommandCreator();
            var handler = new CommandHandler();
            var painter = new Painter();

            var game = new Game(creator, handler, painter);
            game.Start();
        }
    }


}
