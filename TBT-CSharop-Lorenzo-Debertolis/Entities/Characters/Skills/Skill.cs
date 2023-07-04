using System.Text.Json.Serialization;

namespace TBT.Entities.Characters.Skills;

public class Skill : Entity
{
    public double AttackMultiplier { get; }
    public int Cooldown { get; }
    public int RemainingCooldown { get; private set; }
    public Status? PossibleStatus { get; }
    public bool IncProbCritical { get; }

    protected internal Skill(
        string name,
        double attackMultiplier,
        int cooldown,
        Status? possibleStatus,
        bool incProbCritical
    ) : base(name)
    {
        AttackMultiplier = attackMultiplier;
        Cooldown = cooldown;
        RemainingCooldown = 0;
        PossibleStatus = possibleStatus;
        IncProbCritical = incProbCritical;
    }

    public void DecreaseCooldown()
    {
        if (RemainingCooldown > 0) RemainingCooldown--;
    }

    public void ResetCooldown() => RemainingCooldown = Cooldown;
}
