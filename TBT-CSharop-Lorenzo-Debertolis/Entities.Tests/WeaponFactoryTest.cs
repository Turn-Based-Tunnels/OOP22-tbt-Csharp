using NUnit.Framework;
using TBT.Entities.Items.Factories;

namespace Entities.Tests;

public class WeaponFactoryTests
{
    [Test]
    public void TestWeaponFactory()
    {
        WeaponFactory WeaponFactory1 = WeaponFactory.Instance;
        WeaponFactory WeaponFactory2 = WeaponFactory.Instance;
        Assert.AreEqual(WeaponFactory1, WeaponFactory2);
        Assert.IsNotEmpty(WeaponFactory1.Weapons);
    }
}