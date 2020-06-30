using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.Model
{
    public class Agent : BaseModelKey
    {
        public Person Principal { get; set; }
        public String Name { get; set; }
    }
}
