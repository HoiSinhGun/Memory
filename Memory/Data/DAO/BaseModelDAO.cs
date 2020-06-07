using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Data.DAO
{
    public abstract class BaseModelDAO<T> where T:BaseModel
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
    }
}
