using System;
using System.Collections.Generic;
using System.Text;

namespace NewAge.Infra.Exceptions
{
    public class MyException : System.Exception
    {
        public MyException(string messsage) : base(messsage)
        {
        }
    }
}
