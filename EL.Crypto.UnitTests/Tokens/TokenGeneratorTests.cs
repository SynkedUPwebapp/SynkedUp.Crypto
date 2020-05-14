using System;
using EL.Crypto.Hashing;
using EL.Crypto.Tokens;
using NUnit.Framework;

namespace EL.Crypto.UnitTests.Tokens
{
    public class TokenGeneratorTests : With_an_automocked<TokenGenerator>
    {
        [Test]
        public void When_generating_a_new_token()
        {
            var hash = "this is the hash";
            GetMock<IHasher>().Setup(x => x.Hash(IsAny<string>())).Returns(hash);

            var result = ClassUnderTest.Generate();

            Assert.That(Convert.FromBase64String(result.Value).Length == 64);
            Assert.That(result.Hash, Is.EqualTo(hash));
        }

        [Test]
        public void When_generating_a_new_token_it_should_not_match_an_old_token()
        {
            var result1 = ClassUnderTest.Generate();
            var result2 = ClassUnderTest.Generate();

            Assert.That(result1.Value, Is.Not.EqualTo(result2.Value));
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
