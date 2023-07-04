using ConsoleApp1.Api;
using ConsoleApp1.Dummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>ItemNPCImpl</c> class is an implementation of the <see cref="ItemNPC"/> interface.
    /// It extends the <see cref="AbstractNPCImpl"/> class and represents an NPC that provides items to the player's party.
    /// </summary>
    public class ItemNPCImpl : AbstractNPCImpl, Api.ItemNPC//, KillableEntity non di mia competenza
    {
        private readonly IDictionary<Dummy.Item, int> items;
        //private KillObserver killObserver;

        /// <summary>
        /// Constructs a new instance of the ItemNPCImpl class with the specified name, position, dimensions, and items.
        /// </summary>
        /// <param name="name">The name of the item NPC.</param>
        /// <param name="x">The X coordinate of the item NPC's position.</param>
        /// <param name="y">The Y coordinate of the item NPC's position.</param>
        /// <param name="height">The height of the item NPC.</param>
        /// <param name="width">The width of the item NPC.</param>
        /// <param name="items">The map of items provided by the NPC and their quantities.</param>
        public ItemNPCImpl(string name, int x, int y, int height, int width, IDictionary<Dummy.Item, int> items)
            : base(name, x, y, height, width)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            if (items == null)
            {
                throw new ArgumentException("Items cannot be null", nameof(items));
            }

            this.items = new Dictionary<Dummy.Item, int>(items);
            //this.killObserver = null;
        }

        /// <summary>
        /// Gets the map of items provided by the NPC and their quantities.
        /// </summary>
        /// <returns>The items map.</returns>
        public IDictionary<Dummy.Item, int> GetItems()
        {
            return new Dictionary<Dummy.Item, int>(items);
        }

        Dictionary<Item, int> ItemNPC.GetItems()
        {
            throw new NotImplementedException();
        }

        /*
         * 
         * 
        /// <summary>
        /// Handles the interaction with the NPC.
        /// </summary>
        /// <param name="interactable">The spatial entity triggering the interaction.</param>
        public void OnInteraction(SpatialEntity interactable)
        {
            if (!(interactable is IParty party))
            {
                throw new ArgumentException("Interactable must be an instance of IParty");
            }

            foreach (KeyValuePair<Item, int> entry in items)
            {
                for (int count = 0; count < entry.Value; count++)
                {
                    party.AddItemToInventory(entry.Key);
                }
            }

            killObserver?.OnKill(this);
        }

        /// <summary>
        /// Sets the kill observer for the NPC.
        /// </summary>
        /// <param name="killObserver">The kill observer.</param>
        public void SetKillObserver(KillObserver killObserver)
        {
            this.killObserver = killObserver;
        }
        */
    }
}
