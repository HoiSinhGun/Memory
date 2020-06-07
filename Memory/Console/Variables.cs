using Memory.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memory.Console
{
    public static class Variables
    {
        public const String Me = "Me";
        public const String Other = "Other";

        public static Person GetMe()
        {
            return VariablesContext.Current.MyPersonMap[Me];
        }
    }
}
