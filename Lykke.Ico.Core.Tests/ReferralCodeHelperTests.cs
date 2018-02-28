using Lykke.Ico.Core.Helpers;
using Xunit;

namespace Lykke.Ico.Core.Tests
{
    public class ReferralCodeHelperTests
    {
        [Fact]
        public void MustGenerateCode()
        {
            var length = 6;
            var code = ReferralCodeHelper.Generate(length);

            Assert.Equal(code.Length, length);
        }
    }
}
