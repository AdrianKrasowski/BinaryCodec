using BinaryCodec.Codecs.Abstract;
using BinaryCodec.Converters;
using BinaryCodec.Exceptions;
using BinaryCodec.Models;
using BinaryCodec.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryCodec.Codecs
{
    public class MessageCoder : IMessageCoder
    {
        private readonly Int32ToByteArrayConverter int32ToByteConverter;
        private readonly ASCIIStringToBytesConverter asciiStringToBytesConverter;
        private readonly MessageValidator validator;

        public MessageCoder()
        {
            int32ToByteConverter = new Int32ToByteArrayConverter();
            asciiStringToBytesConverter = new ASCIIStringToBytesConverter();
            validator = new MessageValidator();
        }

        public byte[] CodeMesssage(Message message)
        {
            if (!String.IsNullOrEmpty(validator.Validate(message, out string validationResult)))
            {
                throw new InvalidMessageException(validationResult);
            }
            var outputBytes = new List<byte>();

            outputBytes.Add(message.HeadersNumber);
            foreach (KeyValuePair<string, string> header in message.Headers)
            {
                outputBytes.AddRange(CodeHeader(header.Key, header.Value));
            }
            outputBytes.AddRange(CodePayload(message.Payload));
            return outputBytes.ToArray();
        }

        private List<byte> CodePayload(byte[] payload)
        {
            var payloadBytes = new List<byte>();
            payloadBytes.AddRange(int32ToByteConverter.Convert(payload.Length));
            payloadBytes.AddRange(payload);
            return payloadBytes;
        }

        private List<byte> CodeHeader(string key, string value)
        {
            var headerBytes = new List<byte>();
            headerBytes.AddRange(int32ToByteConverter.Convert(key.Length));
            headerBytes.AddRange(asciiStringToBytesConverter.Convert(key));
            headerBytes.AddRange(int32ToByteConverter.Convert(value.Length));
            headerBytes.AddRange(asciiStringToBytesConverter.Convert(value));
            return headerBytes;
        }
    }
}