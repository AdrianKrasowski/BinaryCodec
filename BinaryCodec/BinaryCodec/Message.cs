using System;
using System.Collections.Generic;

namespace BinaryCodec
{
    public class Message
    {
        public Dictionary<String, String> headers;
        public byte[] payload;
    }
}