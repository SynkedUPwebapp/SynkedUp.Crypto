# Emmersion.Crypto
A library with some helpful cryptographic functionality.

## Usage

To configure DI, call `Emmersion.Crypto.DependencyInjectionConfig.ConfigureServices(services);`

Here are the interfaces defining the available functionality:
* `IAesEncryption` - Simple AES 256 encryption/decryption
* `IByteGenerator` - Get cryptographically secure random byte arrays
* `IRandomStringGenerator` - Get a random string from a provided character set
* `ITokenGenerator` - Get a new 512 bit random opaque token along with its hash.
  Suitable for use as an API Key. When using, store the hash rather than the token
  and call the `Regenerate` function to recreate the hash when verifying a token.
* `IHasher` - Hash string data. Defaults to the `Sha256Hasher` implementation.

## Version History
- 2.0 - Change namespace from `EL.` to `Emmersion.`
- 1.0 - Initial release
