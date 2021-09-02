using BinaryCodec.Codecs.Abstract;
using BinaryCodec.Consts;
using BinaryCodec.Converters;
using BinaryCodec.Models;
using System.IO;

namespace BinaryCodec.Codecs
{
    public class MessageDecoder : IMessageDecoder
    {
        private readonly ByteArrayToInt32Converter intConverter;
        private readonly BytesToASCIIStringConverter stringConverter;

        public MessageDecoder()
        {
            intConverter = new ByteArrayToInt32Converter();
            stringConverter = new BytesToASCIIStringConverter();
        }

        public Message DecodeMessage(byte[] inputBytes)
        {
            var message = new Message();
            using (MemoryStream stream = new MemoryStream(inputBytes))
            {
                var headersCount = stream.ReadByte();
                for (int i = 0; i < headersCount; i++)
                {
                    var headerKey = DecodeHeaderPart(stream);
                    var headerValue = DecodeHeaderPart(stream);
                    message.Headers.Add(headerKey, headerValue);
                }
                message.Payload = DecodePayload(stream);
            }

            throw new System.NotImplementedException();
        }

        private string DecodeHeaderPart(MemoryStream stream)
        {
            var headerStringLenghtBytes = new byte[LenghtInBytes.IntegerLength];
            stream.Read(headerStringLenghtBytes, 0, LenghtInBytes.IntegerLength);
            var headerStringLength = intConverter.Convert(headerStringLenghtBytes);
            var headerStringBytes = new byte[headerStringLength];
            stream.Read(headerStringBytes, 0, headerStringLength);
            return stringConverter.Convert(headerStringBytes);
        }

        private byte[] DecodePayload(MemoryStream stream)
        {
            var payloadLenghtBytes = new byte[LenghtInBytes.IntegerLength];
            stream.Read(payloadLenghtBytes, 0, LenghtInBytes.IntegerLength);
            var payloadLength = intConverter.Convert(payloadLenghtBytes);
            var payload = new byte[payloadLength];
            stream.Read(payload, 0, payloadLength);
            return payload;
        }
    }
}