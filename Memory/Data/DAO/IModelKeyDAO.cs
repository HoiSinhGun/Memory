using Memory.Data.Model;
using System;

namespace Memory.Data.DAO
{
    public interface IModelKeyDAO
    {
        public void Add(BaseModelKey baseModelKey);

        public Type KeyType();
    }
}
