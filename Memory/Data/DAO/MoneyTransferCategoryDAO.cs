using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.DAO
{
    public class MoneyTransferCategoryDAO : BaseModelDAO<MoneyTransferCategory>
    {
        public MoneyTransferCategoryDAO(DataContext context) : base(context)
        {
        }
    }
}
