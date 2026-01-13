using System;

namespace Shared.Contracts.Events;

public class OrderCreatedEvent
{
    public long OrderId { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}
