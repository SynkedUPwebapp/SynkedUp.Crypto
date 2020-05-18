using System;
using System.Linq;

namespace EL.Crypto.Generators
{
    public interface IRandomStringGenerator
    {
        string Generate(int length);
        string Generate(int length, string characterSet);
    }

    public class RandomStringGenerator : IRandomStringGenerator
    {
        public const string DefaultCharacterSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly Random random = new Random();

        public string Generate(int length)
        {
            return Generate(length, DefaultCharacterSet);
        }

        public string Generate(int length, string characterSet)
        {
            if (string.IsNullOrEmpty(characterSet))
            {
                throw new ArgumentException("The provided characterSet must have 1 or more characters", nameof(characterSet));
            }

            return new string(Enumerable.Range(start: 0, count: length)
                .Select(x => characterSet[random.Next(minValue: 0, maxValue: characterSet.Length)])
                .ToArray());
        }
    }
}
