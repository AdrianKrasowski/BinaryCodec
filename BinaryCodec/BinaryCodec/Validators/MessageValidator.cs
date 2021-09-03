using BinaryCodec.Consts;
using BinaryCodec.Models;
using System.Collections.Generic;

namespace BinaryCodec.Validators
{
    public class MessageValidator
    {
        public string Validate(Message message, out string validationResult)
        {
            validationResult = "";
            if (message.HeadersNumber > Limitations.MaxHeadersNumber)
                validationResult += "To many headers! Message is supporting only up to 63 headers\n";
            foreach (KeyValuePair<string, string> header in message.Headers)
            {
                if (header.Key.Length > Limitations.MaxHeaderLength)
                    validationResult += $"Hedaer Key: {header.Key} is too long (key cannot be longer than 1023 characters)\n";
                if (header.Value.Length > Limitations.MaxHeaderLength)
                    validationResult += $"Hedaer Value: {header.Value} is too long (key cannot be longer than 1023 characters)\n";
            }
            if (message.PayloadBytes > Limitations.MaxPayloadSize)
                validationResult += $"Message payload is too big";
            return validationResult;
        }
    }
}