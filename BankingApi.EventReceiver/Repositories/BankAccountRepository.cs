using BankingApi.EventReceiver.Models;

namespace BankingApi.EventReceiver.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankingApiDbContext _context;

        public BankAccountRepository(BankingApiDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccount?> Get(Guid id) => await _context.FindAsync<BankAccount>(id);

        public async Task Update(BankAccount account, CancellationToken cancellationToken)
        {
            _context.Update(account);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
