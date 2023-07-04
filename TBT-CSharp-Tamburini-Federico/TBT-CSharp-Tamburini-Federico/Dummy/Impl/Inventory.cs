using System.Collections;
using Dummy.Api;


namespace Dummy.Impl
{
    public class Inventory : IEnumerable<Inventory>, IEnumerable
    {
        public Dictionary<Item, int> Items { get; }

        public Inventory()
        {
            this.Items = new Dictionary<Item, int>();
        }

        public Inventory(IEnumerable<Item> newItems)
        {
            this.Items = new Dictionary<Item, int>();
            foreach (var item in newItems)
            {
                this.Items[item] = 1;
            }
        }

        public Inventory(Dictionary<Item, int> newItems)
        {
            this.Items = new Dictionary<Item, int>(newItems);
        }

        public Dictionary<Item, int> GetItems()
        {
            return new Dictionary<Item, int>(this.Items);
        }

        public void AddItem(Item item)
        {
            if (this.Items.ContainsKey(item))
            {
                this.Items[item]++;
            }
            else
            {
                this.Items[item] = 1;
            }
        }

        public bool RemoveItem(Item item)
        {
            if (this.Items.ContainsKey(item))
            {
                int count = this.Items[item];
                if (count > 1)
                {
                    this.Items[item] = count - 1;
                }
                else
                {
                    this.Items.Remove(item);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<Inventory> GetEnumerator()
        {
            return (IEnumerator<Inventory>)this.Items;
            //fonte soluzione: https://stackoverflow.com/questions/62670596/foreach-statement-cannot-operate-on-variables-of-type-table1-because-table1
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}