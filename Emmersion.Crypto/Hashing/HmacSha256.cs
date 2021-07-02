using System;
using System.Security.Cryptography;
using System.Text;

namespace Emmersion.Crypto.Hashing
{
    public interface IHmacSha256
    {
        byte[] GenerateBytes(byte[] secret, byte[] input);
        string GenerateBase64(string secret, string input);
    }

    public class HmacSha256 : IHmacSha256
    {
        public byte[] GenerateBytes(byte[] secret, byte[] input)
        {
            using (var hmac = new HMACSHA256(secret))
            {
                return hmac.ComputeHash(input);
            }
        }

        public string GenerateBase64(string secret, string input)
        {
            var encoding = Encoding.UTF8;
            return Convert.ToBase64String(GenerateBytes(encoding.GetBytes(secret), encoding.GetBytes(input)));
        }
    }
}