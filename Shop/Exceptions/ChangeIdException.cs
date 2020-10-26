using System;

namespace Shop.Exceptions
{
    public class ChangeIdException : IdException
    {
        public ChangeIdException() : base("Changing the ID is prohibited!")
        {
        }

        public ChangeIdException(string message) : base(message)
        {
        }

        public ChangeIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}