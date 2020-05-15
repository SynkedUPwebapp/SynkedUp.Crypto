# EL.Crypto
A library with some helpful cryptographic functionality.

## Usage

To configure DI, call `EL.Crypto.DependencyInjectionConfig.ConfigureServices(services);`

Here are the interfaces defining the available functionality:
* `IAesEncryption` - Simple AES 256 encryption/decryption
* `IByteGenerator` - Get cryptographically secure random byte arrays
* `IRandomStringGenerator` - Get a random string from a provided character set
* `ITokenGenerator` - Get a new 512 bit random opaque token along with it's hash.
  Suitable for use as an API Key. 
* `IHasher` - Hash string data.

