
namespace AuthZero.AccountService.Domain.Common;

public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// The unique identifier of the entity.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Create a new unique identifier.
    /// </summary>
    public static Guid CreateNewId()
    {
        return Guid.NewGuid();
    }

    public bool Equals(Entity? other)
    {
        return Equals((object?)other);
    }

}