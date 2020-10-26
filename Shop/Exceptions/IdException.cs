using System;

namespace Shop.Exceptions
{
    public class IdException : Exception
    {
        public IdException() : base("Wrong Id")
        {
        }

        protected IdException(string message) : base(message)
        {
        }

        protected IdException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}