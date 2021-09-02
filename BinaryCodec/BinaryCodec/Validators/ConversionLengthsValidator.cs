namespace BinaryCodec.Validators
{
    public class ConversionLengthsValidator
    {
        public bool AreLengthsCorrect(string stringValue, byte[] byteArray, int lengthInbytes) => stringValue.Length == (byteArray.Length / lengthInbytes);
    }
}