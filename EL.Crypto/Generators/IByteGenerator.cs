namespace EL.Crypto.Generators
{
    public interface IByteGenerator
    {
        byte[] Generate(int numberOfBytes);
        string GenerateAsBase64(int numberOfBytes);
    }
}