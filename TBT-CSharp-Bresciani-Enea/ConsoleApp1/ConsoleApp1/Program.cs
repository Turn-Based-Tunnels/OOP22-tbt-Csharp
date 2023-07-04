using System;

namespace ConsoleApp1
{
    internal class Program
    {
        // Definizione delle costanti per evitare magic numbers
        const int INT_CONST_10 = 10;
        const int INT_CONST_20 = 20;
        const int INT_CONST_30 = 30;
        const int INT_CONST_50 = 50;
        const int INT_CONST_10000 = 10_000;

        static void Main(string[] args)
        {
            // Test dei metodi di creazione NPC
            TestCreateDialogueNPC();
            TestCreateItemNPC();
            TestCreateShopNPC();
            TestCreateHealerNPC();
            TestCreateFightNPC();
            TestCreateAllyNPC();

            // Se tutti i test hanno avuto successo, viene visualizzato un messaggio di conferma
            Console.WriteLine("All tests passed");
        }

        static void TestCreateDialogueNPC()
        {
            // Creazione di un NPC di tipo "dialogue" utilizzando la NPCFactory
            Api.NPC dialogueNPC = Impl.NPCFactory.CreateDialogueNPC("John", INT_CONST_10, INT_CONST_20,
                INT_CONST_50, INT_CONST_30, "Hello, how can I help you?");

            // Verifica che l'NPC sia un'istanza di DialogueNPCImpl
            if (!(dialogueNPC is Impl.DialogueNPCImpl))
            {
                Console.WriteLine("TestCreateDialogueNPC failed: NPC is not an instance of DialogueNPCImpl");
                return;
            }

            // Verifica delle proprietà dell'NPC
            if (((Impl.DialogueNPCImpl)dialogueNPC).GetName() != "John" ||
                ((Impl.DialogueNPCImpl)dialogueNPC).GetX() != INT_CONST_10 ||
                ((Impl.DialogueNPCImpl)dialogueNPC).GetY() != INT_CONST_20 ||
                ((Impl.DialogueNPCImpl)dialogueNPC).GetHeight() != INT_CONST_50 ||
                ((Impl.DialogueNPCImpl)dialogueNPC).GetWidth() != INT_CONST_30 ||
                ((Impl.DialogueNPCImpl)dialogueNPC).GetDialogue() != "Hello, how can I help you?")
            {
                Console.WriteLine("TestCreateDialogueNPC failed: NPC properties do not match expected values");
                return;
            }
        }

        static void TestCreateItemNPC()
        {
            // Creazione di una mappa di oggetti per l'NPC di tipo "item"
            Dictionary<Dummy.Item, int> items = new Dictionary<Dummy.Item, int>();
            items.Add(new Dummy.Item(), 1);
            items.Add(new Dummy.Item(), 2);

            // Creazione di un NPC di tipo "item" utilizzando la NPCFactory
            Api.NPC itemNPC = Impl.NPCFactory.CreateItemNPC("Merchant",
                INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, items);

            // Verifica che l'NPC sia un'istanza di ItemNPCImpl
            if (!(itemNPC is Impl.ItemNPCImpl))
            {
                Console.WriteLine("TestCreateItemNPC failed: NPC is not an instance of ItemNPCImpl");
                return;
            }

            // Verifica delle proprietà dell'NPC
            if (((Impl.ItemNPCImpl)itemNPC).GetName() != "Merchant" ||
                ((Impl.ItemNPCImpl)itemNPC).GetX() != INT_CONST_10 ||
                ((Impl.ItemNPCImpl)itemNPC).GetY() != INT_CONST_20 ||
                ((Impl.ItemNPCImpl)itemNPC).GetHeight() != INT_CONST_50 ||
                ((Impl.ItemNPCImpl)itemNPC).GetWidth() != INT_CONST_30 ||
                !DictionaryEquals(items, (Dictionary<Dummy.Item, int>)((Impl.ItemNPCImpl)itemNPC).GetItems()))
            {
                Console.WriteLine("TestCreateItemNPC failed: NPC properties do not match expected values");
                return;
            }
        }

        static void TestCreateShopNPC()
        {
            // Creazione di un negozio per l'NPC di tipo "shop"
            Dictionary<Dummy.Item, int> shopMap = new Dictionary<Dummy.Item, int>();
            shopMap.Add(new Dummy.Item(), 1);
            shopMap.Add(new Dummy.Item(), 2);
            Dummy.Shop shop = new Dummy.Shop(shopMap, INT_CONST_10000);

            // Creazione di un NPC di tipo "shop" utilizzando la NPCFactory
            Api.NPC shopNPC = Impl.NPCFactory.CreateShopNPC("Shopkeeper",
                INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, shop);

            // Verifica che l'NPC sia un'istanza di ShopNPCImpl
            if (!(shopNPC is Impl.ShopNPCImpl))
            {
                Console.WriteLine("TestCreateShopNPC failed: NPC is not an instance of ShopNPCImpl");
                return;
            }

            // Verifica delle proprietà dell'NPC
            if (((Impl.ShopNPCImpl)shopNPC).GetName() != "Shopkeeper" ||
                ((Impl.ShopNPCImpl)shopNPC).GetX() != INT_CONST_10 ||
                ((Impl.ShopNPCImpl)shopNPC).GetY() != INT_CONST_20 ||
                ((Impl.ShopNPCImpl)shopNPC).GetHeight() != INT_CONST_50 ||
                ((Impl.ShopNPCImpl)shopNPC).GetWidth() != INT_CONST_30 ||
                !ReferenceEquals(shop, ((Impl.ShopNPCImpl)shopNPC).GetShop()))
            {
                Console.WriteLine("TestCreateShopNPC failed: NPC properties do not match expected values");
                return;
            }
        }

