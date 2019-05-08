using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Exceptions
{
    public class PasswordFormatException: Exception
    {
        public PasswordFormatException()
        {

        }

        public PasswordFormatException(string message): base(string.Format($"Exception Message: {message}"))
        {

        }
    }
}
