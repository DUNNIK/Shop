using System;

namespace Shop.Exceptions
{
    public class ValueException : Exception
    {
        public ValueException() : base("Invalid value!")
        {
        }

        public ValueException(string message) : base(message)
        {
        }

        public ValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}