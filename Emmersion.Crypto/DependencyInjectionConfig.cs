using Emmersion.Crypto.Encryption;
using Emmersion.Crypto.Generators;
using Emmersion.Crypto.Hashing;
using Microsoft.Extensions.DependencyInjection;

namespace Emmersion.Crypto
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
            services.AddTransient<ISha256Hasher, Sha256Hasher>();
            services.AddTransient<IHmacSha256, HmacSha256>();
        }
    }
}
