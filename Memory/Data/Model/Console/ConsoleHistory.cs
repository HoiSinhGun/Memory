using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Data.Model.Console
{
    class ConsoleHistory : BaseModel
    {
        public DateTime Timestamp { get; set; }
        public String UserInput { get; set; }
        public String Output { get; set; }
    }
}
