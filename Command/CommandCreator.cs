using System;

namespace Game2048.Command
{
    interface ICommandCreator{
        Command GetCommand(ConsoleKeyInfo cmd);
    }
        public class CommandCreator: ICommandCreator
    {

        public CommandCreator()
        {
        }
        public Command GetCommand(ConsoleKeyInfo cmd)
        {
            switch (cmd.Key)
            {
                case ConsoleKey.LeftArrow:
                    return Command.Left;
                case ConsoleKey.RightArrow:
                    return Command.Right;
                case ConsoleKey.UpArrow:
                    return Command.Up;
                case ConsoleKey.DownArrow:
                    return Command.Down;
                default:
                    return Command.Empty;
            }
        }
    }
}
