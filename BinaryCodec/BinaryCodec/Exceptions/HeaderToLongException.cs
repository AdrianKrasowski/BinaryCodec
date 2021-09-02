using System;

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