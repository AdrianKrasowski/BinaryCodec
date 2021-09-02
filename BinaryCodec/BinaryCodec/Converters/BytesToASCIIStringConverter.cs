using BinaryCodec.Consts;
using BinaryCodec.Exceptions;
using BinaryCodec.Validators;
using System.Text;

namespace BinaryCodec.Converters
{
    public class BytesToASCIIStringConverter
    {
        private readonly Encoding encoding = Encoding.ASCII;
        private readonly ConversionLengthsValidator validator = new ConversionLengthsValidator();

        public string Convert(byte[] inputBytes)
        {
            var outputString = encoding.GetString(inputBytes);
            if (!validator.AreLengthsCorrect(outputString, inputBytes, LenghtInBytes.AsciiCharLength))
            {
                throw new ASCIIStringConversionException($"Conversion of byte array returned string with length different than expected");
            }
            return outputString;
        }
    }
}