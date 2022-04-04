using System.Security.Cryptography;
using System.Text.Json;
using System.Configuration;

namespace BankingSystem.Loading
{
    internal class Load<K,T>
    {
        public Dictionary<K,T> Information;
        byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
        private string Path;
        public Load(string bank, string fileName)
        {
            this.Path = $"{ConfigurationManager.AppSettings.Get("DirectoryToProject")}/{bank}/{bank}{fileName}";
            Information = new Dictionary<K,T>();
        }

        public void LoadToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Create))
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        byte[] iv = aes.IV;
                        fs.Write(iv, 0, iv.Length);

                        using (CryptoStream cryptoStream = new(fs, aes.CreateEncryptor(),
                                                                CryptoStreamMode.Write))
                        {
                            using (StreamWriter encryptWriter = new(cryptoStream))
                            {
                                encryptWriter.WriteLine(JsonSerializer.Serialize(Information));
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public void LoadFromFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] iv = new byte[aes.IV.Length];
                        int numBytesToRead = aes.IV.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            int n = fs.Read(iv, numBytesRead, numBytesToRead);
                            if (n == 0) break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        using (CryptoStream cryptoStream = new(fs, aes.CreateDecryptor(key, iv),
                                                                CryptoStreamMode.Read))
                        {
                            using (StreamReader decryptReader = new(cryptoStream))
                            {
                                string decryptedMessage = decryptReader.ReadToEnd();
                                if (!string.IsNullOrEmpty(decryptedMessage))
                                {
                                    Information = JsonSerializer.Deserialize<Dictionary<K,T>>(decryptedMessage);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        public void AddToFile(T temp, K key)
        {
            LoadFromFile();
            Information.Add(key, temp);
            LoadToFile();
        }
    }

}
