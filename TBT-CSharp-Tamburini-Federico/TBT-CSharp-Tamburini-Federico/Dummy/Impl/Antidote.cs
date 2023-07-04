using Dummy.Api;

namespace Dummy.Impl
{
    public class Antidote : Item
    {
        private string _name;
        public int Value { get; }
        public Antidote(string name, int value)
        {
            this._name = name;
            this.Value = value;
        }
    }
}