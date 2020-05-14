namespace EL.Crypto.Generators
{
    public interface ITokenGenerator
    {
        Token Generate();
        Token Regenerate(string tokenValue);
    }
}
