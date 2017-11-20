using System.Collections.Generic;
using Nethereum;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Util;

namespace Lykke.Ico.Core.Helpers
{
    public class EthHelper
    {
        public static string GetAddressByPublicKey(string publicKey)
        {
            return new EthECKey(publicKey.HexToByteArray(), false).GetPublicAddress();
        }

        public static bool ValidateAddress(string address)
        {
            var util = new AddressUtil();

            try
            {
                // force investors to use checksum addresses only
                return 
                    (util.IsValidAddressLength(address) || util.IsValidAddressLength(util.ConvertToValid20ByteAddress(address))) && 
                    (util.IsChecksumAddress(address) || util.IsChecksumAddress(util.ConvertToChecksumAddress(address)));
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
                keys.Add(EthECKey.GenerateKey().GetPubKey().ToHex(true));
            }

            return keys.ToArray();
        }
    }
}
