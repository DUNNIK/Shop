﻿using System;

namespace Shop.Exceptions
{
    public class BuyException : Exception
    {
        public BuyException() : base("Unable to make a purchase")
        {
        }

        public BuyException(string message) : base(message)
        {
        }

        public BuyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}