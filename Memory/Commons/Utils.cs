using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memory.Commons
{
    public class Utils
    {
        public static Type[] GetDerivedTypes(Type baseType)
        {
            var listOfBs = (
                   from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                       // alternative: from domainAssembly in domainAssembly.GetExportedTypes()
                    from assemblyType in domainAssembly.GetTypes()
                   where baseType.IsAssignableFrom(assemblyType)
                   // WAS: IsAssignableFrom
                   // alternative: where assemblyType.IsSubclassOf(typeof(B))
                   // alternative:
                   && !assemblyType.IsAbstract
                   select assemblyType).ToArray();
            return listOfBs;
        }
    }
}
