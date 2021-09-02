using BinaryCodec;
using BinaryCodec.Models;
using System;
using System.Text.Json;

namespace BinaryCodecTestingApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var message = new Message();
            message.Headers.Add("Ble", "Ble");
            message.Headers.Add("Ble1", "Ble");
            message.Headers.Add("Ble2", "Ble");
            message.Headers.Add("Ble3", "Ble");
            message.Payload = new byte[] { 65, 65, 65, 65, 65, 65, 65 };

            MessageCodec codec = new MessageCodec();
            var bytes = codec.Encode(message);
            var decodedMessage = codec.Decode(bytes);
            string jsonString = JsonSerializer.Serialize(decodedMessage);
            Console.WriteLine(jsonString);
            Console.ReadKey();
        }
    }
}