using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class UserPresenter
    {
        IUser? UserView;

        public UserPresenter(IUser view)
        {
            UserView = view;
        }

        public void FindUser()
        {
            LoadUser<User> Load = new LoadUser<User>("UsersData");
            Load.LoadFromFileAsync();
            try
            {
                if (Load.Users != null)
                {
                    foreach (User user in Load.Users)
                    {
                        if (user.Login == UserView.LoginText && user.Password == UserView.PasswordText)
                        {
                            UserView.Message = $"Welcome {user.Login}";
                            break;
                        }
                    }
                    UserView.Message = "there is no this user with the login or password";
                }
                else
                {
                    UserView.Message = "there are no users";
                }
            }
            catch (NullReferenceException) { }

        }

        public AddUser()
        {
            LoadUser<User> Load = new LoadUser<User>("UsersData");
            Load.LoadFromFileAsync();
        }
    }

    public class LoadUser<T>
    {
        public List<T>? Users { get; set; }
        byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
        private string Path;
        public LoadUser(string path) 
        {
            Path = path;
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

        public async Task LoadFromFileAsync()
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
                                string decryptedMessage = await decryptReader.ReadToEndAsync();
                                Users = JsonSerializer.Deserialize<List<T>>(decryptedMessage);
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }

}
