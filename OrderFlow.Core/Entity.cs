namespace OrderFlow.Core;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected init; }

    protected Entity(Guid id) => Id = id;
    
    public bool Equals(Entity? other) =>
        other is not null && GetType() == other.GetType() && Id == other.Id;

    public override bool Equals(object? obj) => Equals(obj as Entity);
    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
    
    public static bool operator ==(Entity? left, Entity? right) =>
        left is null ? right is null : left.Equals(right);
    public static bool operator !=(Entity? left, Entity? right) => !(left == right);
}

public class AgregateRoot : Entity
{
    protected AgregateRoot(Guid id) : base(id) { }
}
