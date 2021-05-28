using Emmersion.Crypto.Hashing;

namespace Emmersion.Crypto.Generators
{
    public interface ITokenGenerator
    {
        Token Generate();
        Token Regenerate(string tokenValue);
    }
    
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
