using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Exceptions
{
    public class DuplicateExeption : Exception
    {
        public DuplicateExeption(string message)
            : base(message) { }
    }
}
