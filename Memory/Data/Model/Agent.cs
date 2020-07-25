using Microsoft.Data.Sqlite;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memory.Data.Model
{
        [Table("agent")]
    public class Agent : BaseModelKey
    {
        public static readonly String ID = "agent";

        [Required, Column("Principal_id")]
        public Person Principal { get; set; }
        public String Name { get; set; }

        public static string GetID()
        {
            return ID;
        }

        public override SqliteCommand AddEntityParams(SqliteCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
