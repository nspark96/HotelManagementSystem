using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NLF_INTRANET.Comman.Utility
{
    public class Cipher
    {
        public static string AESEncrypt(string text)
        {
            try
            {
                string secretKey = ConfigurationManager.AppSettings["SecurityKey"].ToString();
                SHA1 sha = new SHA1CryptoServiceProvider();
                RijndaelManaged aes = new RijndaelManaged();

                byte[] finalKey = new byte[16]; // Used to generate finalKey


                //byte[] byteDataToEncrypt = Convert.FromBase64String(text); // Converting Base64 data to Byte Array
                byte[] byteDataToEncrypt = Encoding.UTF8.GetBytes(text);
                byte[] byteSecretKey = Encoding.UTF8.GetBytes(secretKey); // Converting secret key in byte array
                byte[] hashSecretKey = sha.ComputeHash(byteSecretKey); // geneating hash in byte array of secret key

                Array.Copy(hashSecretKey, finalKey, 16); // copying fist 16 bytes from hashed secret key to finaly key which to use in algo

                aes.KeySize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.ECB;
                aes.Key = finalKey;

                using (ICryptoTransform Encrypt = aes.CreateEncryptor(aes.Key, null)) //Passing IV as NULL because IV is not present in the Java Code
                {
                    byte[] dest = Encrypt.TransformFinalBlock(byteDataToEncrypt, 0, byteDataToEncrypt.Length);
                    Encrypt.Dispose();
                    return Convert.ToBase64String(dest);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string AESDecrypt(string text)
        {
            try
            {
                string secretKey = ConfigurationManager.AppSettings["SecurityKey"].ToString();
                SHA1 sha = new SHA1CryptoServiceProvider();
                RijndaelManaged aes = new RijndaelManaged();

                byte[] finalKey = new byte[16]; // Used to generate finalKey
                byte[] byteDataToDecrypt = Convert.FromBase64String(text); // Converting Base64 data to Byte Array
                byte[] byteSecretKey = Encoding.UTF8.GetBytes(secretKey); // Converting secret key in byte array
                byte[] hashSecretKey = sha.ComputeHash(byteSecretKey); // geneating hash in byte array of secret key

                Array.Copy(hashSecretKey, finalKey, 16); // copying fist 16 bytes from hashed secret key to finaly key which to use in algo

                aes.KeySize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.ECB;
                aes.Key = finalKey;

                using (ICryptoTransform decrypt = aes.CreateDecryptor(aes.Key, null)) //Passing IV as NULL because IV is not present in the Java Code
                {
                    byte[] dest = decrypt.TransformFinalBlock(byteDataToDecrypt, 0, byteDataToDecrypt.Length);
                    decrypt.Dispose();
                    return Encoding.UTF8.GetString(dest);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
