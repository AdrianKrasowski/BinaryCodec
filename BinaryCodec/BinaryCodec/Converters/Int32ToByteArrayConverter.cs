using System;

namespace BinaryCodec.Converters
{
    public class Int32ToByteArrayConverter
    {
        public byte[] Convert(Int32 integer) => BitConverter.GetBytes(integer);
    }
}