using System;

namespace Shop.Exeptions
{
    public class IdExeption : Exception
    {
        public IdExeption() : base("Wrong Id")
        {
        }

        public IdExeption(string message) : base(message)
        {
        }

        public IdExeption(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}