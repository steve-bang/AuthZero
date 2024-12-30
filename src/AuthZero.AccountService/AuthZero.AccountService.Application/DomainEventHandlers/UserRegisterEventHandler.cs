

using AuthZero.AccountService.Domain.Events;
using Confluent.Kafka;


namespace AuthZero.AccountService.Application.DomainEventHandlers;



public class UserRegisterEventHandler(
    IProducer<string, string> _messageProducer
) : INotificationHandler<UserRegisterEvent>
{

    public async Task Handle(UserRegisterEvent notification, CancellationToken cancellationToken)
    {
        var message = new Message<string, string>{ Key = notification.User.Id.ToString(), Value = notification.User.EmailAddress, Timestamp = new Timestamp(DateTimeOffset.UtcNow) };

        var result = await _messageProducer.ProduceAsync("account-messages", message);

        if (result.Status != PersistenceStatus.Persisted)
        {
            throw new Exception("Failed to produce message");
        }

        Console.WriteLine($"Produced message to topic {result.Topic}, partition {result.Partition}, offset {result.Offset}");

        
    }
}
