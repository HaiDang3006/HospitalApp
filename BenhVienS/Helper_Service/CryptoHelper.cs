using System;
using System.Text;
using System.Security.Cryptography;

namespace BenhVienS.Helper_Service
{
    internal class CryptoHelper
    {
        public static byte[] Encrypt(string text)
        {
            var data = Encoding.UTF8.GetBytes(text);
            return ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        }

        public static string Decrypt(byte[] data)
        {
            var raw = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(raw);
        }
    }
}
