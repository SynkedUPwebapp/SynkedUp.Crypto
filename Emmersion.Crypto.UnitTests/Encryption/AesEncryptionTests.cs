using System;
using Emmersion.Testing;
using Emmersion.Crypto.Encryption;
using Emmersion.Crypto.Generators;
using NUnit.Framework;

namespace Emmersion.Crypto.UnitTests.Encryption
{
    public class AesEncryptionTests : With_an_automocked<AesEncryption>
    {
        [Test]
        public void When_encrypting()
        {
            var plainText = "it's a secret to everyone";
            var key = Convert.FromBase64String("rb4y12shhYkPKHHt81gTCxcK0wazdWd92eu19uevyAM=");
            var iv = Convert.FromBase64String("/ADA/PUt5OIP8h2bFqCO5w==");

            var cypherText = ClassUnderTest.Encrypt(plainText, key, iv);

            Assert.That(Convert.ToBase64String(cypherText), Is.EqualTo("PzkqO8fwQt4PQjjYHxEN3wSVJCPUTPM4EAUXzrDhNg8="));
        }

        [Test]
        public void When_decrypting()
        {
            var cypherText = Convert.FromBase64String("PzkqO8fwQt4PQjjYHxEN3wSVJCPUTPM4EAUXzrDhNg8=");
            var key = Convert.FromBase64String("rb4y12shhYkPKHHt81gTCxcK0wazdWd92eu19uevyAM=");
            var iv = Convert.FromBase64String("/ADA/PUt5OIP8h2bFqCO5w==");

            var plainText = ClassUnderTest.Decrypt(cypherText, key, iv);

            Assert.That(plainText, Is.EqualTo("it's a secret to everyone"));
        }

        [Test]
        public void When_getting_a_new_256_bit_key()
        {
            var key = new byte[] {0x00, 0x01, 0x02};
            GetMock<IByteGenerator>().Setup(x => x.Generate(32)).Returns(key);

            var result = ClassUnderTest.Generate256BitKey();

            Assert.That(result, Is.EqualTo(key));
        }

        [Test]
        public void When_getting_a_new_iv()
        {
            var key = new byte[] {0x00, 0x01, 0x02};
            GetMock<IByteGenerator>().Setup(x => x.Generate(16)).Returns(key);

            var result = ClassUnderTest.GenerateIV();

            Assert.That(result, Is.EqualTo(key));
        }
    }
}
