using System;
using System.Linq;
using EL.Crypto.Generators;
using EL.Testing;
using NUnit.Framework;

namespace EL.Crypto.UnitTests.Generators
{
    public class RandomStringGeneratorTests : With_an_automocked<RandomStringGenerator>
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(14)]
        [TestCase(64)]
        public void When_generating_a_random_string_it_should_be_the_correct_length(int length)
        {
            var result = ClassUnderTest.Generate(length);
            Assert.That(result.Length, Is.EqualTo(length));
        }

        [Test]
        public void When_generating_from_a_provided_character_set_all_characters_should_be_used_eventually()
        {
            var characterSet = "ABC123";
            var generated = string.Join("", Enumerable.Range(1, 100).Select(x => ClassUnderTest.Generate(10, characterSet)));
            characterSet.ToCharArray().ToList().ForEach(x => { Assert.That(generated.Contains(x)); });
        }

        [Test]
        public void When_generating_from_a_provided_character_set_of_only_one_character()
        {
            var result = ClassUnderTest.Generate(12, "A");
            Assert.That(result, Is.EqualTo("AAAAAAAAAAAA"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void When_generating_from_a_provided_character_set_that_is_null_or_empty(string characterSet)
        {
            var result = Assert.Catch<ArgumentException>(() => ClassUnderTest.Generate(12, characterSet));
            Assert.That(result.Message, Does.StartWith("The provided characterSet must have 1 or more characters"));
            Assert.That(result.ParamName, Is.EqualTo("characterSet"));
        }

        [Test]
        public void When_generating_the_results_should_be_random()
        {
            var generated = Enumerable.Range(1, 100).Select(x => ClassUnderTest.Generate(10)).ToList();
            var unique = generated.Distinct().ToList();
            Assert.That(generated.Count, Is.EqualTo(unique.Count));
        }
    }
}
