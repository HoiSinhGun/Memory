using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Console.Command
{
    public interface ICommand
    {
        public Dictionary<string, string> getOptions();
        public string getKey();
        public string getDescription();
        public List<string> getOutputAsList();
        public void AddLine(string name);
        /**
         * Abort the command, set aborted flag
         **/
        public void Abort(params string[] lines);


    }
}
