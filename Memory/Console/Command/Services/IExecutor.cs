using System.Collections.Generic;

namespace Memory.Console.Command.Services
{
    public interface IExecutor
    {
        public ICommand Execute(ICommand command) ;
        public ICommand NewInstance(Dictionary<string, string> options);
        public bool Handle(string commandString);
    }
}
