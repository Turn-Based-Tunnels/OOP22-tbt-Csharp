namespace TBT.Entities.Items;

public class Weapon : Item, IEquipement
{
    public int Attack { get; }

    public Weapon(string name, int attack, int value) : base(name, value) => Attack = attack;

    public override string ToString() => Name + " - Attack: " + Attack;
}
