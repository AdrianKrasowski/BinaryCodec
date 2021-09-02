using BinaryCodec.Models;

namespace BinaryCodec.Codecs.Abstract
{
    internal interface IMessageCoder
    {
        byte[] CodeMesssage(Message message);
    }
}