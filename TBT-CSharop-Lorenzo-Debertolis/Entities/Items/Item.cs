namespace TBT.Entities.Items;

public class Item : Entity, IItem
{
    public int Value { get; }

    public Item(string name, int value) : base(name) => Value = value;

    public override string ToString() => "Item: " + Name;
}
