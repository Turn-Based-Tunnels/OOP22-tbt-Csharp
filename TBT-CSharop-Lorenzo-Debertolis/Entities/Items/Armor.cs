namespace TBT.Entities.Items;

public class Armor : Item, IEquipement
{
    public int Defence { get; }

    public Armor(string name, int defence, int value) : base(name, value) => Defence = defence;

    public override string ToString() => Name + " - Defence: " + Defence;
}
