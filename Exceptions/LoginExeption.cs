using System;

namespace Manager.Exceptions
{
    class LoginExeption : Exception
    {
        public LoginExeption(string message)
            : base(message) { }
    }
}
