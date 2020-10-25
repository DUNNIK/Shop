using System;

namespace Shop.Exeptions
{
    public class ChangeIdExeption : IdExeption
    {
        public ChangeIdExeption() : base("Changing the ID is prohibited!")
        {
        }

        public ChangeIdExeption(string message) : base(message)
        {
        }

        public ChangeIdExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}