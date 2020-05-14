using EL.Crypto.Generators;
using EL.Crypto.Hashing;
using NUnit.Framework;

namespace EL.Crypto.UnitTests.Generators
{
    public class TokenGeneratorTests : With_an_automocked<TokenGenerator>
    {
        [Test]
        public void When_generating_a_new_token()
        {
            var value = "token value";
            var hash = "this is the hash";
            GetMock<IByteGenerator>().Setup(x => x.GenerateAsBase64(64)).Returns(value);
            GetMock<IHasher>().Setup(x => x.Hash(IsAny<string>())).Returns(hash);

            var result = ClassUnderTest.Generate();

            Assert.That(result.Value, Is.EqualTo(value));
            Assert.That(result.Hash, Is.EqualTo(hash));
        }

        [Test]
        public void When_regenerating_a_token()
        {
            var tokenValue = "token value";
            var hash = "hash value";
            GetMock<IHasher>().Setup(x => x.Hash(tokenValue)).Returns(hash);

            var result = ClassUnderTest.Regenerate(tokenValue);

            Assert.That(result.Value, Is.EqualTo(tokenValue));
            Assert.That(result.Hash, Is.EqualTo(hash));
        }
    }
}
