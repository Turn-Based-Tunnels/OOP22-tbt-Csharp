namespace Dummy.Impl
{   
    public class Skill
    {
        private string _name;
        public double AttackMultiplier { get; }
        public int Cooldown { get; }
        public int RemainingCooldown { get; set; }
        public Nullable<Status> PossibleStatus { get; }
        public bool IncProbCritical { get; } // increased probability of critical damage

        public Skill(string name, double attackMultiplier, int cooldown, Nullable<Status> possibleStatus, bool incProbCritical)
        {
            this._name = name;
            this.AttackMultiplier = attackMultiplier;
            this.Cooldown = cooldown;
            this.RemainingCooldown = 0;
            this.PossibleStatus = possibleStatus;
            this.IncProbCritical = incProbCritical;
        }

        public void DecreaseCooldown()
        {
            if (RemainingCooldown > 0)
            {
                this.RemainingCooldown--;
            }
        }

        public void ResetCooldown()
        {
            this.RemainingCooldown = Cooldown;
        }
    }
}