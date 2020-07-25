using Memory.Data.Model;
using System;

namespace Memory.Data.DAO
{
    public class PersonDAO : BaseModelDAO<Person>
    {
        public PersonDAO(DataContext context) : base(context)
        {
        }

        public override Type KeyType()
        {
            return typeof(Person);
        }
    }
}
