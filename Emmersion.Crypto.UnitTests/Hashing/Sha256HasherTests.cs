using EL.Testing;
using Emmersion.Crypto.Hashing;
using NUnit.Framework;

namespace Emmersion.Crypto.UnitTests.Hashing
{
    public class Sha256HasherTests : With_an_automocked<Sha256Hasher>
    {
        [Test]
        public void When_hashing_a_null_string()
        {
            var hash = ClassUnderTest.Hash(null);
            Assert.That(hash, Is.EqualTo(ClassUnderTest.Hash("")));
        }

        [Test]
        public void When_hashing_a_string()
        {
            var hash = ClassUnderTest.Hash("some secret value");
            Assert.That(hash, Is.EqualTo("ZPq/VlYDC90izc0HWbt08QSv7R4oy03WUDCcXYmLOs0="));
        }
    }
}
