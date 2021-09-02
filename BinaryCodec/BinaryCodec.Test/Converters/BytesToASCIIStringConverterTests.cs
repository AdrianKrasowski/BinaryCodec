using BinaryCodec.Converters;
using Xunit;

namespace BinaryCodec.Test.Converters
{
    public class BytesToASCIIStringConverterTests
    {
        private readonly BytesToASCIIStringConverter _uut;

        public BytesToASCIIStringConverterTests()
        {
            _uut = new BytesToASCIIStringConverter();
        }

        [Fact]
        public void GivenCorrectBytesArrayConvertShouldReturnExpectedString()
        {
            //Arrange
            var inputArray = new byte[] { 84, 101, 115, 116 };
            var expectedResult = "Test";

            //Act
            var result = _uut.Convert(inputArray);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}