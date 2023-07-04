namespace Dummy.Impl
{
    public interface Character
    {
        int HP { get; }
        int MaxHP { get; }
        int Attack { get; }
        int Speed { get; }
        List<Status> Status { get; }

        void TakeDamage(int damage);
        void SetHealth(int health);
        void AddStatus(Status status);
        bool RemoveStatus(Status status);
        int GetWeaponAttack();
        int GetArmorDefence();
        Nullable<int> GetWeapon();
        Nullable<int> GetArmor();
        void EquipeWeapon(int weapon);
        void EquipeArmor(int armor);
    }
}