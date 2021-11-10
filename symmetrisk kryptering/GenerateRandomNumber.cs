using System.Security.Cryptography;

namespace symmetrisk_kryptering
{
    internal class GenerateRandomNumber
    {
        //Generate random numbers that we return in byte array
        public byte[] Generate(int length)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
