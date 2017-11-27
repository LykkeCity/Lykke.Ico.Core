﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public interface IAddressPoolRepository
    {
        Task AddBatchAsync(List<IAddressPoolItem> keys);

        Task<IAddressPoolItem> GetNextFree(string email);
    }
}
