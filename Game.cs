using System;
using Game2048.Command;
using Game2048.Paint;

namespace Game2048
{
    public class Game
    {
        private Array gameState = new Array[4,4];
        private CommandCreator creator;
        private CommandHandler handler;
        private Painter painter;

        public Game()
        {

        }

        public Game(CommandCreator creator, CommandHandler handler, Painter painter)
        {
            this.painter = painter;
            this.creator = creator;
            this.handler = handler;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Enter command: ");
                var value = Console.ReadKey();

                var cmd = creator.GetCommand(value);
                handler.HandleCommand(cmd);
                painter.Draw();

                Console.WriteLine("You entered: {value}");
            }
        }
    }
}
