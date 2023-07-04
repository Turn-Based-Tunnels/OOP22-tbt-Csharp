namespace Dummy.Impl
{
    public class Ally : Character
    {
        public string Name { get; }
        public int MaxHP { get; }
        public int HP { get; set; }
        public int Attack { get; }
        public int Speed { get; }
        public List<Status> Status { get; }

        private List<Skill> skills;
        public Ally(string name, int hp, int atk, int speed)
        {
            this.Name = name;
            this.MaxHP = hp;
            this.HP = hp;
            this.Attack = atk;
            this.Speed = speed;
            this.skills = new List<Skill>();
            Status = new List<Status>();
        }

        public Ally(string name, int hp, int atk, int speed, List<Skill> skills)
        {
            this.Name = name;
            this.MaxHP = hp;
            this.HP = hp;
            this.Attack = atk;
            this.Speed = speed;
            this.skills = skills;
            Status = new List<Status>();
        }

        public Ally(Ally ally)
        {
            this.Name = ally.Name;
            this.MaxHP = ally.MaxHP;
            this.HP = ally.HP;
            this.Attack = ally.Attack;
            this.Speed = ally.Speed;
            this.skills = ally.GetSkills();
            Status = ally.Status;
        }

        public List<Skill> GetSkills()
        {
            return this.skills;
        }

        public void TakeDamage(int damage)
        {
            this.HP -= damage;
            if (HP < 0)
            {
                HP = 0;
            }
        }

        public void SetHealth(int health)
        {
            this.HP = health;
            if (HP < 0)
            {
                HP = 0;
            }
        }

        public void AddStatus(Status status)
        {
            this.Status.Add(status);
        }

        public bool RemoveStatus(Status status)
        {
            if (this.Status.Contains(status))
            {
                this.Status.Remove(status);
                return true;
            }
            return false;
        }

        public int GetWeaponAttack()
        {
            return 5; //test value
        }

        public int GetArmorDefence()
        {
            return 5; //test value
        }

        public int? GetWeapon()
        {
            return 5; //test value
        }

        public int? GetArmor()
        {
            return 5; //test value
        }

        public void EquipeWeapon(int weapon)
        {
            //test method
        }

        public void EquipeArmor(int armor)
        {
            //test method
        }

        public override string ToString()
        {
            return this.Name + ", " + this.MaxHP + ", " + this.HP + ", " + this.Attack + ", " + this.Speed + ", " + skills.ToString();
        }
    }
}