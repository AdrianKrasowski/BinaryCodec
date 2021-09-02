using BinaryCodec.Codecs.Abstract;
using BinaryCodec.Consts;
using BinaryCodec.Converters;
using BinaryCodec.Exceptions;
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
                if (headersCount > Limitations.MaxHeadersNumber)
                {
                    throw new InvalidMessageException("Message has to many headers");
                }
                for (int i = 0; i < headersCount; i++)
                {
                    var headerKey = DecodeHeaderPart(stream);
                    var headerValue = DecodeHeaderPart(stream);
                    message.Headers.Add(headerKey, headerValue);
                }
                message.Payload = DecodePayload(stream);
            }

            return message;
        }

        private string DecodeHeaderPart(MemoryStream stream)
        {
            var headerStringLenghtBytes = new byte[LenghtInBytes.IntegerLength];
            stream.Read(headerStringLenghtBytes, 0, LenghtInBytes.IntegerLength);
            var headerStringLength = intConverter.Convert(headerStringLenghtBytes);
            if (headerStringLength > Limitations.MaxHeaderLength)
            {
                throw new HeaderToLongException($"One of headers is to long");
            }
            var headerStringBytes = new byte[headerStringLength];
            stream.Read(headerStringBytes, 0, headerStringLength);
            return stringConverter.Convert(headerStringBytes);
        }

        private byte[] DecodePayload(MemoryStream stream)
        {
            var payloadLenghtBytes = new byte[LenghtInBytes.IntegerLength];
            stream.Read(payloadLenghtBytes, 0, LenghtInBytes.IntegerLength);
            var payloadLength = intConverter.Convert(payloadLenghtBytes);
            if (payloadLength > Limitations.MaxPayloadSize)
            {
                throw new PayloadSizeException("Message payload is to big");
            }
            var payload = new byte[payloadLength];
            stream.Read(payload, 0, payloadLength);
            return payload;
        }
    }
}