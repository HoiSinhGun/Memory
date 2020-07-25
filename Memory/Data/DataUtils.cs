using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Text;

namespace Memory.Data
{
    public static class DataUtils
    {

        public static SqliteConnection NewDbConnection(DbConnectionMode mode = DbConnectionMode.ReadOnly)
        {
            string dataSource = ConfigurationManager.AppSettings["ADO_Datasource"];
            string baseConnectionString = $"Data Source={dataSource}";
            {
                // Sqllite
                SqliteOpenMode sqliteOpenMode = SqliteOpenMode.ReadOnly;
                switch (mode)
                {
                    case DbConnectionMode.ReadOnly:
                        sqliteOpenMode = SqliteOpenMode.ReadOnly;
                        break;
                    case DbConnectionMode.ReadWrite:
                        sqliteOpenMode = SqliteOpenMode.ReadWrite;
                        break;
                    case DbConnectionMode.ReadWriteCreate:
                        sqliteOpenMode = SqliteOpenMode.ReadWriteCreate;
                        break;
                    default:
                        break;
                }
                var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
                {
                    Mode = sqliteOpenMode
                }.ToString();
                var connection = new SqliteConnection(connectionString);
                return connection;
            }
        }
    }
}

public enum DbConnectionMode
{
    ReadOnly = 0,
    ReadWrite = 1,
    ReadWriteCreate = 2
}

