using NUnit.Framework;
using TBT.Entities.Characters.Skills;

namespace Entities.Tests;

public class SkillFactoryTests
{
    [Test]
    public void TestSkillFactory()
    {
        SkillFactory skillFactory1 = SkillFactory.Instance;
        SkillFactory skillFactory2 = SkillFactory.Instance;
        Assert.AreEqual(skillFactory1, skillFactory2);
        Assert.IsNotEmpty(skillFactory1.Skills);
    }
}