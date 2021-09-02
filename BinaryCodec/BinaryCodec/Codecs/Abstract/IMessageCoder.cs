using BinaryCodec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Codecs.Abstract
{
    internal interface IMessageCoder
    {
        Message DecodeMesssage(byte[] encodedMessage);
    }
}