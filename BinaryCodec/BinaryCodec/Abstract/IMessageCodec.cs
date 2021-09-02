using BinaryCodec.Models;

namespace BinaryCodec.Abstract
{
    public interface IMessageCodec
    {
        byte[] Encode(Message message);

        Message Decode(byte[] data);
    }
}