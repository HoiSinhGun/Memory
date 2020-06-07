using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.Model
{
    public class Person : BaseModelKey
    {

        public static readonly String ID = "pers";
        public String Name { get; set; }

        public static string GetID()
        {
         return   Person.GetID();
        }
    }
}
