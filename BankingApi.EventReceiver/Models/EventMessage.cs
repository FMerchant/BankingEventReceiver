﻿namespace BankingApi.EventReceiver.Model;

public class EventMessage
{
    public Guid Id { get; set; }
    public string MessageType { get; set; }
    public Guid BankAccountId { get; set; }
    public decimal Amount { get; set; }
}