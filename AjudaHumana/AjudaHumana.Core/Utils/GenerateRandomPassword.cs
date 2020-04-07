using System;
using System.Linq;

namespace AjudaHumana.Core.Utils
{
    public static class GenerateRandomPassword
    {
        private static readonly Random random = new Random();
        public static string Generate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
