using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Console
{
    class VariablesContext
    {
        public static VariablesContext Current { get; set; } = new VariablesContext();
        public static readonly Dictionary<String, Person> PersonMap = new Dictionary<String, Person>();
        public Dictionary<String, Person> MyPersonMap { get; set; } = VariablesContext.PersonMap;
            
    }
}
