using Memory.Bridges;
using Memory.Console.Command.Services;
using Memory.Data.DAO;
using Memory.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private ServicesProviderBridge ServicesProviderBridge;

        public ModelKeyAddExe(ServicesProviderBridge servicesProviderBridge)
        {
            ServicesProviderBridge = servicesProviderBridge;
        }

        public ICommand Execute(ICommand command)
        {
            foreach (var key in command.getOptions().Keys)
            {
                command.getOptions().TryGetValue(key, out string value);
                command.AddLine($"{key}={value}");
            }
            // - need: entity type, key, other properties (as JSON?)
            // Entity instance from entityID
            command.getOptions().TryGetValue(ModelKeyAdd.p_entity, out string entityID);
            var baseModelKey = ModelUtils.NewEntityInstance(entityID);
            if(baseModelKey == null)
            {
                // exit command, user input invalid
                command.Abort($"Unknown entityID: {entityID}");
                return command;
            }
            // Set entity key
            command.getOptions().TryGetValue(ModelKeyAdd.p_entity_key, out string entityKey);
            baseModelKey.Key = entityKey;
            // @TODO_GUN: Set other properties
            // Persist: get persistence services and persist it
            ServicesProviderBridge._modelKeyDAODict.TryGetValue(baseModelKey.GetType(), out IModelKeyDAO modelKeyDAO);
            modelKeyDAO.Add(baseModelKey);
            return command;
        }

        public bool Handle(string commandString)
        {
            return ModelKeyAdd.Command.ToLower().Equals(commandString.ToLower());
        }

        public ICommand NewInstance(Dictionary<string, string> options)
        {
            ModelKeyAdd modelKeyAdd = new ModelKeyAdd(options);

            var optionResolveDict = new Dictionary<string, string>() {
                {ModelKeyAdd.p_entity,ModelKeyAdd.p_0001 },
                {ModelKeyAdd.p_entity_key, ModelKeyAdd.p_0002 } 
            };
            ModelKeyAdd.resolveOptions(modelKeyAdd, optionResolveDict);

            return modelKeyAdd;
        }
    }
}
