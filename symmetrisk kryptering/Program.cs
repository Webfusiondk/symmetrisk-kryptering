using symmetrisk_kryptering;
using System.Diagnostics;
using System.Text;

GenerateRandomNumber randomNumber = new GenerateRandomNumber();
AesEnctyption aesEncrypt = new AesEnctyption();
DesEncryption desEncrypt = new DesEncryption();
string dataToEncrypt = "Hello World";
string hex = ConvertStringToHex();
EncryptDes();
EncryptAes();
Console.ReadLine();

void UI(string encryptionType, string timeTilDone,string unEncrypted, string encrypted, string decrypted, string key, string iv, string hex)
{
    Console.WriteLine($"Encrypted with {encryptionType}" + "\n");
    Console.WriteLine($"Key {key}");
    Console.WriteLine($"Iv {iv}");
    Console.WriteLine($"Plain text: {unEncrypted}");
    Console.WriteLine($"Plain text in HEX: {hex}");
    Console.WriteLine($"StopWatch time in ticks: {timeTilDone}");
    Console.WriteLine($"Encrypted text: {encrypted}");
    Console.WriteLine($"Decrypted text: {decrypted}");
    Console.WriteLine("-----------------------------------------------------------");
}

//Encrypt dataToEncrypt with DES
void EncryptDes()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();
    byte[] desKey = randomNumber.Generate(8);
    byte[] desIv = randomNumber.Generate(8);
    byte[] desEncrypted = desEncrypt.Encrypt(Encoding.UTF8.GetBytes(dataToEncrypt), desKey, desIv);
    byte[] desDecrypted = desEncrypt.Decrypt(desEncrypted, desKey, desIv);
    sw.Stop();
    string stopWatchTime = sw.ElapsedTicks.ToString();
    UI("DES", stopWatchTime, dataToEncrypt, Convert.ToBase64String(desEncrypted), Encoding.UTF8.GetString(desDecrypted), Convert.ToBase64String(desKey), Convert.ToBase64String(desIv),hex);
}

//Encrypt dataToEncrypt with AES
void EncryptAes()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();
    byte[] aesKey = randomNumber.Generate(32);
    byte[] aesIv = randomNumber.Generate(16);
    byte[] aesEncrypted = aesEncrypt.Encrypt(Encoding.UTF8.GetBytes(dataToEncrypt), aesKey, aesIv);
    byte[] aesDecrypted = aesEncrypt.Decrypt(aesEncrypted, aesKey, aesIv);
    sw.Stop();
    string stopWatchTime = sw.ElapsedTicks.ToString();
    UI("AES", stopWatchTime, dataToEncrypt, Convert.ToBase64String(aesEncrypted), Encoding.UTF8.GetString(aesDecrypted), Convert.ToBase64String(aesKey), Convert.ToBase64String(aesIv),hex);
}

string ConvertStringToHex()
{
    byte[] ba = Encoding.UTF8.GetBytes(dataToEncrypt);
    var hexString = BitConverter.ToString(ba);
    hexString = hexString.Replace("-", "");
    return hexString;
}
