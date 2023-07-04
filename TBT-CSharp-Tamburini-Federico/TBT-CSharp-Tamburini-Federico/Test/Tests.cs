using Dummy.Api;
using Dummy.Impl;
using NUnit.Framework;

namespace FightModelImpl.Test
{
    [TestFixture]
    internal class Tests
    {
        private Classes.Impl.FightModelImpl _model = default!;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the class
            _model = new Classes.Impl.FightModelImpl(100, new Dictionary<Item, double>());
            List<Ally> allies = new List<Ally>();
            List<Skill> skill = new List<Skill>();
            skill.Add(new Skill("nome", 1.5, 3, Status.POISONED, false));
            allies.Add(new Ally("Roberto", 100, 100, 10001, skill));
            skill = new List<Skill>();
            skill.Add(new Skill("nome", 1.5, 3, Status.POISONED, true));
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
            _model.InitializeParty(p);
        }

        [Test]
        public void TestAllyAttack()
        {
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(new Enemy(_model.GetEnemies()[0]));
            enemyList.Add(new Enemy(_model.GetEnemies()[1]));
            enemyList.Add(new Enemy(_model.GetEnemies()[2]));
            enemyList.Add(new Enemy(_model.GetEnemies()[3]));

            // Perform actions and test the functionality
            _model.PerformSelectedAction();

            List<Enemy> enemyListNext = new List<Enemy>();
            enemyListNext.Add(new Enemy(_model.GetEnemies()[0]));
            enemyListNext.Add(new Enemy(_model.GetEnemies()[1]));
            enemyListNext.Add(new Enemy(_model.GetEnemies()[2]));
            enemyListNext.Add(new Enemy(_model.GetEnemies()[3]));

            Assert.AreNotEqual(enemyList[0].ToString(), enemyListNext[0].ToString());

            //attack should have damaged enemy
        }

        [Test]
        public void TestChangeTarget()
        {
            Enemy en = new Enemy(_model.GetSelectedEnemy());
            Console.WriteLine(en.ToString());

            _model.SelectNextTarget();

            Enemy enNext = new Enemy(_model.GetSelectedEnemy());
            Console.WriteLine(enNext.ToString() + "\n");

            Assert.AreNotEqual(en, enNext);

            //enemies should be different
        }

        [Test]
        public void TestSkillAndPoison()
        {
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(new Enemy(_model.GetEnemies()[0]));
            enemyList.Add(new Enemy(_model.GetEnemies()[1]));
            enemyList.Add(new Enemy(_model.GetEnemies()[2]));
            enemyList.Add(new Enemy(_model.GetEnemies()[3]));

            _model.SelectAction(true, false, false);
            _model.PerformSelectedAction();

            List<Enemy> enemyListNext = new List<Enemy>();
            enemyListNext.Add(new Enemy(_model.GetEnemies()[0]));
            enemyListNext.Add(new Enemy(_model.GetEnemies()[1]));
            enemyListNext.Add(new Enemy(_model.GetEnemies()[2]));
            enemyListNext.Add(new Enemy(_model.GetEnemies()[3]));

            Assert.AreNotEqual(enemyList[0].ToString(), enemyListNext[0].ToString());

            //skill should have damaged enemy

            Assert.Contains(Status.POISONED, enemyList[0].GetStatuses());

            //skill should have poisoned enemy
        }

        [Test]
        public void TestEnemyAttack()
        {
            List<Ally> allies = new List<Ally>();
            allies.Add(new Ally(_model.GetAllies()[0]));
            allies.Add(new Ally(_model.GetAllies()[1]));
            allies.Add(new Ally(_model.GetAllies()[2]));
            allies.Add(new Ally(_model.GetAllies()[3]));

            _model.PerformSelectedAction();
            _model.SelectNextTarget();
            _model.PerformSelectedAction();

            //should be enemies turn

            List<Ally> alliesNew = new List<Ally>();
            alliesNew.Add(new Ally(_model.GetAllies()[0]));
            alliesNew.Add(new Ally(_model.GetAllies()[1]));
            alliesNew.Add(new Ally(_model.GetAllies()[2]));
            alliesNew.Add(new Ally(_model.GetAllies()[3]));

            Assert.AreNotEqual(allies[0].ToString() + allies[1].ToString() + allies[2].ToString() + allies[3].ToString(), alliesNew[0].ToString() + alliesNew[1].ToString() + alliesNew[2].ToString() + alliesNew[3].ToString());

            //allies should have taken damage
        }

        [Test]
        public void TestUsePotions()
        {
            _model.PerformSelectedAction();
            _model.SelectNextTarget();
            _model.PerformSelectedAction();

            //allies take damage

            List<Ally> allies = new List<Ally>();
            allies.Add(new Ally(_model.GetAllies()[0]));
            allies.Add(new Ally(_model.GetAllies()[1]));
            allies.Add(new Ally(_model.GetAllies()[2]));
            allies.Add(new Ally(_model.GetAllies()[3]));

            _model.SelectAction(false, true, false);
            _model.PerformSelectedAction();
            _model.SelectAction(false, true, false);
            _model.SelectNextTarget();
            _model.PerformSelectedAction();
            _model.SelectAction(false, true, false);
            _model.SelectNextTarget();
            _model.SelectNextTarget();
            _model.PerformSelectedAction();
            _model.SelectAction(false, true, false);
            _model.SelectNextTarget();
            _model.SelectNextTarget();
            _model.SelectNextTarget();
            _model.PerformSelectedAction();

            //allies should've healed
            
            List<Ally> alliesNew = new List<Ally>();
            alliesNew.Add(new Ally(_model.GetAllies()[0]));
            alliesNew.Add(new Ally(_model.GetAllies()[1]));
            alliesNew.Add(new Ally(_model.GetAllies()[2]));
            alliesNew.Add(new Ally(_model.GetAllies()[3]));

            Assert.AreNotEqual(allies[0].HP + allies[1].HP + allies[2].HP + allies[3].HP, alliesNew[0].HP + alliesNew[1].HP + alliesNew[2].HP + alliesNew[3].HP);
        }
    }
}
