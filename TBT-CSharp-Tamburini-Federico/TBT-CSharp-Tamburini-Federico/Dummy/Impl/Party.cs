using Dummy.Api;

namespace Dummy.Impl
{
    public class Party : IParty
    {
        public List<Ally> Members { get; set; }
        public int Wallet { get; set; }
        public Inventory Inventory { get; }

        public Party(string name)
        {
            Members = new List<Ally>();
            Inventory = new Inventory();
        }

        public Party(List<Ally> c)
        {
            Members = new List<Ally>(c);
            Inventory = new Inventory();
        }

        public bool AddMember(Ally ally)
        {
            Members.Add(ally);
            return true;
        }

        public bool RemoveMember(Ally ally)
        {
            return Members.Remove(ally);
        }

        public void AddCash(int amount)
        {
            Wallet += amount;
        }

        public Dictionary<Item, int> GetInventory()
        {
            return Inventory.GetItems();
        }

        public void AddItemToInventory(Item item)
        {
            Inventory.AddItem(item);
        }

        public bool RemoveItemFromInventory(Item item)
        {
            return Inventory.RemoveItem(item);
        }

    }

}