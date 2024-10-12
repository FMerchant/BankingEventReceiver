
using BankingApi.EventReceiver.Repositories;

namespace BankingApi.EventReceiver.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccount;

        public BankAccountService(IBankAccountRepository bankAccount)
        {
            _bankAccount = bankAccount;
        }

        public async Task CreditToAccount(Guid id, decimal amount, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _bankAccount.Get(id);

                if (account == null)
                {
                    return;
                }

                account.Credit(amount);
                await _bankAccount.Update(account, cancellationToken);
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
                var account = await _bankAccount.Get(id);

                if (account == null)
                {
                    return;
                }

                account.Debit(amount);
                await _bankAccount.Update(account, cancellationToken);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
