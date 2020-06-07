using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.Model
{

    public abstract class BaseModel
    {
        public int Id { get; set; }

    }

    public abstract class BaseModelKey : BaseModel
    {
        public String Key { get; set; }
    }
}
