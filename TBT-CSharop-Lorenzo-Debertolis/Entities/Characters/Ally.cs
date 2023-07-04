using TBT.Entities.Characters.Skills;

namespace TBT.Entities.Characters;

public class Ally : Character
{
    public List<Skill> Skills { get; }

    public Ally(
        string name,
        int health,
        int attack,
        int speed,
        ICollection<Skill> skills
    ) : base(name, health, attack, speed)
    {
        Skills = new List<Skill>(skills);
    }

    public Ally(
        string name,
        int health,
        int attack,
        int speed
    ) : base(name, health, attack, speed)
    {
        Skills = new List<Skill>();
    }

    public void AddSkill(Skill skill) => Skills.Add(skill);
}