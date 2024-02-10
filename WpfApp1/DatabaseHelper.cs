using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    internal class DatabaseHelper
    {
        private static string connectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=1234;" +
            "Database=Users;";

        public static void CreateUser(User user)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                if (UserExists(user.UserName, conn))
                {
                    MessageBox.Show("Данный ник уже занят");
                    return;
                }

                using (var cmd = new NpgsqlCommand("INSERT INTO Users (UserName, PasswordHash, Salt) VALUES (@UserName, @PasswordHash, @Salt)", conn))
                {
                    cmd.Parameters.AddWithValue("UserName", user.UserName);
                    cmd.Parameters.AddWithValue("PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("Salt", user.Salt);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool CheckUserAuthentication(string username, string password)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT PasswordHash, Salt FROM Users WHERE UserName = @UserName", conn))
                {
                    cmd.Parameters.AddWithValue("UserName", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] storedPasswordHash = (byte[])reader["PasswordHash"];
                            byte[] salt = (byte[])reader["Salt"];

                            byte[] enteredPasswordHash = GenerateHash(password, salt);

                            return CompareByteArrays(storedPasswordHash, enteredPasswordHash);
                        }
                    }
                }
            }

            return false;
        }

        private protected static bool UserExists(string username, NpgsqlConnection conn)
        {
            using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM Users WHERE UserName = @UserName", conn))
            {
                cmd.Parameters.AddWithValue("UserName", username);

                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        internal static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        internal static byte[] GenerateHash(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedBytes = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                return sha256.ComputeHash(combinedBytes);
            }
        }

        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null || array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }
    }
}