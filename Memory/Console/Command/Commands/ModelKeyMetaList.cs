using Memory.Console.Command.Services;
using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Memory.Console.Command.Commands
{
    public class ModelKeyMetaList : BaseCommand<ModelKeyMetaList>
    {

        public static readonly string Key = "ModKeyMetaLi";
        public static readonly string Command = Key;
        public static readonly string Description = "List all final subclasses of BaseModelKey.cs";

        public ModelKeyMetaList(Dictionary<string, string> options) : base(options)
        {
        }

        public override string getDescription()
        {
            return ModelKeyMetaList.Description;
        }

        public override string getKey()
        {
            return ModelKeyMetaList.Key;
        }
    }

    public class ModelKeyMetaListExe : IExecutor
    {

        public ICommand Execute(ICommand command)
        {
            Type parentType = typeof(BaseModelKey);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.IsSubclassOf(parentType));

            foreach (Type type in subclasses)
            {
                command.AddLine(type.Name);
            }
            return command;
        }

        public bool Handle(string commandString)
        {
            return ModelKeyMetaList.Command.ToLower().Equals(commandString.ToLower());
        }

        public ICommand NewInstance(Dictionary<string, string> options)
        {
            return new ModelKeyMetaList(options);
        }
    }
}
