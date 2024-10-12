using BankingApi.EventReceiver.Services;

namespace BankingApi.EventReceiver
{
    public class MessageWorker
    {
        private readonly IServiceBusReceiver _serviceBusReceiver;
        private readonly IBankAccountService _bankAccountService;
        public MessageWorker(IServiceBusReceiver serviceBusReceiver, IBankAccountService bankAccountService)
        {
            _serviceBusReceiver = serviceBusReceiver;
            _bankAccountService = bankAccountService;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var message = await _serviceBusReceiver.Peek(cancellationToken);

                if (message == null) return;

                switch (message.MessageType)
                {
                    case "Credit":
                        await _bankAccountService.CreditToAccount(message.BankAccountId, message.Amount, cancellationToken);
                        await _serviceBusReceiver.Complete(message);
                        break;
                    case "Debit":
                        await _bankAccountService.DebitFromAccount(message.BankAccountId, message.Amount, cancellationToken);
                        await _serviceBusReceiver.Complete(message);
                        break;
                    default:
                        await _serviceBusReceiver.MoveToDeadLetter(message);
                        break;
                }
            }
        }
    }
}
