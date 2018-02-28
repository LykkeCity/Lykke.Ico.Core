using System;
using System.Linq;

namespace Lykke.Ico.Core.Helpers
{
    public class ReferralCodeHelper
    {
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Generate(int length)
        {
            var random = new Random();

            return new string(Enumerable
                .Repeat(_chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}
