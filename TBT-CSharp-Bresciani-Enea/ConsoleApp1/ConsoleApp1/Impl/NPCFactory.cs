using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>NPCFactory</c> class provides static methods for creating different types of NPCs.
    /// </summary>
    public static class NPCFactory
    {
        /// <summary>
        /// Creates a dialogue NPC with the specified name, position, dimensions, and dialogue.
        /// </summary>
        /// <param name="name">The name of the dialogue NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="dialogue">The dialogue of the NPC.</param>
        /// <returns>The created dialogue NPC.</returns>
        public static Api.NPC CreateDialogueNPC(string name, int x, int y, int height, int width, string dialogue)
        {
            return new DialogueNPCImpl(name, x, y, height, width, dialogue);
        }

        /// <summary>
        /// Creates an item NPC with the specified name, position, dimensions, and items.
        /// </summary>
        /// <param name="name">The name of the item NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="items">The map of items provided by the NPC and their quantities.</param>
        /// <returns>The created item NPC.</returns>
        public static Api.NPC CreateItemNPC(string name, int x, int y, int height, int width, Dictionary<Dummy.Item, int> items)
        {
            return new ItemNPCImpl(name, x, y, height, width, items);
        }

        /// <summary>
        /// Creates a shop NPC with the specified name, position, dimensions, and shop.
        /// </summary>
        /// <param name="name">The name of the shop NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="shop">The shop associated with the NPC.</param>
        /// <returns>The created shop NPC.</returns>
        public static Api.NPC CreateShopNPC(string name, int x, int y, int height, int width, Dummy.Shop shop)
        {
            return new ShopNPCImpl(name, x, y, height, width, shop);
        }

        /// <summary>
        /// Creates a healer NPC with the specified name, position, dimensions, and heal amount.
        /// </summary>
        /// <param name="name">The name of the healer NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="healAmount">The amount of health the NPC can heal.</param>
        /// <returns>The created healer NPC.</returns>
        public static Api.NPC CreateHealerNPC(string name, int x, int y, int height, int width, int healAmount)
        {
            return new HealerNPCImpl(name, x, y, height, width, healAmount);
        }

        /// <summary>
        /// Creates a fight NPC with the specified name, position, dimensions, and fight model.
        /// </summary>
        /// <param name="name">The name of the fight NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="fightModel">The fight model associated with the NPC.</param>
        /// <returns>The created fight NPC.</returns>
        public static Api.NPC CreateFightNPC(string name, int x, int y, int height, int width, Dummy.FightModel fightModel)
        {
            return new FightNPCImpl(name, x, y, height, width, fightModel);
        }

        /// <summary>
        /// Creates an ally NPC with the specified name, position, dimensions, and ally.
        /// </summary>
        /// <param name="name">The name of the ally NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <param name="ally">The ally associated with the NPC.</param>
        /// <returns>The created ally NPC.</returns>
        public static Api.NPC CreateAllyNPC(string name, int x, int y, int height, int width, Dummy.Ally ally)
        {
            return new AllyNPCImpl(name, x, y, height, width, ally);
        }
    }
}
