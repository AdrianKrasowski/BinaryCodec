using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Exceptions
{
    public class ASCIIStringConversionException : Exception
    {
        public ASCIIStringConversionException() : base()
        {
        }

        public ASCIIStringConversionException(string message) : base(message)
        {
        }

        public ASCIIStringConversionException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}