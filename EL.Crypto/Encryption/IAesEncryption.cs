namespace EL.Crypto.Encryption
{
    public interface IAesEncryption
    {
        byte[] Encrypt(string plainText, byte[] key, byte[] iv);
        string Decrypt(byte[] cipherText, byte[] key, byte[] iv);
        byte[] Generate256BitKey();
        byte[] GenerateIV();
    }
}