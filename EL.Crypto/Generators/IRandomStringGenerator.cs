namespace EL.Crypto.Generators
{
    public interface IRandomStringGenerator
    {
        string Generate(int length);
        string Generate(int length, string characterSet);
    }
}
