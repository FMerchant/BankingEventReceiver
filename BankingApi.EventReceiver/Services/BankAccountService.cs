
using BankingApi.EventReceiver.Repositories;

namespace BankingApi.EventReceiver.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task CreditToAccount(Guid id, decimal amount, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _bankAccountRepository.GetAccount(id);

                if (account == null)
                {
                    return;
                }

                account.Credit(amount);
                await _bankAccountRepository.UpdateAccount(account, cancellationToken);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task DebitFromAccount(Guid id, decimal amount, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _bankAccountRepository.GetAccount(id);

                if (account == null)
                {
                    return;
                }

                account.Debit(amount);
                await _bankAccountRepository.UpdateAccount(account, cancellationToken);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
