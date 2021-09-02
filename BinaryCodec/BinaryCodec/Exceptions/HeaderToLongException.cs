using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Exceptions
{
    public class HeaderToLongException : Exception
    {
        public HeaderToLongException() : base()
        {
        }

        public HeaderToLongException(string message) : base(message)
        {
        }

        public HeaderToLongException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}