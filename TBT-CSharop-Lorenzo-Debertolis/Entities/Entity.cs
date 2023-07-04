namespace TBT.Entities;

public class Entity : IEntity
{
    public string Name { get; }
    public Entity(string name) => Name = name;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Entity e = (Entity)obj;
        return Name == e.Name;
    }

    public override int GetHashCode() => Name.GetHashCode();
}
