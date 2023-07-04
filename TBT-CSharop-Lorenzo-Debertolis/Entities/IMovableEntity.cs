namespace TBT.Entities;

public interface IMovableEntity : ISpatialEntity
{
    new int X { get; set; }
    new int Y { get; set; }
}
