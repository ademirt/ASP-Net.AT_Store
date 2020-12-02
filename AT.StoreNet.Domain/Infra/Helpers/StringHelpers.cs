using System;
using System.Security.Cryptography;
using System.Text;

namespace AT.StoreNet.Domain.Infra.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            var salt = "|6F5A13AE3D9140B69CE319777CEB0F9FC5C907BED03044EFBAACEB0951DCCF5B";

            var arrBytes = Encoding.UTF8.GetBytes(senha + salt);

            byte[] hashBytes;

            using (var sha = SHA512.Create())
            {
                hashBytes = sha.ComputeHash(arrBytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }
}
