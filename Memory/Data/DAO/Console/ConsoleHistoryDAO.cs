using Memory.Data.Model.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.DAO.Console
{
    class ConsoleHistoryDAO
    {
        public void create(ConsoleHistory consoleHistory)
        {
            if (consoleHistory.Timestamp == null)
                consoleHistory.Timestamp = DateTime.Now;
            var connection = DataUtils.NewDbConnection(DbConnectionMode.ReadWriteCreate);
            try
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.Parameters.Add()
                foreach (SqliteParameter param in cmd.Parameters)
                {
                    if (!first)
                    {
                        columns.Append(", ");
                        values.Append(", ");
                    }
                    columns.Append($"'{param.ParameterName.Replace("@", "")}'");
                    values.Append($"{param.ParameterName}");
                    first = false;
                }
                // @TODO: toLower only first character
                cmd.CommandText = $"INSERT INTO {baseModelKey.GetType().Name.ToLower()} " +
                    $"({columns}) " +
                    $"VALUES ({values});";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // @TODO values must be set
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
