namespace TBT.Entities.Items;

public class Antidote : Item, IConsumable
{
    public Antidote(string name, int value) : base(name, value) { }
    public Antidote(int value) : base("Antidote", value) { }
}