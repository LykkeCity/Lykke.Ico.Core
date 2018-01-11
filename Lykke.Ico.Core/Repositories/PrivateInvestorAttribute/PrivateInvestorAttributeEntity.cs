using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.PrivateInvestorAttribute
{
    internal class PrivateInvestorAttributeEntity : TableEntity
    {
        public string Email { get; set; }

        public static PrivateInvestorAttributeEntity Create(string email)
        {
            return new PrivateInvestorAttributeEntity
            {
                Email = email
            };
        }
    }
}
