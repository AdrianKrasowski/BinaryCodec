using BinaryCodec.Converters;
using Xunit;

namespace BinaryCodec.Test.Converters
{
    public class ASCIIStringToBytesConverterTests
    {
        private readonly ASCIIStringToBytesConverter _uut;

        public ASCIIStringToBytesConverterTests()
        {
            _uut = new ASCIIStringToBytesConverter();
        }

        [Fact]
        public void GivenASCIIStringConvertShouldReturnExpectedByteArrays()
        {
            //Arrange

            var inputString = "Test";
            var expectedResult = new byte[] { 84, 101, 115, 116 };

            //Act
            var result = _uut.Convert(inputString);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}