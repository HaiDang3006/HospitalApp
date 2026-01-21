using BenhVienS.Helper_Service;
using BenhVienS.Models;
using System;
using System.IO;
using Newtonsoft.Json;

namespace BenhVienS.Common
{
    static class SessionManager
    {
        private static readonly string _path =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BenhVienS", "session.dat"
            );

        public static void Save(UserSession session)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path));
            string json = JsonConvert.SerializeObject(session);
            var encrypted = CryptoHelper.Encrypt(json);
            File.WriteAllBytes(_path, encrypted);
        }

        public static UserSession Load()
        {
            if (!File.Exists(_path)) return null;
            var encrypted = File.ReadAllBytes(_path);
            var json = CryptoHelper.Decrypt(encrypted);
            var session = JsonConvert.DeserializeObject<UserSession>(json);
            if (session.ExpiredAt < DateTime.Now)
            {
                Clear();
                return null;
            }

            return session;
        }

        public static void Clear()
        {
            if (File.Exists(_path))
                File.Delete(_path);
        }
    }
}