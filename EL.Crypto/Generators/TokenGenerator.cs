using System;
using System.Security.Cryptography;
using EL.Crypto.Hashing;

namespace EL.Crypto.Generators
{
    public class TokenGenerator : ITokenGenerator
    {
        private static readonly RNGCryptoServiceProvider byteGenerator = new RNGCryptoServiceProvider();
        private readonly IHasher hasher;

        public TokenGenerator(IHasher hasher)
        {
            this.hasher = hasher;
        }

        public Token Generate()
        {
            var bytes = new byte[64];
            byteGenerator.GetBytes(bytes);
            var token = Convert.ToBase64String(bytes);
            return Regenerate(token);
        }

        public Token Regenerate(string tokenValue)
        {
            return new Token
            {
                Value = tokenValue,
                Hash = hasher.Hash(tokenValue)
            };
        }
    }
}
