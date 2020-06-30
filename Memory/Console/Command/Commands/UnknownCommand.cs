using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Console.Command.Commands
{
    public class UnknownCommand : BaseCommand<UnknownCommand>
    {

        public static readonly string Description = "Command not resolved, it is unkown";

        public UnknownCommand(Dictionary<string,string> options) : base(options)
        {
        }


        public override string getDescription()
        {
            return Description;
        }

        public override string getKey()
        {
            throw new NotImplementedException();
        }

    }

    public class UnknownCommandExe : Memory.Console.Command.Services.IExecutor
    {
        public static UnknownCommandExe instance = new UnknownCommandExe();

        public ICommand Execute(ICommand command)
        {
            command.AddLine("Command unknown!");
            return command;
        }

        public bool Handle(string commandString)
        {
            throw new NotImplementedException();
        }

        public ICommand NewInstance(Dictionary<string, string> options)
        {
            return new UnknownCommand(options);
        }
    }
}
