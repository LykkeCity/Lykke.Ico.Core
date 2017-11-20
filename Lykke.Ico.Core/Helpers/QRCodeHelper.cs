using QRCoder;

namespace Lykke.Ico.Core.Helpers
{
    public class QRCodeHelper
    {
        public static byte[] GenerateQRPng(string address)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrGenerator.CreateQrCode(address, QRCodeGenerator.ECCLevel.Q))
                {
                    using (var code = new PngByteQRCode(qrCodeData))
                    {
                        return code.GetGraphic(20);
                    }
                }
            }
        }
    }
}
