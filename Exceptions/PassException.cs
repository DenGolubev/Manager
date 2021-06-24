using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Exceptions
{
    class PassException : Exception
    {
        public PassException(string message)
            : base(message) { }
    }
}
