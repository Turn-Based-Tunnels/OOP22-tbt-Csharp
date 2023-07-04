using TBT.Entities.Items;

namespace TBT.Entities.Characters;

public interface ICharacter : IEntity
{
    int Health { get; set; }
    int MaxHealth { get; }
    int Attack { get; }
    int Speed { get; }
    ISet<Status> Statuses { get; }
    Armor? Armor { get; set; }
    Weapon? Weapon { get; set; }

    void TakeDamage(int damage);

    void AddStatus(Status status);

    bool RemoveStatus(Status status);

    int GetWeaponAttack();

    int GetArmorDefence();
}
