using System;

namespace BinaryCodec.Exceptions
{
    public class PayloadSizeException : Exception
    {
        public PayloadSizeException() : base()
        {
        }

        public PayloadSizeException(string message) : base(message)
        {
        }

        public PayloadSizeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}