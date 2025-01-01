
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.Domain.Common;

namespace AuthZero.AccountService.Domain.Events
{
    public class UserRegisterEvent : IDomainEvent
    {
        public User User { get; }

        public UserRegisterEvent(User user)
        {
            User = user;
        }
    }
}