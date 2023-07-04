namespace Dummy.Impl
{
    public static class CharacterFactory
    {
        private static readonly Random RND = new Random();

        private static int GenerateRandomStat(int statSum)
        {
            return RND.Next(statSum / 10) + 1;
        }

        public static Ally CreateAlly(string name, int health, int attack, int speed, List<Skill> skills)
        {
            return new Ally(name, health, attack, speed, skills);
        }

        public static Ally CreateAlly(string name, int health, int attack, int speed)
        {
            return new Ally(name, health, attack, speed, new List<Skill>());
        }

        public static Enemy CreateEnemy(string name, int health, int attack, int speed)
        {
            return new Enemy(name, health, attack, speed);
        }

        public static Enemy CreateRandomEnemy(string name, int statsSum)
        {
            int tmpHealth = statsSum / 3 + 1;
            int tmpAttack = statsSum / 3 + 1;
            int tmpSpeed = statsSum / 3 + 1;
            return new Enemy(
                name,
                (int)(tmpHealth),
                (int)(tmpAttack),
                (int)(tmpSpeed)
            );
        }
    }

}