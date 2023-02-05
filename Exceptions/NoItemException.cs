using System;

namespace Invoices.Exceptions
{
    public class NoItemException : Exception
    {
        public NoItemException() : base() { }
        public NoItemException(string message) : base(message) { }
        public NoItemException(string message, Exception inner) : base(message, inner) { }
    }
}
