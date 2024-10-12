using BankingApi.EventReceiver.Models;

namespace BankingApi.EventReceiver.Repositories
{
    public interface IBankAccountRepository
    {
        Task<BankAccount?> Get(Guid id);

        Task Update(BankAccount account, CancellationToken cancellationToken);
    }
}
