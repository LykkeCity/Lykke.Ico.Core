using System.Collections.Generic;
using NBitcoin;

namespace Lykke.Ico.Core.Helpers
{
    public class BtcHelper
    {
        public static string GetAddressByPublicKey(string publicKey, string networkName)
        {
            return new PubKey(publicKey).GetAddress(GetNetwork(networkName)).ToString();
        }

        public static bool ValidateAddress(string address, string networkName)
        {
            try
            {
                return BitcoinAddress.Create(address).Network == GetNetwork(networkName);
            }
            catch
            {
                return false;
            }
        }

        public static string[] GeneratePublicKeys(int count)
        {
            var keys = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                keys.Add(new Key().PubKey.ToHex());
            }

            return keys.ToArray();
        }

        public static Network GetNetwork(string networkName)
        {
            return Network.GetNetwork(networkName) ?? Network.RegTest;
        }
    }
}
