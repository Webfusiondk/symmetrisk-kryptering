using System.Security.Cryptography;

namespace symmetrisk_kryptering
{
    internal class DesEncryption
    {
        
        //Encrypt data using the key and iv
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        //Decrypt the encrypted data we send in with the key and iv
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }



    }
}
