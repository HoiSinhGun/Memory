using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public SqliteCommand AddAllParameters(SqliteCommand command)
        {
            command.Parameters.Add("@key", SqliteType.Text).Value = Key;
            return AddEntityParams(command);
        }

        public abstract SqliteCommand AddEntityParams(SqliteCommand command);
    }


}
