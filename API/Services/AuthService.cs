using API.Config;
using API.Services._Interface;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private static RSACryptoServiceProvider _privateRSAProvider = null!;
        private static RSACryptoServiceProvider _publicRSAProvider = null!;

        public AuthService(ApiSettings apiSettings) {
            if (_privateRSAProvider is not null && _publicRSAProvider is not null)
                return;

            RSAParameters _rsaKeyParams;
            using (var tr = new StringReader(apiSettings.RSA.PrivateKey))
            {
                var pemReader = new PemReader(tr);
                AsymmetricCipherKeyPair? keyPair = pemReader.ReadObject() as AsymmetricCipherKeyPair;
                if (keyPair == null)
                    throw new Exception("Could not read RSA private key");

                _rsaKeyParams = DotNetUtilities.ToRSAParameters(keyPair.Private as RsaPrivateCrtKeyParameters);
            }
            _privateRSAProvider = new RSACryptoServiceProvider();
            _privateRSAProvider.ImportParameters(_rsaKeyParams);

            using (var tr = new StringReader(apiSettings.RSA.PublicKey))
            {
                var pemReader = new PemReader(tr);
                RsaKeyParameters? publicKeyParams = pemReader.ReadObject() as RsaKeyParameters;
                if (publicKeyParams == null)
                    throw new Exception("Could not read RSA public key");

                _rsaKeyParams = DotNetUtilities.ToRSAParameters(publicKeyParams);
            }

            _publicRSAProvider = new RSACryptoServiceProvider();
            _publicRSAProvider.ImportParameters(_rsaKeyParams);
        }

        public string CreateToken(IList<Claim> claims)
        {
            Dictionary<string, object> payload = claims.ToDictionary(k => k.Type, v => (object)v.Value);
            return Jose.JWT.Encode(payload, _privateRSAProvider, Jose.JwsAlgorithm.RS256);
        }

        public string DecodeToken(string token)
        {
            return Jose.JWT.Decode(token, _publicRSAProvider, Jose.JwsAlgorithm.RS256);
        }
    }
}
