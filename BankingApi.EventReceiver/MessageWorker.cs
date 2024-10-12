using BankingApi.EventReceiver.Services;

namespace BankingApi.EventReceiver
{
    public class MessageWorker
    {
        private readonly IServiceBusReceiver _serviceBusReceiver;
        public MessageWorker(IServiceBusReceiver serviceBusReceiver)
        {
            _serviceBusReceiver = serviceBusReceiver;
        }

        public async Task Start()
        {
            
        }
    }
}
