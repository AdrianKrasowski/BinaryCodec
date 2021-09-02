using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Exceptions
{
    public class InvalidInt32BytesException : Exception
    {
        public InvalidInt32BytesException() : base()
        {
        }

        public InvalidInt32BytesException(string message) : base(message)
        {
        }

        public InvalidInt32BytesException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}