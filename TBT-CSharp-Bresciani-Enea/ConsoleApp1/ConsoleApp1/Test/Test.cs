using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConsoleApp1.Dummy;
using ConsoleApp1.Impl;
using ConsoleApp1.Api;
namespace ConsoleApp1.Test

{
    [TestFixture]
    class NPCFactoryTest
    {
        // Constants to mitigate MagicNumber alerts
        private const int INT_CONST_10 = 10;
        private const int INT_CONST_20 = 20;
        private const int INT_CONST_30 = 30;
        private const int INT_CONST_50 = 50;
        private const int INT_CONST_10000 = 10000;

        [Test]
        public void TestCreateDialogueNPC()
        {
            // Create a dialogue NPC using the NPCFactory
            NPC dialogueNPC = NPCFactory.CreateDialogueNPC("John", INT_CONST_10, INT_CONST_20,
                INT_CONST_50, INT_CONST_30, "Hello, how can I help you?");

            // Assert that the NPC is an instance of DialogueNPCImpl
            Assert.IsTrue(dialogueNPC is DialogueNPCImpl);

            // Assert the properties of the NPC
            Assert.AreEqual("John", ((DialogueNPCImpl)dialogueNPC).GetName());
            Assert.AreEqual(INT_CONST_10, ((DialogueNPCImpl)dialogueNPC).GetX());
            Assert.AreEqual(INT_CONST_20, ((DialogueNPCImpl)dialogueNPC).GetY());
            Assert.AreEqual(INT_CONST_50, ((DialogueNPCImpl)dialogueNPC).GetHeight());
            Assert.AreEqual(INT_CONST_30, ((DialogueNPCImpl)dialogueNPC).GetWidth());
            Assert.AreEqual("Hello, how can I help you?", ((DialogueNPCImpl)dialogueNPC).GetDialogue());
        }

        [Test]
        public void TestCreateItemNPC()
        {
            // Create a map of items for the item NPC
            Dictionary<Item, int> items = new Dictionary<Item, int>();
            items[new Item()] = 1;
            items[new Item()] = 2;

            // Create an item NPC using the NPCFactory
            NPC itemNPC = NPCFactory.CreateItemNPC("Merchant",
                INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, items);

            // Assert that the NPC is an instance of ItemNPCImpl
            Assert.IsTrue(itemNPC is ItemNPCImpl);

            // Assert the properties of the NPC
            Assert.AreEqual("Merchant", ((ItemNPCImpl)itemNPC).GetName());
            Assert.AreEqual(INT_CONST_10, ((ItemNPCImpl)itemNPC).GetX());
            Assert.AreEqual(INT_CONST_20, ((ItemNPCImpl)itemNPC).GetY());
            Assert.AreEqual(INT_CONST_50, ((ItemNPCImpl)itemNPC).GetHeight());
            Assert.AreEqual(INT_CONST_30, ((ItemNPCImpl)itemNPC).GetWidth());
            Assert.AreEqual(items, ((ItemNPCImpl)itemNPC).GetItems());
        }

        [Test]
        public void TestCreateShopNPC()
        {
            // Create a shop for the shop NPC
            Dictionary<Item, int> shopMap = new Dictionary<Item, int>();
            shopMap[new Item()] = 1;
            shopMap[new Item()] = 2;
            Shop shop = new Shop(shopMap, INT_CONST_10000);

            // Create a shop NPC using the NPCFactory
            NPC shopNPC = NPCFactory.CreateShopNPC("Shopkeeper",
                INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, shop);

            // Assert that the NPC is an instance of ShopNPCImpl
            Assert.IsTrue(shopNPC is ShopNPCImpl);

            // Assert the properties of the NPC
            Assert.AreEqual("Shopkeeper", ((ShopNPCImpl)shopNPC).GetName());
            Assert.AreEqual(INT_CONST_10, ((ShopNPCImpl)shopNPC).GetX());
            Assert.AreEqual(INT_CONST_20, ((ShopNPCImpl)shopNPC).GetY());
            Assert.AreEqual(INT_CONST_50, ((ShopNPCImpl)shopNPC).GetHeight());
            Assert.AreEqual(INT_CONST_30, ((ShopNPCImpl)shopNPC).GetWidth());
            Assert.AreEqual(shop, ((ShopNPCImpl)shopNPC).GetShop());
        }

