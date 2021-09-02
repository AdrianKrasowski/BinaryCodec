using System;
using System.Collections.Generic;
using System.Text;

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