using Emmersion.Crypto.Hashing;
using Emmersion.Testing;
using NUnit.Framework;

namespace Emmersion.Crypto.UnitTests.Hashing
{
    public class HmacSha256Tests : With_an_automocked<HmacSha256>
    {
        [TestCase("abc123", "acme_api_key|1476218468", "53j1OpOtS3Hw+XjpUjz/OEER2WiXrEffXv7AMjCaZDE=")]
        [TestCase("123456", "qwerty", "M2Stk8CD3HbXl2uHWRJEJhXMb3485yeyMWFzgAyjKzo=")]
        public void When_generating_a_base64_hmac_from_strings(string secret, string input, string expected)
        {
            Assert.That(ClassUnderTest.GenerateBase64(secret, input), Is.EqualTo(expected));
        }
    }
}