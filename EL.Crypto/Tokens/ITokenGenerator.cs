namespace EL.Crypto.Tokens
{
    public interface ITokenGenerator
    {
        Token Generate();
        Token Regenerate(string tokenValue);
    }
}
