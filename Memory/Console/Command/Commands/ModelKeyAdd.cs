using Memory.Console.Command.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Memory.Console.Command.Commands
{
    public class ModelKeyAdd : BaseCommand<ModelKeyAdd>
    {

        public static readonly string Key = "ModKey";
        public static readonly string Command = Key + ":" + (long)Modifier.Create;
        public static readonly string Description = "Create in DB an entity of type BaseModelKey.cs";
        public static readonly string p_entity = "entity";
        public static readonly string p_entity_key = "entity_key";

        public ModelKeyAdd(Dictionary<string, string> options) : base(options)
        {
        }

        public static ModelKeyAdd NewInstance() => new ModelKeyAdd(options: new Dictionary<string, string>());

        public override string getDescription()
        {
            return ModelKeyAdd.Description;
        }

        public override string getKey()
        {
            return ModelKeyAdd.Key;
        }
    }

    public class ModelKeyAddExe : IExecutor
    {

        public ICommand Execute(ICommand command)
        {
            command.getOptions();
            // - need: entity type, key, other properties (as JSON?)
            return command;
        }

        public bool Handle(string commandString)
        {
            return ModelKeyMetaList.Command.ToLower().Equals(commandString.ToLower());
        }

        public ICommand NewInstance(Dictionary<string, string> options)
        {
            ModelKeyAdd modelKeyAdd = new ModelKeyAdd(options);

            var optionResolveDict = new Dictionary<string, string>() {
                {ModelKeyAdd.p_entity,ModelKeyAdd.p_0001 },
                {ModelKeyAdd.p_entity_key, ModelKeyAdd.p_0001 } 
            };
            ModelKeyAdd.resolveOptions(modelKeyAdd, optionResolveDict);
            BaseCommand<ICommand>.resolveOption(modelKeyAdd, ModelKeyAdd.p_entity, BaseCommand<ICommand>.p_0001);
            BaseCommand<ICommand>.resolveOption(modelKeyAdd, ModelKeyAdd.p_entity_key, BaseCommand<ICommand>.p_0002);

            return modelKeyAdd;
        }
    }
}
