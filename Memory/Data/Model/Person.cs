using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Memory.Data.Model
{
    [Table("person")]
    public class Person : BaseModelKey
    {

        public static readonly String ID = "person";
        public String Name { get; set; }

        public static string GetID()
        {
            return ID;
        }

        public override SqliteCommand AddEntityParams(SqliteCommand command)
        {
            command.Parameters.Add("@name", SqliteType.Text).Value = Name == null ? "":Name;
            return command;
        }
    }
}
