using BinaryCodec.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BinaryCodec.Test.Converters
{
    public class Int32ToByteArrayConverterTests
    {
        private readonly Int32ToByteArrayConverter _uut;

        public Int32ToByteArrayConverterTests()
        {
            _uut = new Int32ToByteArrayConverter();
        }

        [Fact]
        public void ConvertShouldReturnCorrectByteArray()
        {
            //Arrange

            var expectedResult = new byte[] { 210, 0, 0, 0 };
            var inputInteger = 210;

            //Act
            var result = _uut.Convert(inputInteger);

            //Assert

            Assert.Equal(expectedResult, result);
        }
    }
}