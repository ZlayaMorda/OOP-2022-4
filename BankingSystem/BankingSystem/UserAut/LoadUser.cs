using System.Security.Cryptography;
using System.Text.Json;

namespace UserAut
{
    public class LoadUser<T>
    {
        public List<T> Users;
        byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
        private string Path;
        public LoadUser(string Path)
        {
            this.Path = Path;
            Users = new List<T>();
        }

        public void LoadToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
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
                                encryptWriter.WriteLine(JsonSerializer.Serialize(Users));
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
                                    Users = JsonSerializer.Deserialize<List<T>>(decryptedMessage);
                                    //List<T>? temp = JsonSerializer.Deserialize<List<T>>(decryptedMessage);
                                    //MessageBox.Show(temp.ToString());
                                }
                                //else
                                //{
                                //    Users = new List<T>();
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
