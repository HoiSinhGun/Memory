using Memory.Commons;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Memory.Data.Model
{
    public class ModelUtils
    {
        public static readonly Dictionary<String, Type> entityDict = new Dictionary<string, Type>();

        public static Dictionary<String, Type> GetEntityDict()
        {
            if (entityDict.Count != 0)
                return entityDict;

            Type[] allEntityTypes = Utils.GetDerivedTypes(typeof(BaseModelKey));
            foreach (var entityType in allEntityTypes)
            {
                System.Reflection.MethodInfo methodGetID 
                    = entityType.GetMethod("getID", System.Reflection.BindingFlags.Static);
                if (methodGetID == null)
                {
                    System.Reflection.MethodInfo[] methodInfo = entityType.GetMethods();
                    foreach (var method in methodInfo)
                    {
                        if (!method.IsStatic)
                            continue;
                        if (method.Name.Equals("GetID"))
                            methodGetID = method;
                    }
                    
                }
                string entityID = Convert.ToString(methodGetID.Invoke(null, new object[] { }));
                entityDict.Add(entityID, entityType);
            }

            return entityDict;
        }

        public static BaseModelKey NewEntityInstance(String entityID)
        {
            GetEntityDict().TryGetValue(entityID, out Type entityType);
            if (entityType == null)
                // log? This change is required because at the moment userInput is passed through until here!
                // Have to validate user input, this method should not be called with unsupported entityID
                // throw new NotSupportedException($"No entityType found for {entityID}!");
                return null;

            System.Reflection.ConstructorInfo entityConstructor = entityType.GetConstructor(Type.EmptyTypes);
            object entity = entityConstructor.Invoke(new object[] { });
            return (BaseModelKey)entity;
        }
    }
}
