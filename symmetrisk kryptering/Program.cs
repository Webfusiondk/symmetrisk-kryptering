using symmetrisk_kryptering;
using System.Text;

GenerateRandomNumber randomNumber = new GenerateRandomNumber();
AesEnctyption aesEncrypt = new AesEnctyption();
DesEncryption desEncrypt = new DesEncryption();
string dataToEncrypt = "Hello World";
EncryptDes();
EncryptAes();
Console.ReadLine();

void UI(string encryptionType, string unEncrypted, string encrypted, string decrypted)
{
    Console.WriteLine($"Encrypted with {encryptionType}" + "\n");
    Console.WriteLine($"Plain text: {unEncrypted}" + "\n");
    Console.WriteLine($"Encrypted text: {encrypted}" + "\n");
    Console.WriteLine($"Decrypted text: {decrypted}" + "\n");
    Console.WriteLine("-----------------------------------------------------------");
}

//Encrypt dataToEncrypt with DES
void EncryptDes()
{
    byte[] desKey = randomNumber.Generate(8);
    byte[] desIv = randomNumber.Generate(8);
    byte[] desEncrypted = desEncrypt.Encrypt(Encoding.UTF8.GetBytes(dataToEncrypt), desKey, desIv);
    byte[] desDecrypted = desEncrypt.Decrypt(desEncrypted, desKey, desIv);
    UI("DES", dataToEncrypt, Convert.ToBase64String(desEncrypted), Encoding.UTF8.GetString(desDecrypted));
}

//Encrypt dataToEncrypt with AES
void EncryptAes()
{
    byte[] aesKey = randomNumber.Generate(32);
    byte[] aesIv = randomNumber.Generate(16);
    byte[] aesEncrypted = aesEncrypt.Encrypt(Encoding.UTF8.GetBytes(dataToEncrypt), aesKey, aesIv);
    byte[] aesDecrypted = aesEncrypt.Decrypt(aesEncrypted, aesKey, aesIv);
    UI("AES", dataToEncrypt, Convert.ToBase64String(aesEncrypted), Encoding.UTF8.GetString(aesDecrypted));
}
