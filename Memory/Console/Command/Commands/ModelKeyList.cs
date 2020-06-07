using Memory.Console.Command.Services;
using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Memory.Console.Command.Commands
{
    public class ModelKeyList : BaseCommand<ModelKeyList>
    {

        public static readonly string Key = "ModKey";
        public static readonly string Command = Key + ":" + Modifier.Read;
        public static readonly string Description = "List all final subclasses of BaseModelKey.cs";

        public ModelKeyList(string[] options) : base(options)
        {
        }

        public static ModelKeyList NewInstance() => new ModelKeyList(options: new string[0]);

        public override string getDescription()
        {
            return ModelKeyList.Description;
        }

        public override string getKey()
        {
            return ModelKeyList.Key;
        }
    }

    public class ModelKeyListExe : IExecutor<ModelKeyList>
    {
        private static readonly ModelKeyListExe _Instance = new ModelKeyListExe();

        public static ModelKeyListExe getCurrent()
        {
            return _Instance;
        }

        public ModelKeyList Execute(ModelKeyList command)
        {
            Type parentType = typeof(BaseModelKey);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.IsSubclassOf(parentType));

            command.Lines = new List<String>();
            foreach (Type type in subclasses)
            {
                command.Lines.Add(type.Name);
            }
            return command;
        }
    }
}
