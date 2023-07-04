using Classes.Impl;
using Dummy.Api;
using Dummy.Impl;

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of the class
        bool allTestPassed = true;
        FightModelImpl model = new FightModelImpl(100, new Dictionary<Item, double>());
        List<Ally> allies = new List<Ally>();
        List<Skill> skill = new List<Skill>();
        skill.Add(new Skill("nome", 1.5, 3, Status.POISONED, false));
        allies.Add(new Ally("Roberto", 100, 100, 10001, skill));
        skill = new List<Skill>();
        skill.Add(new Skill("nome", 1.5, 3, null, true));
        allies.Add(new Ally("Antonio", 100, 100, 10002, skill));
        skill = new List<Skill>();
        skill.Add(new Skill("nome", 1.5, 2, null, false));
        allies.Add(new Ally("Andrea", 100, 100, 1, skill));
        skill = new List<Skill>();
        skill.Add(new Skill("nome", 2.0, 3, null, false));
        allies.Add(new Ally("Francesca", 100, 100, 2, skill));
        Party p = new Party(allies);
        p.AddItemToInventory(new Potion("Name1", 5, 30));
        p.AddItemToInventory(new Potion("Name2", 5, 30));
        p.AddItemToInventory(new Potion("Name3", 5, 30));
        p.AddItemToInventory(new Potion("Name4", 5, 30));
        model.InitializeParty(p);

        Console.WriteLine(allies[0].ToString() + "\n" + allies[1].ToString() + "\n" + allies[2].ToString() + "\n" + allies[3].ToString() + "\n");

        List<Ally> alliesNew = new List<Ally>();
        alliesNew.Add(new Ally(model.GetAllies()[0]));
        alliesNew.Add(new Ally(model.GetAllies()[1]));
        alliesNew.Add(new Ally(model.GetAllies()[2]));
        alliesNew.Add(new Ally(model.GetAllies()[3]));

        Console.WriteLine(alliesNew[0].ToString() + "\n" + alliesNew[1].ToString() + "\n" + alliesNew[2].ToString() + "\n" + alliesNew[3].ToString() + "\n");

        if(alliesNew[0].ToString() == allies[0].ToString() && alliesNew[1].ToString() == allies[1].ToString() && alliesNew[2].ToString() == allies[2].ToString() && alliesNew[3].ToString() == allies[3].ToString())
        {
            Console.WriteLine("true, party initialized correctly\n");
        }
        else
        {
            Console.WriteLine("false, error in initailizing party\n");
            allTestPassed = false;
        }
        
        List<Enemy> enemyList = new List<Enemy>();
        enemyList.Add(new Enemy(model.GetEnemies()[0]));
        enemyList.Add(new Enemy(model.GetEnemies()[1]));
        enemyList.Add(new Enemy(model.GetEnemies()[2]));
        enemyList.Add(new Enemy(model.GetEnemies()[3]));
        Console.WriteLine(enemyList[0].ToString() + "\n" + enemyList[1].ToString() + "\n" + enemyList[2].ToString() + "\n" + enemyList[3].ToString() + "\n");

        // Perform actions and test the functionality
        model.PerformSelectedAction();

        List<Enemy> enemyListNext = new List<Enemy>();
        enemyListNext.Add(new Enemy(model.GetEnemies()[0]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[1]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[2]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[3]));
        Console.WriteLine(enemyListNext[0].ToString() + "\n" + enemyListNext[1].ToString() + "\n" + enemyListNext[2].ToString() + "\n" + enemyListNext[3].ToString() + "\n");

        if (enemyList[0].ToString() == enemyListNext[0].ToString() && enemyList[1].ToString() == enemyListNext[1].ToString() && enemyList[2].ToString() == enemyListNext[2].ToString() && enemyList[3].ToString() == enemyListNext[3].ToString())
        {
            Console.WriteLine("false, enemy didn't take damage from attack\n");
            allTestPassed = false;
        }
        else
        {
            Console.WriteLine("true, enemy took damage\n");
        }

        Enemy en = new Enemy(model.GetSelectedEnemy());
        Console.WriteLine(en.ToString());

        model.SelectNextTarget();

        Enemy enNext = new Enemy(model.GetSelectedEnemy());
        Console.WriteLine(enNext.ToString() + "\n");

        if (en.ToString() != enNext.ToString())
        {
            Console.WriteLine("true, succesfully changed target\n");
        }
        else
        {
            Console.WriteLine("false, target didn't change\n");
            allTestPassed = false;
        }

        enemyList = new List<Enemy>();
        enemyList.Add(new Enemy(model.GetEnemies()[0]));
        enemyList.Add(new Enemy(model.GetEnemies()[1]));
        enemyList.Add(new Enemy(model.GetEnemies()[2]));
        enemyList.Add(new Enemy(model.GetEnemies()[3]));
        Console.WriteLine(enemyList[0].ToString() + "\n" + enemyList[1].ToString() + "\n" + enemyList[2].ToString() + "\n" + enemyList[3].ToString() + "\n");

        model.SelectAction(true, false, false);
        model.SelectNextTarget();
        model.PerformSelectedAction();

        enemyListNext = new List<Enemy>();
        enemyListNext.Add(new Enemy(model.GetEnemies()[0]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[1]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[2]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[3]));
        Console.WriteLine(enemyListNext[0].ToString() + "\n" + enemyListNext[1].ToString() + "\n" + enemyListNext[2].ToString() + "\n" + enemyListNext[3].ToString() + "\n");

        if (enemyList[0].ToString() == enemyListNext[0].ToString() && enemyList[1].ToString() == enemyListNext[1].ToString() && enemyList[2].ToString() == enemyListNext[2].ToString() && enemyList[3].ToString() == enemyListNext[3].ToString())
        {
            Console.WriteLine("false, couldn't use skill\n");
            allTestPassed = false;
        }
        else
        {
            Console.WriteLine("true, skill used\n");
        }

        alliesNew = new List<Ally>();
        alliesNew.Add(new Ally(model.GetAllies()[0]));
        alliesNew.Add(new Ally(model.GetAllies()[1]));
        alliesNew.Add(new Ally(model.GetAllies()[2]));
        alliesNew.Add(new Ally(model.GetAllies()[3]));

        Console.WriteLine(alliesNew[0].ToString() + "\n" + alliesNew[1].ToString() + "\n" + alliesNew[2].ToString() + "\n" + alliesNew[3].ToString() + "\n");

        if (alliesNew[0].HP == alliesNew[0].MaxHP && alliesNew[1].HP == alliesNew[1].MaxHP && alliesNew[2].HP == alliesNew[2].MaxHP && alliesNew[3].HP == alliesNew[3].MaxHP)
        {
            Console.WriteLine("false, allies took no damage from enemy attack\n");
            allTestPassed = false;
        }
        else
        {
            Console.WriteLine("true, allies took damage from enemy attack\n");
        }

        if (model.GetEnemies()[1].Status.Contains(Status.POISONED))
        {
            Console.WriteLine("true, enemy was poisoned by poisonous skill\n");
        }
        else
        {
            Console.WriteLine("false, enemy didn't get poisoned from poisonous skill\n");
            allTestPassed = false;
        }

        model.SelectAction(true, false, false);
        model.SelectAction(false, false, false);
        model.SelectNextTarget();
        model.SelectNextTarget();
        model.PerformSelectedAction();
        model.SelectNextTarget();
        model.PerformSelectedAction();

        enemyListNext = new List<Enemy>();
        enemyListNext.Add(new Enemy(model.GetEnemies()[0]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[1]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[2]));
        enemyListNext.Add(new Enemy(model.GetEnemies()[3]));
        Console.WriteLine(enemyListNext[0].ToString() + "\n" + enemyListNext[1].ToString() + "\n" + enemyListNext[2].ToString() + "\n" + enemyListNext[3].ToString() + "\n");

        if(enemyListNext[0].HP == 0 && enemyListNext[1].HP == 0 && enemyListNext[2].HP == 0 && enemyListNext[3].HP == 0)
        {
            Console.WriteLine("true, all enemies were defeated\n");
        }
        else
        {
            Console.WriteLine("false, not all enemies were defeated\n");
            allTestPassed = false;
        }

        alliesNew = new List<Ally>();
        alliesNew.Add(new Ally(model.GetAllies()[0]));
        alliesNew.Add(new Ally(model.GetAllies()[1]));
        alliesNew.Add(new Ally(model.GetAllies()[2]));
        alliesNew.Add(new Ally(model.GetAllies()[3]));

        model.SelectAction(true, false, false);
        model.SelectAction(false, true, false);
        model.PerformSelectedAction();
        model.SelectAction(false, true, false);
        model.SelectNextTarget();
        model.PerformSelectedAction();
        model.SelectAction(false, true, false);
        model.SelectNextTarget();
        model.SelectNextTarget();
        model.PerformSelectedAction();
        model.SelectAction(false, true, false);
        model.SelectNextTarget();
        model.SelectNextTarget();
        model.SelectNextTarget();
        model.PerformSelectedAction();

        Console.WriteLine(alliesNew[0].ToString() + "\n" + alliesNew[1].ToString() + "\n" + alliesNew[2].ToString() + "\n" + alliesNew[3].ToString() + "\n");

        Console.WriteLine(allies[0].ToString() + "\n" + allies[1].ToString() + "\n" + allies[2].ToString() + "\n" + allies[3].ToString() + "\n");

        if (alliesNew[0].ToString() == allies[0].ToString() && alliesNew[1].ToString() == allies[1].ToString() && alliesNew[2].ToString() == allies[2].ToString() && alliesNew[3].ToString() == allies[3].ToString())
        {
            Console.WriteLine("false, party not healed\n");
            allTestPassed = false;
        }
        else
        {
            Console.WriteLine("true, party healed\n");
        }

        // Output the result
        if (allTestPassed)
        {
            Console.WriteLine("All tests passed");
        }
    }
}
