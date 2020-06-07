using System;
using System.Collections.Generic;

namespace Memory.Console.Command
{
    public  class CommandsContext
    {
        public static CommandsContext Current { get; set; } = new CommandsContext();
        public static readonly Dictionary<String, ICommand> CommandMap = new Dictionary<String, ICommand>();

        public Dictionary<String, ICommand> MyCommandMap = CommandMap;
    }
}
