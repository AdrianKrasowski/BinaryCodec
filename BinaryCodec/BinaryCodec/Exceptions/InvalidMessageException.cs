using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Exceptions
{
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException() : base()
        {
        }

        public InvalidMessageException(string message) : base(message)
        {
        }

        public InvalidMessageException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}