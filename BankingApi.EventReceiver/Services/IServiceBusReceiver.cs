﻿using BankingApi.EventReceiver.Model;

namespace BankingApi.EventReceiver.Services
{
    public interface IServiceBusReceiver
    {
        Task<EventMessage?> Peek();

        Task Abandon(EventMessage message);
        
        Task Complete(EventMessage message);
        Task ReSchedule(EventMessage message, DateTime nextAvailableTime);
        Task MoveToDeadLetter(EventMessage message);
    }
}
