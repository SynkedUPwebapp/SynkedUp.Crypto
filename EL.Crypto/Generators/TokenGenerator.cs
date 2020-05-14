using EL.Crypto.Hashing;

namespace EL.Crypto.Generators
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IByteGenerator byteGenerator;
        private readonly IHasher hasher;

        public TokenGenerator(IByteGenerator byteGenerator, IHasher hasher)
        {
            this.byteGenerator = byteGenerator;
            this.hasher = hasher;
        }

        public Token Generate()
        {
            return Regenerate(byteGenerator.GenerateAsBase64(64));
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
