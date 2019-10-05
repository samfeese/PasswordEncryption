using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PasswordEncryption
{
    public static class Users
    {
        public static Dictionary<string, string> userAccount = new Dictionary<string, string> { };

        public static void UserInput (string username, string password)
        {
            string hashPassword = HashPass(password);

            userAccount.Add(username, hashPassword);

        }

        private static string HashPass(string password)
        {
            //This Initializes the Hash
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //This returns the byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Convert the byte array to a string
                StringBuilder build = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    build.Append(bytes[i].ToString("x2"));
                }
                return build.ToString();
            }
           

        }
        public static string GetHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //This returns the byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Convert the byte array to a string
                StringBuilder build = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    build.Append(bytes[i].ToString("x2"));
                }
                return build.ToString();
            }
        }


    }


}
