using NUnit.Framework;
using TBT.Entities.Items.Factories;

namespace Entities.Tests;

public class ArmorFactoryTests
{
    // [SetUp]
    // public void Setup()
    // {

    // }

    [Test]
    public void TestArmorFactory()
    {
        ArmorFactory armorFactory1 = ArmorFactory.Instance;
        ArmorFactory armorFactory2 = ArmorFactory.Instance;
        Assert.AreEqual(armorFactory1, armorFactory2);
        Assert.IsNotEmpty(armorFactory1.Armors);
    }
}