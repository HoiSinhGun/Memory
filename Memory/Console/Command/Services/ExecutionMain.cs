using Memory.Console.Command.Commands;
using System;
using System.Collections.Generic;

namespace Memory.Console.Command.Services
{
    public class ExecutionMain
    {
        private readonly ConsoleWriter _consoleWriter;

        public List<ICommand> History { get; set; } = new List<ICommand>();

        public ExecutionMain(ConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void Execute(String userInput)
        {
            Command.Commands.ModelKeyList command = new Command.Commands.ModelKeyList(new string[0]);
            Command.Commands.ModelKeyListExe.getCurrent().Execute(command: command);
            _consoleWriter.ListWrite(command.getOutputAsList());
            History.Add(command);
        }
    }
}
