using BinaryCodec.Abstract;
using BinaryCodec.Codecs;
using BinaryCodec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec
{
    public class MessageCodec : IMessageCodec
    {
        private readonly MessageDecoder _messageDecoder;

        public Message Decode(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] Encode(Message message)
        {
            throw new NotImplementedException();
        }
    }
}