using System;
using Lykke.AzureStorage.Tables;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.InvestorAttribute
{
    internal class InvestorAttributeEntity : TableEntity
    {
        public string Email { get; set; }

        public static InvestorAttributeEntity Create(string email)
        {
            return new InvestorAttributeEntity
            {
                Email = email
            };
        }
    }
}
