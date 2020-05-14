using System;
using System.Security.Cryptography;
using System.Text;

namespace EL.Crypto.Hashing
{
    public class Sha256Hasher : IHasher
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
