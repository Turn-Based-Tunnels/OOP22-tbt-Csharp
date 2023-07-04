namespace TBT.Entities.Items.Factories;

public sealed class AntidoteFactory
{
    public Antidote Antidote { get; }

    private static readonly Lazy<AntidoteFactory> _lazyAntidoteFactory = new(() => new());
    public static AntidoteFactory Instance { get { return _lazyAntidoteFactory.Value; } }

    private AntidoteFactory() => Antidote = new(100);
}