        [Test]
        public void TestCreateHealerNPC()
        {
            // Create a healer NPC using the NPCFactory
            NPC healerNPC = NPCFactory.CreateHealerNPC("Healer",
                INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, INT_CONST_10);

            // Assert that the NPC is an instance of HealerNPCImpl
            Assert.IsTrue(healerNPC is HealerNPCImpl);

            // Assert the properties of the NPC
            Assert.AreEqual("Healer", ((HealerNPCImpl)healerNPC).GetName());
            Assert.AreEqual(INT_CONST_10, ((HealerNPCImpl)healerNPC).GetX());
            Assert.AreEqual(INT_CONST_20, ((HealerNPCImpl)healerNPC).GetY());
            Assert.AreEqual(INT_CONST_50, ((HealerNPCImpl)healerNPC).GetHeight());
            Assert.AreEqual(INT_CONST_30, ((HealerNPCImpl)healerNPC).GetWidth());
            Assert.AreEqual(INT_CONST_10, ((HealerNPCImpl)healerNPC).GetHealAmount());
        }

        [Test]
        public void TestCreateFightNPC()
        {
            // Create a fight model for the fight NPC
            Dictionary<Item, double> drop = new Dictionary<Item, double>();
            drop[new Item()] = 0.5;
            drop[new Item()] = 0.5;
            FightModel fightModel = new FightModel(INT_CONST_10, drop);

            // Create a fight NPC using the NPCFactory
            NPC fightNPC = NPCFactory.CreateFightNPC("Enemy", INT_CONST_10,
                INT_CONST_20, INT_CONST_50, INT_CONST_30, fightModel);

            // Assert that the NPC is an instance of FightNPCImpl
            Assert.IsTrue(fightNPC is FightNPCImpl);

            // Assert the properties of the NPC
            Assert.AreEqual("Enemy", ((FightNPCImpl)fightNPC).GetName());
            Assert.AreEqual(INT_CONST_10, ((FightNPCImpl)fightNPC).GetX());
            Assert.AreEqual(INT_CONST_20, ((FightNPCImpl)fightNPC).GetY());
            Assert.AreEqual(INT_CONST_50, ((FightNPCImpl)fightNPC).GetHeight());
            Assert.AreEqual(INT_CONST_30, ((FightNPCImpl)fightNPC).GetWidth());
            Assert.AreEqual(fightModel, ((FightNPCImpl)fightNPC).GetFightModel());
        }

        [Test]
        public void TestCreateAllyNPC()
        {
            // Create an ally for the ally NPC
            Ally ally = new Ally("asd", INT_CONST_10, INT_CONST_10, INT_CONST_10, new List<string>());

            // Create an ally NPC using the NPCFactory
            NPC allyNPC = NPCFactory.CreateAllyNPC("Friend", INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, ally);

            // Assert that the NPC is an instance of AllyNPCImpl
            Assert.IsTrue(allyNPC is AllyNPCImpl);

            // Assert the properties of the NPC
            Assert.AreEqual("Friend", ((AllyNPCImpl)allyNPC).GetName());
            Assert.AreEqual(INT_CONST_10, ((AllyNPCImpl)allyNPC).GetX());
            Assert.AreEqual(INT_CONST_20, ((AllyNPCImpl)allyNPC).GetY());
            Assert.AreEqual(INT_CONST_50, ((AllyNPCImpl)allyNPC).GetHeight());
            Assert.AreEqual(INT_CONST_30, ((AllyNPCImpl)allyNPC).GetWidth());
            Assert.AreEqual(ally, ((AllyNPCImpl)allyNPC).GetAlly());
        }
    }
}
