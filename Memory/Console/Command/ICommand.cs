using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Console.Command
{
    public interface ICommand
    {
        public string getKey();
        public string getDescription();
        public List<string> getOutputAsList();
    }
}
