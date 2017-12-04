using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.EmailHistory
{
    public  interface IInvestorEmailRepository
    {
        Task<IEnumerable<IInvestorEmail>> GetAsync(string email);

        Task SaveAsync(string type, string email, string subject, string body);

        Task RemoveAsync(string email);
    }
}