        static void TestCreateHealerNPC()
        {
            // Creazione di un NPC di tipo "healer" utilizzando la NPCFactory
            Api.NPC healerNPC = Impl.NPCFactory.CreateHealerNPC("Healer",
                INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, INT_CONST_10);

            // Verifica che l'NPC sia un'istanza di HealerNPCImpl
            if (!(healerNPC is Impl.HealerNPCImpl))
            {
                Console.WriteLine("TestCreateHealerNPC failed: NPC is not an instance of HealerNPCImpl");
                return;
            }

            // Verifica delle proprietà dell'NPC
            if (((Impl.HealerNPCImpl)healerNPC).GetName() != "Healer" ||
                ((Impl.HealerNPCImpl)healerNPC).GetX() != INT_CONST_10 ||
                ((Impl.HealerNPCImpl)healerNPC).GetY() != INT_CONST_20 ||
                ((Impl.HealerNPCImpl)healerNPC).GetHeight() != INT_CONST_50 ||
                ((Impl.HealerNPCImpl)healerNPC).GetWidth() != INT_CONST_30 ||
                ((Impl.HealerNPCImpl)healerNPC).GetHealAmount() != INT_CONST_10)
            {
                Console.WriteLine("TestCreateHealerNPC failed: NPC properties do not match expected values");
                return;
            }
        }

        static void TestCreateFightNPC()
        {
            // Creazione di un modello di combattimento per l'NPC di tipo "fight"
            Dictionary<Dummy.Item, double> drop = new Dictionary<Dummy.Item, double>();
            drop.Add(new Dummy.Item(), 0.5);
            drop.Add(new Dummy.Item(), 0.5);
            Dummy.FightModel fightModel = new Dummy.FightModel(INT_CONST_10, drop);

            // Creazione di un NPC di tipo "fight" utilizzando la NPCFactory
            Api.NPC fightNPC = Impl.NPCFactory.CreateFightNPC("Enemy", INT_CONST_10,
                INT_CONST_20, INT_CONST_50, INT_CONST_30, fightModel);

            // Verifica che l'NPC sia un'istanza di FightNPCImpl
            if (!(fightNPC is Impl.FightNPCImpl))
            {
                Console.WriteLine("TestCreateFightNPC failed: NPC is not an instance of FightNPCImpl");
                return;
            }

            // Verifica delle proprietà dell'NPC
            if (((Impl.FightNPCImpl)fightNPC).GetName() != "Enemy" ||
                ((Impl.FightNPCImpl)fightNPC).GetX() != INT_CONST_10 ||
                ((Impl.FightNPCImpl)fightNPC).GetY() != INT_CONST_20 ||
                ((Impl.FightNPCImpl)fightNPC).GetHeight() != INT_CONST_50 ||
                ((Impl.FightNPCImpl)fightNPC).GetWidth() != INT_CONST_30 ||
                !ReferenceEquals(fightModel, ((Impl.FightNPCImpl)fightNPC).GetFightModel()))
            {
                Console.WriteLine("TestCreateFightNPC failed: NPC properties do not match expected values");
                return;
            }
        }

        static void TestCreateAllyNPC()
        {
            // Creazione di un alleato per l'NPC di tipo "ally"
            Dummy.Ally ally = new Dummy.Ally("asd", INT_CONST_10, INT_CONST_10, INT_CONST_10, new List<string>());

            // Creazione di un NPC di tipo "ally" utilizzando la NPCFactory
            Api.NPC allyNPC = Impl.NPCFactory.CreateAllyNPC("Friend", INT_CONST_10, INT_CONST_20, INT_CONST_50, INT_CONST_30, ally);

            // Verifica che l'NPC sia un'istanza di AllyNPCImpl
            if (!(allyNPC is Impl.AllyNPCImpl))
            {
                Console.WriteLine("TestCreateAllyNPC failed: NPC is not an instance of AllyNPCImpl");
                return;
            }

            // Verifica delle proprietà dell'NPC
            if (((Impl.AllyNPCImpl)allyNPC).GetName() != "Friend" ||
                ((Impl.AllyNPCImpl)allyNPC).GetX() != INT_CONST_10 ||
                ((Impl.AllyNPCImpl)allyNPC).GetY() != INT_CONST_20 ||
                ((Impl.AllyNPCImpl)allyNPC).GetHeight() != INT_CONST_50 ||
                ((Impl.AllyNPCImpl)allyNPC).GetWidth() != INT_CONST_30 ||
                !ReferenceEquals(ally, ((Impl.AllyNPCImpl)allyNPC).GetAlly()))
            {
                Console.WriteLine("TestCreateAllyNPC failed: NPC properties do not match expected values");
                return;
            }
        }

        static bool DictionaryEquals<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {
            // Verifica che le due mappe siano uguali
            if (dict1.Count != dict2.Count)
                return false;

            foreach (var pair in dict1)
            {
                if (!dict2.TryGetValue(pair.Key, out var value) || !value.Equals(pair.Value))
                    return false;
            }

            return true;
        }
    }
}