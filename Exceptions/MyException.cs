using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Exceptions
{
    class MyRegistertNameException : Exception
    {
        private string value;
        public string BadValue => value;

        public MyRegistertNameException()
            : base() { }

        public MyRegistertNameException(string message)
            : base(message) { }

        public MyRegistertNameException(string value, string message)
            : base(message)
        {
            this.value = value;
        }

        public MyRegistertNameException(string value, string message, Exception exception)
            : base(message, exception)
        {
            this.value = value;
        }
    }
}
