using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Memory.Console.Command.Services
{
    class ConsoleHistoryServices
    {
        public readonly int HistoryItemsMaxCount = 10;

        public List<string> AddLines(List<string> consoleHistory, params string[] lines)
        {
            foreach (var line in lines)
            {
                consoleHistory.Insert(0, line);
                if (consoleHistory.Count > HistoryItemsMaxCount)
                {
                    consoleHistory.RemoveRange(HistoryItemsMaxCount, consoleHistory.Count - HistoryItemsMaxCount);
                }
            }
            return consoleHistory;
        }

        /*
         * Call also AddLine, if params not null (maybe not so good, design?)
         * 
         */
        public List<string> Persist(List<string> history, params string[] lines)
        {
            this.AddLines(history, lines);
            /// Write to file here
            return history;
        }

        public List<string> Read()
        {
            List<string> history = new List<string>();
            // read from file
            return history;
        }
    }
}
