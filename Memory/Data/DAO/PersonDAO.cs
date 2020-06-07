using Memory.Data.Model;

namespace Memory.Data.DAO
{
    public class PersonDAO : BaseModelDAO<Person>
    {
        public PersonDAO(DataContext context) : base(context)
        {
        }
    }
}
