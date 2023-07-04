namespace TBT.Entities;

public class SpatialEntity : Entity, ISpatialEntity
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; }
    public int Width { get; }

    public SpatialEntity(
        string name,
        int x,
        int y,
        int width,
        int height) : base(name)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}
