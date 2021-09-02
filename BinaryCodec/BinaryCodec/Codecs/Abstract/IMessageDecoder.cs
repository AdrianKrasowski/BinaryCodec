using BinaryCodec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Codecs.Abstract
{
    internal interface IMessageDecoder
    {
        Message DecodeMessage(byte[] inputBytes);
    }
}