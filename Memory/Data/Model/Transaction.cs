using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.Model
{
    public class Transaction:BaseModel
    {
        public Agent Sender { get; set; }
        public Agent Receiver { get; set; }
        public MoneyTransferCategory MoneyTransferCategory { get; set; }
        public double Amount { get; set; }
        public String Description { get; set; }

    }
}
