using BinaryCodec.Codecs.Abstract;
using BinaryCodec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Codecs
{
    public class MessageCoder : IMessageCoder
    {
        public Message DecodeMesssage(byte[] encodedMessage)
        {
            throw new NotImplementedException();
        }
    }
}