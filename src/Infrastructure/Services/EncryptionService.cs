using Core.Interfaces;
using Core.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly string _key;

        public EncryptionService(string key)
        {
            _key = Encoding.UTF8.GetString(EnsureKeySize(key, 16));
        }

        public EncryptedData Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return new EncryptedData(Convert.ToBase64String(ms.ToArray()));

                    }
                }
            }
        }

        public string Decrypt(EncryptedData cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText.Data)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static byte[] EnsureKeySize(string key, int size)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            if (keyBytes.Length > size)
            {
                Array.Resize(ref keyBytes, size);
            }
            else if (keyBytes.Length < size)
            {
                Array.Resize(ref keyBytes, size);
                for (int i = keyBytes.Length; i < size; i++)
                {
                    keyBytes[i] = 0; // Padding with zeros
                }
            }

            return keyBytes;
        }
    }
}