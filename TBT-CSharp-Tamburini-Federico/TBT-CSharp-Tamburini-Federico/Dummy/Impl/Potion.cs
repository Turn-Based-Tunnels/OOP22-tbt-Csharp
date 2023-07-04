using Dummy.Api;

namespace Dummy.Impl
{
    public class Potion : Item
    {
        private string _name;
        public int Value { get; }
        public int HealPower { get; }
        public Potion(string name, int value, int healPower)
        {
            _name = name;
            this.Value = value;
            this.HealPower = healPower;
        }

        public override string ToString()
        {
            return $"{this._name} - Heal: {HealPower}";
        }
    }

}