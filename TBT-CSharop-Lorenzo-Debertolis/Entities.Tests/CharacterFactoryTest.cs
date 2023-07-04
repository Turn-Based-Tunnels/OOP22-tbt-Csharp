using NUnit.Framework;
using TBT.Entities.Characters;

namespace Entities.Tests;

public class CharacterFactoryTests
{
    [Test]
    public void TestCreateAlly()
    {
        Ally ally = CharacterFactory.CreateAlly("Test", 50, 20, 10);
        Assert.IsEmpty(ally.Statuses);
        Assert.Null(ally.Weapon);
        Assert.Zero(ally.GetWeaponAttack());
        Assert.Null(ally.Armor);
        Assert.Zero(ally.GetArmorDefence());
        Assert.AreEqual(ally.Health, ally.MaxHealth);
        ally.TakeDamage(20);
        Assert.AreEqual(ally.Health, ally.MaxHealth - 20);
        ally.TakeDamage(1000);
        Assert.Zero(ally.Health);
        ally.Health = 1000;
        Assert.AreEqual(ally.Health, ally.MaxHealth);
        ally.Health = -1000;
        Assert.Zero(ally.Health);
    }

    [Test]
    public void TestCreateRandomEnemy()
    {
        Enemy enemy = CharacterFactory.CreateRandomEnemy("Test", 100);
        Assert.GreaterOrEqual(enemy.Attack, 1);
        Assert.GreaterOrEqual(enemy.Health, 1);
        Assert.GreaterOrEqual(enemy.Speed, 1);
        Assert.IsEmpty(enemy.Statuses);
        Assert.Null(enemy.Weapon);
        Assert.Zero(enemy.GetWeaponAttack());
        Assert.Null(enemy.Armor);
        Assert.Zero(enemy.GetArmorDefence());
        Assert.AreEqual(enemy.Health, enemy.MaxHealth);
        enemy.TakeDamage(20);
        Assert.AreEqual(enemy.Health, enemy.MaxHealth - 20);
        enemy.TakeDamage(1000);
        Assert.Zero(enemy.Health);
        enemy.Health = 1000;
        Assert.AreEqual(enemy.Health, enemy.MaxHealth);
        enemy.Health = -1000;
        Assert.Zero(enemy.Health);
    }
}