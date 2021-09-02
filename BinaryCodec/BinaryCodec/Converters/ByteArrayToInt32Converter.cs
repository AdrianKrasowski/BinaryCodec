using BinaryCodec.Consts;
using BinaryCodec.Exceptions;
using System;

namespace BinaryCodec.Converters
{
    public class ByteArrayToInt32Converter
    {
        public int Convert(byte[] byteArray)
        {
            if (byteArray.Length != LenghtInBytes.IntegerLength)
            {
                throw new InvalidInt32BytesException("Byte array can't be cast to int32 due to invalid number of bytes");
            }
            return BitConverter.ToInt32(byteArray, 0);
        }
    }
}