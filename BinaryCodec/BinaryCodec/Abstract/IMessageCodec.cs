using BinaryCodec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Abstract
{
    public interface IMessageCodec
    {
        byte[] Encode(Message message);

        Message Decode(byte[] data);
    }
}