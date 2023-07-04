using Dummy.Impl;

namespace Dummy.Api
{
    public interface IParty
    {
        bool AddMember(Ally ally);
        bool RemoveMember(Ally ally);
        void AddCash(int amount);
        Dictionary<Item, int> GetInventory();
        void AddItemToInventory(Item item);
        bool RemoveItemFromInventory(Item item);
    }
}