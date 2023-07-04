using TBT.Entities.Items;

namespace TBT.Entities.Characters;

public class Character : Entity, ICharacter
{
    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            if (value < 0) _health = 0;
            else if (value > MaxHealth) _health = MaxHealth;
            else _health = value;
        }
    }
    public int MaxHealth { get; }
    public int Attack { get; }
    public int Speed { get; }
    public ISet<Status> Statuses { get; }
    public Weapon? Weapon { get; set; }
    public Armor? Armor { get; set; }

    public Character(string name, int health, int attack, int speed) : base(name)
    {
        MaxHealth = health;
        Health = health;
        Attack = attack;
        Speed = speed;
        Statuses = new HashSet<Status>();
        Weapon = null;
        Armor = null;
    }

    public int GetArmorDefence() => Armor == null ? 0 : Armor.Defence;

    public int GetWeaponAttack() => Weapon == null ? 0 : Weapon.Attack;

    public void AddStatus(Status status) => Statuses.Add(status);

    public bool RemoveStatus(Status status) => Statuses.Remove(status);

    public void TakeDamage(int damage)
    {
        if (!Statuses.Contains(Status.Invincible))
        {
            Health = Health < damage ? 0 : Health - damage;
        }
    }
}