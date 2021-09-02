using System;
using System.Collections.Generic;

namespace BinaryCodec.Models
{
    public class Message
    {
        public Dictionary<String, String> Headers;
        public byte[] Payload;

        public int HeadersNumber => Headers.Count;
        public int PayloadBytes => Payload.Length;
    }
}