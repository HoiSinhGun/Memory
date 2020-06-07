using System.Collections.Generic;

namespace Memory.Console.Command.Services
{
    public class ConsoleWriter
    {
        public void ListWrite(List<string> lines)
        {
            foreach (var item in lines)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
