using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Converters
{
    public class Int32ToByteArrayConverter
    {
        public byte[] Convert(Int32 integer) => BitConverter.GetBytes(integer);
    }
}