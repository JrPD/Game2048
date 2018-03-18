using System;

namespace Game2048.Command
{
        public interface ICommandHandler
    {
        void HandleCommand(Command command);
    }
    public class CommandHandler: ICommandHandler
    {
        public void HandleCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }


}
