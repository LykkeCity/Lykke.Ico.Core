using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Lykke.Ico.Core.Helpers
{
    public class EncryptionHelper
    {
        public static string Encrypt(string message, string key, string iv)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var ivBytes = Encoding.UTF8.GetBytes(iv);

            using (var aes = Aes.Create())
            {
                using (var encryptor = aes.CreateEncryptor(keyBytes, ivBytes))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(messageBytes, 0, messageBytes.Length);
                            csEncrypt.FlushFinalBlock();

                            var encryptedBytes = msEncrypt.ToArray();
                            var base64String = Convert.ToBase64String(encryptedBytes);

                            return WebUtility.UrlEncode(base64String);
                        }
                    }
                }
            }
        }

        public static string Decrypt(string encodedMessage, string key, string iv)
        {
            var decodedMessage = WebUtility.UrlDecode(encodedMessage);
            var message = Convert.FromBase64String(decodedMessage);
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var ivBytes = Encoding.UTF8.GetBytes(iv);

            using (var aes = Aes.Create())
            {
                using (var decryptor = aes.CreateDecryptor(keyBytes, ivBytes))
                {
                    using (var msDecrypt = new MemoryStream(message))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
