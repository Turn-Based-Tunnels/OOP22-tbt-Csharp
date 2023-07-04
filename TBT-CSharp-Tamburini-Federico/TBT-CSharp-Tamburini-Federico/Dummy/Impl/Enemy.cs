using System.Linq;

namespace Dummy.Impl
{
    public class Enemy : Character
    {
        private string _name;
        public int HP { get; set; }

        public int MaxHP { get; }

        public int Attack { get; }

        public int Speed { get; }
        public List<Status> Status { get; }
        public Enemy(string name, int hp, int atk, int speed)
        {
            this._name = name;
            this.Speed = speed;
            this.Attack = atk;
            this.HP = hp;
            this.MaxHP = hp;
            Status = new List<Status>();
        }
        public Enemy(Enemy enemy)
        {
            this.HP = enemy.HP;
            this.MaxHP = enemy.MaxHP;
            this.Attack = enemy.Attack;
            this.Speed = enemy.Speed;
            this._name = enemy._name;
            Status = enemy.Status;
        }
        public void AddStatus(Status status)
        {
            this.Status.Add(status);
        }

        public int GetArmorDefence()
        {
            return 0;
        }

        public List<Status> GetStatuses()
        {
            return this.Status;
        }

        public int GetWeaponAttack()
        {
            return 0;
        }

        public bool RemoveStatus(Status status)
        {
            throw new NotImplementedException();
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
            return;
        }

        public void EquipeArmor(int armor)
        {
            return;
        }
        public override string ToString()
        {
            return this._name + ", " + this.MaxHP + ", " + this.HP + ", " + this.Attack + ", " + this.Speed;
        }
    }

}