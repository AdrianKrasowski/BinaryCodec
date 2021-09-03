using BinaryCodec.Consts;
using BinaryCodec.Validators;
using Xunit;

namespace BinaryCodec.Test.Validator
{
    public class ConversionLengthsValidatorTest
    {
        private readonly ConversionLengthsValidator _uut;

        public ConversionLengthsValidatorTest()
        {
            _uut = new ConversionLengthsValidator();
        }

        [Fact]
        public void ValidateShouldReturnTrueIfGivenCorrectStringAndByteArray()
        {
            //Arrange

            var exampleString = "Abcd";
            var array = new byte[] { 1, 1, 1, 1 };

            //Act
            var result = _uut.AreLengthsCorrect(exampleString, array, LenghtInBytes.AsciiCharLength);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateShouldReturnFalseIfGivenInCorrectStringAndByteArray()
        {
            //Arrange

            var exampleString = "Abcdef";
            var array = new byte[] { 1, 1, 1, 1 };

            //Act
            var result = _uut.AreLengthsCorrect(exampleString, array, LenghtInBytes.AsciiCharLength);

            //Assert
            Assert.False(result);
        }
    }
}