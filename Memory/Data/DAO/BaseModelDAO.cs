using Memory.Data.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Data.DAO
{
    // @TODOGUN: T:BaseModel and IModelKeyDAO ... seems to be erroneous
    public abstract class BaseModelDAO<T> : IModelKeyDAO where T : BaseModel
    {
        private readonly DataContext _context;

        public BaseModelDAO(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Add(BaseModelKey baseModelKey)
        {
            var connection = DataUtils.NewDbConnection(DbConnectionMode.ReadWriteCreate);
            try
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                baseModelKey.AddAllParameters(cmd);
                var columns = new StringBuilder();
                var values = new StringBuilder();
                bool first = true;
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
            //ConfigurationManager.ConnectionStrings
        }

        public void AddAll(IEnumerable<T> entityList)
        {
            _context.AddRange(entityList);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(p => p.Id == id);
            return entity;
        }

        public abstract Type KeyType();
    }
}
