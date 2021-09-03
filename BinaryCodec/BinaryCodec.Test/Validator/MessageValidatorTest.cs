using BinaryCodec.Consts;
using BinaryCodec.Models;
using BinaryCodec.Validators;
using System;
using Xunit;

namespace BinaryCodec.Test.Validator
{
    public class MessageValidatorTest
    {
        private readonly MessageValidator _uut;

        public MessageValidatorTest()
        {
            _uut = new MessageValidator();
        }

        [Fact]
        public void ValidateShouldReturnCorrectStringIfTooManyHeadersAreGiven()
        {
            //Arrange
            var expectedResult = "To many headers! Message is supporting only up to 63 headers\n";
            var message = new Message();
            message.Payload = new byte[] { 0, 12, 12, 53 };
            for (int i = 0; i < 64; i++)
            {
                message.Headers.Add($"Header#{i}", "value");
            }
            //Act
            _uut.Validate(message, out var result);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ValidateShouldReturnCorrectMessageIfHeaderKeyIsToLong()
        {
            //Arrange
            var message = new Message();
            message.Payload = new byte[] { 0, 12, 12, 53 };
            var key = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec est mi, laoreet sit amet pharetra sed, gravida eu ex. Aliquam feugiat dolor ut fermentum viverra. Nulla et imperdiet nibh. Nam congue dignissim ligula, convallis fermentum metus condimentum a. Praesent vel felis vel odio suscipit lacinia. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque non dolor neque. Etiam et euismod enim, id euismod nulla. Integer nec mauris a augue viverra iaculis ut vitae turpis. Mauris quis quam sed justo porttitor ultrices. Aliquam rutrum ipsum at est dictum fringilla eget non turpis. Nullam sit amet tortor elementum, semper sapien nec, fermentum ipsum. Pellentesque sed lacus ornare est pretium feugiat. Nam magna odio, rhoncus sit amet mauris quis, egestas fringilla ex. Vestibulum pretium hendrerit libero quis auctor. Quisque at orci justo. Etiam quis erat orci. Curabitur malesuada varius orci, at porta odio eleifend quis. Proin in molestie metus, id efficitur arcu. Morbi et lobortis augue. Duis vel tortor ut quam venenatis fermentum sed ut velit. Nulla libero massa, mattis id nisi vel, dapibus tristique ex. Sed diam arcu, porttitor vel porttitor nec, suscipit et massa. Integer iaculis malesuada augue eget sagittis. Donec pretium malesuada libero, eget efficitur arcu viverra in. Nunc vitae eros pellentesque mauris placerat mattis ut vitae libero.";
            message.Headers.Add(key, "value");
            var expectedResult = $"Hedaer Key: {key} is too long (key cannot be longer than 1023 characters)\n";
            //Act
            _uut.Validate(message, out var result);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ValidateShouldReturnCorrectMessageIfHeaderValueIsToLong()
        {
            //Arrange
            var message = new Message();
            message.Payload = new byte[] { 0, 12, 12, 53 };
            var value = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec est mi, laoreet sit amet pharetra sed, gravida eu ex. Aliquam feugiat dolor ut fermentum viverra. Nulla et imperdiet nibh. Nam congue dignissim ligula, convallis fermentum metus condimentum a. Praesent vel felis vel odio suscipit lacinia. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque non dolor neque. Etiam et euismod enim, id euismod nulla. Integer nec mauris a augue viverra iaculis ut vitae turpis. Mauris quis quam sed justo porttitor ultrices. Aliquam rutrum ipsum at est dictum fringilla eget non turpis. Nullam sit amet tortor elementum, semper sapien nec, fermentum ipsum. Pellentesque sed lacus ornare est pretium feugiat. Nam magna odio, rhoncus sit amet mauris quis, egestas fringilla ex. Vestibulum pretium hendrerit libero quis auctor. Quisque at orci justo. Etiam quis erat orci. Curabitur malesuada varius orci, at porta odio eleifend quis. Proin in molestie metus, id efficitur arcu. Morbi et lobortis augue. Duis vel tortor ut quam venenatis fermentum sed ut velit. Nulla libero massa, mattis id nisi vel, dapibus tristique ex. Sed diam arcu, porttitor vel porttitor nec, suscipit et massa. Integer iaculis malesuada augue eget sagittis. Donec pretium malesuada libero, eget efficitur arcu viverra in. Nunc vitae eros pellentesque mauris placerat mattis ut vitae libero.";
            message.Headers.Add("key", value);
            var expectedResult = $"Hedaer Value: {value} is too long (key cannot be longer than 1023 characters)\n";
            //Act
            _uut.Validate(message, out var result);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ValidateShouldReturnCorrectMessageIfPayloadIsToBig()
        {
            //Arrange
            var message = new Message();
            Random rnd = new Random();
            message.Payload = new byte[Limitations.MaxPayloadSize + 10];
            rnd.NextBytes(message.Payload);
            message.Headers.Add("key", "value");
            var expectedResult = $"Message payload is too big";
            //Act
            _uut.Validate(message, out var result);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedResult, result);
        }
    }
}