using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Memory.Console.Command
{
    enum Modifier : ushort
    {
        None = 0,
        Create = 1,
        Read = 2,
        Update = 4,
        Delete = 8

    }

    public abstract class BaseCommand<T> : Command.ICommand where T : ICommand
    {
        public static readonly string p_0001 = "1";
        public static readonly string p_0002 = "2";
        public static readonly string p_0003 = "3";
        public static readonly string p_0004 = "4";
        public static readonly string p_0005 = "5";

        public readonly Dictionary<string, string> Options;
        public List<string> Lines = new List<string>();

        protected BaseCommand(Dictionary<string, string> options)
        {
            Options = options;
        }

        public void AddLine(string name)
        {
            Lines.Add(name);
        }

        public abstract string getDescription();
        public abstract string getKey();

        public List<string> getOutputAsList()
        {
            return Lines;
        }

        public Dictionary<string, string> getOptions()
        {
            return Options;
        }

        public static void resolveOptions(T command, Dictionary<string, string> resolveDict)
        {
            foreach (var key in resolveDict.Keys)
            {
                resolveOption(command, key, resolveDict.GetValueOrDefault(key));
            }
        }

        public static void resolveOption(T command, string targetParamName, string numberedParamName)
        {
            Dictionary<string, string> options = command.getOptions();
            string value;
            if (!options.TryGetValue(targetParamName, out value))
            {
                if (options.TryGetValue(numberedParamName, out value))
                {
                    options.Add(targetParamName, value);
                }
            }
        }
    }
}
