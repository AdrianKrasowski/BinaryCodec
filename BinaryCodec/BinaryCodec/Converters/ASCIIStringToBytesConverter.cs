using BinaryCodec.Consts;
using BinaryCodec.Exceptions;
using BinaryCodec.Validators;
using System.Text;

namespace BinaryCodec.Converters
{
    public class ASCIIStringToBytesConverter
    {
        private readonly ConversionLengthsValidator validator = new ConversionLengthsValidator();
        private readonly Encoding encoding = Encoding.ASCII;

        public byte[] Convert(string givenString)
        {
            var stringBytes = encoding.GetBytes(givenString);
            if (!validator.AreLengthsCorrect(givenString, stringBytes, LenghtInBytes.AsciiCharLength))
            {
                throw new ASCIIStringConversionException($"Byte array created while converting: \"{givenString}\" has invalid length");
            }
            return stringBytes;
        }
    }
}