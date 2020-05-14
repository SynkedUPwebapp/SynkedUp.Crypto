﻿using System;
using System.Security.Cryptography;

namespace EL.Crypto.Generators
{
    public class ByteGenerator : IByteGenerator
    {
        private static readonly RNGCryptoServiceProvider byteGenerator = new RNGCryptoServiceProvider();

        public byte[] Generate(int numberOfBytes)
        {
            var bytes = new byte[numberOfBytes];
            byteGenerator.GetBytes(bytes);
            return bytes;
        }

        public string GenerateAsBase64(int numberOfBytes)
        {
            return Convert.ToBase64String(Generate(numberOfBytes));
        }
    }
}
