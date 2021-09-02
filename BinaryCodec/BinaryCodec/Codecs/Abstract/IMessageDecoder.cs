using BinaryCodec.Models;

namespace BinaryCodec.Codecs.Abstract
{
    internal interface IMessageDecoder
    {
        Message DecodeMessage(byte[] inputBytes);
    }
}