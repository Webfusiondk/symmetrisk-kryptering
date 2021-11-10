using System.Security.Cryptography;

namespace symmetrisk_kryptering
{
    internal class AesEnctyption
    {
        //Encrypt data using the key and iv
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(),CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        //Decrypt the encrypted data we send in with the key and iv
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(),CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    var decryptBytes = memoryStream.ToArray();

                    return decryptBytes;
                }
            }
        }
    }
}
