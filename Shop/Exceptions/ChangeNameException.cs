﻿using System;

namespace Shop.Exceptions
{
    public class ChangeNameException : Exception
    {
        public ChangeNameException() : base("Name changes are prohibited!")
        {
        }

        public ChangeNameException(string message) : base(message)
        {
        }

        public ChangeNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}