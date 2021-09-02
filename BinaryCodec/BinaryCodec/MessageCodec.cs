using BinaryCodec.Abstract;
using BinaryCodec.Codecs;
using BinaryCodec.Codecs.Abstract;
using BinaryCodec.Models;
using System;

namespace BinaryCodec
{
    public class MessageCodec : IMessageCodec
    {
        private readonly IMessageDecoder messageDecoder;
        private readonly IMessageCoder messageCoder;

        public MessageCodec()
        {
            messageDecoder = new MessageDecoder();
            messageCoder = new MessageCoder();
        }

        public Message Decode(byte[] data)
        {
            try
            {
                var result = messageDecoder.DecodeMessage(data);
                return result;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }

        public byte[] Encode(Message message)
        {
            try
            {
                var result = messageCoder.CodeMesssage(message);
                return result;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }
    }
}