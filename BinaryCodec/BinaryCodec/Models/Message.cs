using System;
using System.Collections.Generic;

namespace BinaryCodec.Models
{
    public class Message
    {
        public Message()
        {
            Headers = new Dictionary<string, string>();
        }

        public Dictionary<String, String> Headers { get; set; }
        public byte[] Payload { get; set; }

        public byte HeadersNumber => (byte)Headers.Count;
        public int PayloadBytes => Payload.Length;
    }
}