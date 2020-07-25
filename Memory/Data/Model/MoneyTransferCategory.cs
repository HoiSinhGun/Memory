using Microsoft.Data.Sqlite;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memory.Data.Model
{
    [Table("Money_Transfer_Category")]
    public class MoneyTransferCategory : BaseModelKey
    {
        public static readonly String ID = "moneyTransferCategory";

        public String Description { get; set; }

        public static String GetID()
        {
            return ID;
        }

        public override SqliteCommand AddEntityParams(SqliteCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
