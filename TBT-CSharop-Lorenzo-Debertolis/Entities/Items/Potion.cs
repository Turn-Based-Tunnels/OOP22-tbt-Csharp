namespace TBT.Entities.Items;

public class Potion : Item, IConsumable
{
    public int HealPower { get; }

    public Potion(string name, int healPower, int value) : base(name, value) => HealPower = healPower;

    public override string ToString() => Name + " - Heal: " + HealPower;
}