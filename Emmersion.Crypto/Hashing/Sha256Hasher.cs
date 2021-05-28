using System;
using System.Security.Cryptography;
using System.Text;

namespace Emmersion.Crypto.Hashing
{
    public interface ISha256Hasher : IHasher
    {

    }

    public class Sha256Hasher : ISha256Hasher
    {
        public string Hash(string input)
        {
            using (var hasher = SHA256.Create())
            {
                return Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(input ?? "")));
            }
        }
    }
}
