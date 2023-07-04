using NUnit.Framework;
using TBT.Entities.Items.Factories;

namespace Entities.Tests;

public class AntidoteFactoryTests
{
    [Test]
    public void TestAntidoteFactory()
    {
        AntidoteFactory antidoteFactory1 = AntidoteFactory.Instance;
        AntidoteFactory antidoteFactory2 = AntidoteFactory.Instance;
        Assert.AreEqual(antidoteFactory1, antidoteFactory2);
    }
}