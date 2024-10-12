using Azure.Messaging.ServiceBus;
using BankingApi.EventReceiver.Model;
using System.Text.Json;

namespace BankingApi.EventReceiver.Services
{
    public class EventManager : IServiceBusReceiver
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusReceiver _serviceBusReceiver;
        private readonly string _queueName;
        public EventManager()
        {
            _queueName = "";
            _serviceBusClient = new ServiceBusClient("", new ServiceBusClientOptions() { RetryOptions = new ServiceBusRetryOptions() { Mode = ServiceBusRetryMode.Exponential, Delay = TimeSpan.FromSeconds(5), MaxRetries = 3 } });
            _serviceBusReceiver = _serviceBusClient.CreateReceiver(_queueName);
        }

        public async Task<EventMessage?> Peek(CancellationToken cancellationToken)
        {
            //The service bus reciver is configured to wait 10 secs for a message before returning a null
            var receivedMessage = await _serviceBusReceiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10), cancellationToken);

            if (receivedMessage != null)
            {
                var jsonMessage = receivedMessage.Body.ToString();
                var message = JsonSerializer.Deserialize<EventMessage>(jsonMessage);
                return message;
            }

            return null;
        }

        public Task Abandon(EventMessage message)
        {
            throw new NotImplementedException();
        }

        public Task Complete(EventMessage message)
        {
            throw new NotImplementedException();
        }

        public Task MoveToDeadLetter(EventMessage message)
        {
            throw new NotImplementedException();
        }


        public Task ReSchedule(EventMessage message, DateTime nextAvailableTime)
        {
            throw new NotImplementedException();
        }
    }
}
