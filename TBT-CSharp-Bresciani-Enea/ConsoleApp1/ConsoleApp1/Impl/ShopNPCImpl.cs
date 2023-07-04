using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>ShopNPCImpl</c> class represents an implementation of a shop NPC.
    /// </summary>
    public class ShopNPCImpl : AbstractNPCImpl, Api.ShopNPC//, StateTrigger non di mia competenza
    {
        private readonly Dummy.Shop shop;
        //private StateObserver stateObserver;

        /// <summary>
        /// Creates a shop NPC with the specified name, position, dimensions, and shop.
        /// </summary>
        /// <param name="name">The name of the shop NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="shop">The shop associated with the NPC.</param>
        /// <exception cref="ArgumentNullException">Thrown when the name or shop is null.</exception>
        public ShopNPCImpl(string name, int x, int y, int height, int width, Dummy.Shop shop)
            : base(name, x, y, height, width)
        {
            this.shop = shop ?? throw new ArgumentNullException(nameof(shop), "Shop cannot be null");
        }

        /// <summary>
        /// Gets the shop associated with the NPC.
        /// </summary>
        /// <returns>The shop associated with the NPC.</returns>
        public Dummy.Shop GetShop()
        {
            return shop;
        }

        /*
         * implementazioni di intrafaccie e classi non di mia competenza
         * 
        /// <summary>
        /// Handles the interaction with an interactable entity.
        /// </summary>
        /// <param name="interactable">The interactable entity.</param>
        public void OnInteraction(SpatialEntity interactable)
        {
            if (interactable is IParty party)
            {
                shop.Party = party;
                if (stateObserver == null)
                {
                    throw new InvalidOperationException("StateObserver not set");
                }
                stateObserver.OnShop(shop);
            }
        }

        /// <summary>
        /// Sets the state observer for the NPC.
        /// </summary>
        /// <param name="stateObserver">The state observer.</param>
        public void SetStateObserver(StateObserver stateObserver)
        {
            this.stateObserver = stateObserver;
        }
        */
    }
}
