using CaeserCipher;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CeaserTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        Caesar caesar = new Caesar();
        int Step = 1;
        string initialString = "NotEncrypted";

        [Fact]
        public void EncodeDecode_StepDoesNotExceedeListElementCount_ReturnsEncryptedString()
        {
            string result = caesar.EncodeDecode(initialString, Step);
            Assert.NotEqual(initialString, result);
        }

        [Fact]
        public void EncodeDecode_StepDoesExceedeListElementCount_ReturnsEncryptedString()
        {
            int step = int.MaxValue;
            string result = caesar.EncodeDecode(initialString, step);
            Assert.NotEqual(initialString, result);
        }

        [Fact]
        public void EncodeDecode_InputValueIsNull_ReturnsEmptyString()
        {
            string input = null;
            string result = caesar.EncodeDecode(input, Step);
            Assert.True(result == "");
        }

        [Fact]
        public void EncodeDecode_InputValueIsEmptyString_ReturnsEmptyString()
        {
            string input = "";
            string result = caesar.EncodeDecode(input, Step);
            Assert.True(result == "");
        }

        [Fact]
        public void EncodeDecode_InputValueIsUnkownCiphers_ReturnsSameString()
        {
            string input = "☹☺☻㋛㋡〠ꌇツ";
            string result = caesar.EncodeDecode(input, Step);
            output.WriteLine(result);
            Assert.True(result == input);
        }

        [Fact]
        public void EncodeDecode_EncodingAndDecoding_ReturnsSameString()
        {
            string resultEncode = caesar.EncodeDecode(initialString, Step);
            string resultDecode = caesar.EncodeDecode(resultEncode, -Step);
            Assert.True(initialString == resultDecode);
        }
    }
}
