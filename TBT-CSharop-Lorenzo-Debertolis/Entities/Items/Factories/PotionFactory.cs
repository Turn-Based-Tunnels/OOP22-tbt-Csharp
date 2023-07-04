namespace TBT.Entities.Items.Factories;

public sealed class PotionFactory
{
    public ISet<Potion> Potions { get; }

    private static readonly Lazy<PotionFactory> _lazyPotionFactory = new(() => new());
    public static PotionFactory Instance { get { return _lazyPotionFactory.Value; } }

    private PotionFactory()
    {
        Potions = new HashSet<Potion> {
            new("Basic Potion", 20, 100),
            new("Medium Potion", 35, 200),
            new("High Potion", 50, 300)
        };
    }
}
