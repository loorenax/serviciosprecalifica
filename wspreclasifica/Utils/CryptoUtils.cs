using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

namespace wspreclasifica.Utils
{
    public class CryptoUtils
    {
        public static string sign(byte[] payload)
        {
            string pkcs8 = @"-----BEGIN EC PRIVATE KEY-----
MIGkAgEBBDDHO0hDuO2LHw9TDB1WDmaDGs9EoATJhpe3iR+rINIsKLoT6YoQVSh6
9DrPfgEKDmGgBwYFK4EEACKhZANiAATI+wyGsrryTsPUXBEgGiCiwNhpw0OTP22r
tZAyAPJ9+RFL4+3Vi9fpeeVoF0RGyY/P9PPUIKujbKDnWCpKJlAC+9c5FnBtziM5
FqnOpwLUlNqVisgqbGRvm2blQn7/tcY=
-----END EC PRIVATE KEY-----";
            TextReader privateKeyTextReader = new StringReader(pkcs8);
            AsymmetricCipherKeyPair privateKeyParams = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();
            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA"); 
            signer.Init(true, privateKeyParams.Private);
            signer.BlockUpdate(payload, 0, payload.Length);
            byte[] signature = signer.GenerateSignature();
            return ByteArrayToString(signature);
        }
        private static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
    }
}
