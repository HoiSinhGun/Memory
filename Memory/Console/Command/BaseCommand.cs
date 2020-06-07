using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Memory.Console.Command
{
    enum Modifier:ushort
    {
        None = 0,
        Create = 1,
        Read = 2,
        Update = 4,
        Delete = 8
    }

    public abstract class BaseCommand<T> : ICommand where T:BaseCommand<T>
    {
        public string[] Options;
        public List<string> Lines = new List<string>();

        protected BaseCommand(string[] options)
        {
            Options = options;
        }

        public abstract string getDescription();
        public abstract string getKey();
       
        public List<string> getOutputAsList()
        {
            return Lines;
        }
    }
}
