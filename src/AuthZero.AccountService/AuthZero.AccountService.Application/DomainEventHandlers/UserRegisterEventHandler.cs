

using AuthZero.AccountService.Domain.Events;


namespace AuthZero.AccountService.Application.DomainEventHandlers;



public class UserRegisterEventHandler : INotificationHandler<UserRegisterEvent>
{


    public async Task Handle(UserRegisterEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("User registered.");
        Console.WriteLine($"User: {notification.User.EmailAddress}");
    }
}
