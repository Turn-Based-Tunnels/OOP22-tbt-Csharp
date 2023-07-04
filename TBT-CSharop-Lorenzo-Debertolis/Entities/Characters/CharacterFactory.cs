using TBT.Entities.Characters.Skills;

namespace TBT.Entities.Characters;

public sealed class CharacterFactory
{
    private static readonly Random RND = new();

    public static Ally CreateAlly(
        string name,
        int health,
        int attack,
        int speed,
        ICollection<Skill> skills
    ) => new(name, health, attack, speed, skills);

    public static Ally CreateAlly(
        string name,
        int health,
        int attack,
        int speed
    ) => new(name, health, attack, speed);

    public static Enemy CreateEnemy(
        string name,
        int health,
        int attack,
        int speed
    ) => new(name, health, attack, speed);

    public static Enemy CreateRandomEnemy(string name, int statsSum)
    {
        long tmpHealth = Math.Abs((long)RND.Next());
        long tmpAttack = Math.Abs((long)RND.Next());
        long tmpSpeed = Math.Abs((long)RND.Next());
        long sum = tmpHealth + tmpAttack + tmpSpeed;
        int statsSumPart = (int)(statsSum * 0.7);
        int res = statsSum / 10;
        return new(
            name,
            (int)(tmpHealth * statsSumPart / sum) + res + 1,
            (int)(tmpAttack * statsSumPart / sum) + res + 1,
            (int)(tmpSpeed * statsSumPart / sum) + res + 1
        );
    }
}
