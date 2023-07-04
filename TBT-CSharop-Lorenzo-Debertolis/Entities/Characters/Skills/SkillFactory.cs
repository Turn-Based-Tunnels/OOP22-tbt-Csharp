namespace TBT.Entities.Characters.Skills;

public sealed class SkillFactory
{
    public ISet<Skill> Skills { get; }

    private static readonly Lazy<SkillFactory> _lazySkillFactory = new(() => new());
    public static SkillFactory Instance { get { return _lazySkillFactory.Value; } }

    private SkillFactory()
    {
        Skills = new HashSet<Skill> {
            new("Right Hook", 1.1, 1, null, false),
            new("Uppercut", 1.15, 2, null, false),
            new("Super Attack", 1.25, 4, null, true),
            new("Poisonus arrow", 1.1, 2, Status.Poisoned, false)
        };
    }
}
