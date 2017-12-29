using Lykke.Ico.Core.Helpers;
using Xunit;

namespace Lykke.Job.IcoJobEmail.Tests
{
    public class EncryptionHelperTests
    {
        [Fact]
        public void MustEncryptDecrypt()
        {
            var message = "Example test";
            var key = "E546C8DF278CD5931069B522E695D4F2";
            var iv = "1234567890123456";

            var encrypted = EncryptionHelper.Encrypt(message, key, iv);
            var decprypted = EncryptionHelper.Decrypt(encrypted, key, iv);

            Assert.Equal(message, decprypted);
        }
    }
}
