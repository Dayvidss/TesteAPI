using System;
using System.Security.Cryptography;
using System.Text;

namespace Cencosud.TesteAPI.Resources
{
    public class Criptografia
    {
        public static string Base64Cifra(string valor)
        {
            string chaveCripto;
            var cript = ASCIIEncoding.ASCII.GetBytes(valor);
            chaveCripto = Convert.ToBase64String(cript);
            return chaveCripto;
        }

        public static string Base64Decifra(string valor)
        {
            string chaveCripto;
            var cript = Convert.FromBase64String(valor);
            chaveCripto = ASCIIEncoding.ASCII.GetString(cript);
            return chaveCripto;
        }

        static public string MD5Cifra(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        static public string MD5Decifra(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        static public string MD5KeyCifra(string key, string input)
        {
            TripleDESCryptoServiceProvider tripleProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();

            try
            {
                if (input.Trim() != "")
                {
                    tripleProvider.Key = mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
                    tripleProvider.Mode = CipherMode.ECB;
                    ICryptoTransform cryptoTransform = tripleProvider.CreateEncryptor();
                    var buff = Encoding.ASCII.GetBytes(input);

                    return Convert.ToBase64String(cryptoTransform.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                tripleProvider = null;
                mD5 = null;
            }
        }

        static public string MD5KeyDecifra(string key, string input)
        {
            TripleDESCryptoServiceProvider tripleProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();

            try
            {
                if (input.Trim() != "")
                {
                    tripleProvider.Key = mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
                    tripleProvider.Mode = CipherMode.ECB;
                    ICryptoTransform cryptoTransform = tripleProvider.CreateDecryptor();
                    var buff = Convert.FromBase64String(input);

                    return ASCIIEncoding.ASCII.GetString(cryptoTransform.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                tripleProvider = null;
                mD5 = null;
            }
        }

        static public byte[] RSACifra(byte[] byteCifrado, RSAParameters RSAInfo, bool isOAEP)
        {
            try
            {
                byte[] DadosCifrados;

                // Cria a nova instância de RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    // Importa a informação da chave RSA.
                    // Feito apenas para incluir a informação da chave pública
                    RSA.ImportParameters(RSAInfo);

                    // Cria o array de bytes e especifica o preenchimento OAEP
                    DadosCifrados = RSA.Encrypt(byteCifrado, isOAEP);
                }
                return DadosCifrados;
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message);
            }
        }

        static public byte[] RSADecifra(byte[] byteDecifrado, RSAParameters RSAInfo, bool isOAEP)
        {
            try
            {
                byte[] DadosDecifrados;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    // Importa a informação da chave RSA
                    // Isso é preciso para incluir a informação da chave privada.
                    RSA.ImportParameters(RSAInfo);

                    // Decifra o array de bytes e especifica o preenchimento OAEP.
                    DadosDecifrados = RSA.Decrypt(byteDecifrado, isOAEP);
                }
                return DadosDecifrados;
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
