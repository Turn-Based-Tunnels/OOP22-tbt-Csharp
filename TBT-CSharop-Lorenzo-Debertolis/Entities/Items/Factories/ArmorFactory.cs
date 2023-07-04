namespace TBT.Entities.Items.Factories;

public sealed class ArmorFactory
{
    public ISet<Armor> Armors { get; }

    private static readonly Lazy<ArmorFactory> _lazyArmorFactory = new(() => new());
    public static ArmorFactory Instance { get { return _lazyArmorFactory.Value; } }

    private ArmorFactory()
    {
        Armors = new HashSet<Armor>{
            new("Bronze Armor", 10, 1000),
            new("Iron Armor", 25, 3000),
            new("Steel Armor", 40, 5000)
        };
    }
}
