﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Exceptions
{
    class TelException: Exception
    {
        public TelException(string message)
            : base(message) { }
    }
}
