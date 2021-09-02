using BinaryCodec.Converters;
using BinaryCodec.Exceptions;
using Xunit;

namespace BinaryCodec.Test.Converters
{
    public class ByteArrayToInt32ConverterTests
    {
        private readonly ByteArrayToInt32Converter _uut;

        public ByteArrayToInt32ConverterTests()
        {
            _uut = new ByteArrayToInt32Converter();
        }

        [Fact]
        public void GivenByteArrayShouldReturnCorrectString()
        {
            //Arrange

            var inputBytes = new byte[] { 210, 0, 0, 0 };
            var expectedResult = 210;

            //Act
            var result = _uut.Convert(inputBytes);

            //Assert

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenLongerByteArrayConvertShouldThrowInvalidInt32BytesException()
        {
            //Arrange

            var inputBytes = new byte[] { 210, 0, 0, 0, 122 };

            //Act - Assert

            Assert.Throws<InvalidInt32BytesException>(() => _uut.Convert(inputBytes));
        }

        [Fact]
        public void GivenShorterByteArrayConvertShouldThrowInvalidInt32BytesException()
        {
            //Arrange

            var inputBytes = new byte[] { 210, 0 };

            //Act - Assert

            Assert.Throws<InvalidInt32BytesException>(() => _uut.Convert(inputBytes));
        }
    }
}