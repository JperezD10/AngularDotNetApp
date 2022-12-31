using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace Services
{
    public class CryptService
    {
        public static string Crypt(string contraseña)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);
            return transformByte(hash);
        }

        private static string transformByte(byte[] hash)
        {
            StringBuilder hex = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash) hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
