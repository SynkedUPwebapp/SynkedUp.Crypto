using System.IO;
using System.Security.Cryptography;
using EL.Crypto.Generators;

namespace EL.Crypto.Encryption
{
    public class AesEncryption : IAesEncryption
    {
        private readonly IByteGenerator byteGenerator;

        public AesEncryption(IByteGenerator byteGenerator)
        {
            this.byteGenerator = byteGenerator;
        }

        public byte[] Encrypt(string plainText, byte[] key, byte[] iv)
        {
            using (var algorithm = new AesManaged())
            {
                algorithm.Key = key;
                algorithm.IV = iv;
                algorithm.Mode = CipherMode.CBC;

                var encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        public string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (var algorithm = new AesManaged())
            {
                algorithm.Key = key;
                algorithm.IV = iv;
                algorithm.Mode = CipherMode.CBC;

                var decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
                using (var memoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public byte[] Generate256BitKey()
        {
            return byteGenerator.Generate(32);
        }

        public byte[] GenerateIV()
        {
            return byteGenerator.Generate(16);
        }
    }
}
