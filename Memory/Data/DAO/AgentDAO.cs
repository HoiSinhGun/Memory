using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.DAO
{
    public class AgentDAO : BaseModelDAO<Agent>
    {
        public AgentDAO(DataContext context) : base(context)
        {
        }

        public override Type KeyType()
        {
            return typeof(Agent);
        }
    }
}
