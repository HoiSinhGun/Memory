using Memory.Bridges;
using Memory.Console.Command.Commands;
using System;
using System.Collections.Generic;

namespace Memory.Console.Command.Services
{
    public class ExecutionMain
    {
        private readonly ConsoleWriter _consoleWriter;
        private readonly ServicesProviderBridge _servicesProviderBridge;


        public ExecutionMain(ConsoleWriter consoleWriter, ServicesProviderBridge servicesProviderBridge)
        {
            _consoleWriter = consoleWriter;
            _servicesProviderBridge = servicesProviderBridge;
        }

        public Command.ICommand Execute(String userInput)
        {
            string[] userInputSplit = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandString = userInputSplit[0];

            // Test for ModKey:1 person me. Strings accordingly.
            // The strings stand for Command Entity Key
            // Entity and Key always necessary for ModKey:1
            var cliArgDict = new Dictionary<string, string>();
            var countUnnamedParam = 0;
            foreach (var arg in userInputSplit)
            {
                string[] argSplit = arg.Split("=");
                if (argSplit.Length == 0)
                    continue;
                if (argSplit.Length == 1)
                {
                    if (countUnnamedParam == 0)
                        cliArgDict.Add("command", argSplit[0]);
                    else
                        // support sth like: "command", "ModKey:1" / "entity", "pers", ...
                        cliArgDict.Add(countUnnamedParam.ToString(), argSplit[0]);
                    countUnnamedParam++;
                }
                if (argSplit.Length == 2)
                    cliArgDict.Add(argSplit[0], argSplit[1]);
                if (argSplit.Length > 2)
                    throw new InvalidOperationException();
            }

            IExecutor executor
                = _servicesProviderBridge.GetCommandExecutorFor(commandString);

            ICommand command = executor.NewInstance(cliArgDict);
                executor.Execute(command);
            
            _consoleWriter.ListWrite(command.getOutputAsList());
            return command;
        }
    }
}
