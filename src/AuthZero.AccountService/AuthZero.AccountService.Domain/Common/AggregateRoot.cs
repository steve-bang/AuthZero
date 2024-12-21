
namespace AuthZero.AccountService.Domain.Common;

public abstract class AggregateRoot : Entity
{


    // /// <summary>
    // /// The events that have been applied to the aggregate root.
    // /// </summary>
    // private readonly List<IDomainEvent> _events = new();

    // /// <summary>
    // /// The events that have been applied to the aggregate root.
    // /// </summary>
    // public IReadOnlyList<IDomainEvent> Events => _events.AsReadOnly();

    // /// <summary>
    // /// Apply a domain event to the aggregate root.
    // /// </summary>
    // /// <param name="event">The domain event to apply.</param>
    // protected void Apply(IDomainEvent @event)
    // {
    //     _events.Add(@event);
    //     Version++;
    // }

    // /// <summary>
    // /// Clear the events that have been applied to the aggregate root.
    // /// </summary>
    // public void ClearEvents()
    // {
    //     _events.Clear();
    // }
}