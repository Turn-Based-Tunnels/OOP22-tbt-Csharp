namespace TBT.Entities;

public interface ISpatialEntity : IEntity
{
    int X { get; }
    int Y { get; }
    int Height { get; }
    int Width { get; }
}
