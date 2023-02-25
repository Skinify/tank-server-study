using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Services
{
    public class AuthService
    {
        public static string? RSAPublicKey = "-----BEGIN PUBLIC KEY-----\r\nMFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqza\r\nuNeF0ieYdWN8fE6/YZpB4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQ==\r\n-----END PUBLIC KEY-----";
        public static string? RSAPrivateKey = "-----BEGIN RSA PRIVATE KEY-----\r\nMIIBOgIBAAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqzauNeF0ieYdWN8fE6/YZpB\r\n4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQJAMLJxiDY3RDN6CQPT8ssZ\r\nDMhxjUZH2VGBmQKzsTT2cvd94bH7V4ETGv011Tv5d31eeMudGLkiwUMIQUVBq/ba\r\nPQIhAOLCUPZxw4v/e3GnRi8Zm31wymdGk40AFuPApAGNFbDnAiEA1co6HkX4psjf\r\ny+XzxcSPlojhiyb98CQV2x5akJz1FEMCIQCLQHVjwl0pvgzasLSi/ADGudsyLN8z\r\nuZhU6NpOsYtehQIgMFrAEG7VEawnai/FljqiG3M0SEv2baVLyDayVzkY+Y8CIBji\r\ngNSm2/bwJM4fYfSsHD2BXOTneOWWP9ZtM6i30gWC\r\n-----END RSA PRIVATE KEY-----";

        public string CreateToken(List<Claim> claims)
        {
            if (RSAPrivateKey is null || RSAPublicKey is null)
                throw new Exception("Chaves não configuradas");

            RSAParameters rsaParams;
            using (var tr = new StringReader(RSAPrivateKey))
            {
                var pemReader = new PemReader(tr);
                var keyPair = pemReader.ReadObject() as AsymmetricCipherKeyPair;
                if (keyPair == null)
                {
                    throw new Exception("Could not read RSA private key");
                }
                var privateRsaParams = keyPair.Private as RsaPrivateCrtKeyParameters;
                rsaParams = DotNetUtilities.ToRSAParameters(privateRsaParams);
            }

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                Dictionary<string, object> payload = claims.ToDictionary(k => k.Type, v => (object)v.Value);
                return Jose.JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS256);
            }
        }

        public string DecodeToken(string token)
        {
            if (RSAPrivateKey is null || RSAPublicKey is null)
                throw new Exception("Chaves não configuradas");

            RSAParameters rsaParams;

            using (var tr = new StringReader(RSAPublicKey))
            {
                var pemReader = new PemReader(tr);
                var publicKeyParams = pemReader.ReadObject() as RsaKeyParameters;
                if (publicKeyParams == null)
                {
                    throw new Exception("Could not read RSA public key");
                }
                rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParams);
            }
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                // This will throw if the signature is invalid
                return Jose.JWT.Decode(token, rsa, Jose.JwsAlgorithm.RS256);
            }
        }
    }
}
