namespace TBT.Entities.Items.Factories;

public sealed class WeaponFactory
{
    public ISet<Weapon> Weapons { get; }

    private static readonly Lazy<WeaponFactory> _lazyWeaponFactory = new(() => new WeaponFactory());
    public static WeaponFactory Instance { get { return _lazyWeaponFactory.Value; } }

    private WeaponFactory()
    {
        Weapons = new HashSet<Weapon> {
            new("Bronze Weapon", 10, 1000),
            new("Iron Weapon", 25, 3000),
            new("Steel Weapon", 40, 5000)
        };
    }
}
