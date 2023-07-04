using NUnit.Framework;
using TBT.Entities.Items.Factories;

namespace Entities.Tests;

public class PotionFactoryTests
{
    [Test]
    public void TestPotionFactory()
    {
        PotionFactory PotionFactory1 = PotionFactory.Instance;
        PotionFactory PotionFactory2 = PotionFactory.Instance;
        Assert.AreEqual(PotionFactory1, PotionFactory2);
        Assert.IsNotEmpty(PotionFactory1.Potions);
    }
}