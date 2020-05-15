using EL.Crypto.Encryption;
using EL.Crypto.Generators;
using EL.Crypto.Hashing;
using Microsoft.Extensions.DependencyInjection;

namespace EL.Crypto
{
    public class DependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAesEncryption, AesEncryption>();
            services.AddTransient<IByteGenerator, ByteGenerator>();
            services.AddTransient<IRandomStringGenerator, RandomStringGenerator>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            services.AddTransient<IHasher, Sha256Hasher>();
        }
    }
}
