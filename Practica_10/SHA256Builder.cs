using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Drawing;

namespace Practica_10
{
    internal class SHA256Builder
    {
        public static string ConvertToHash(string text)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder sd = new StringBuilder();
            foreach (byte h in hash)
                sd.Append(h.ToString("X2"));
            return sd.ToString();
        }
    }
}
