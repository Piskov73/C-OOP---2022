using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroes;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Test_Hero_Name", 5);
        heroes = new HeroRepository();
    }
    [Test]
    public void Test_HeroConstructor()
    {
        Assert.NotNull(hero);
        Assert.AreEqual("Test_Hero_Name", hero.Name);
        Assert.AreEqual(5, hero.Level);
    }
    [Test]
    public void Test_HeroRepositoriCreate()
    {

        string expected = $"Successfully added hero {hero.Name} with level {hero.Level}";

        string actual = heroes.Create(hero);

        Assert.AreEqual(expected, actual);

        Assert.Throws<InvalidOperationException>(()=>heroes.Create(hero), $"Hero with name {hero.Name} already exists");

        hero = null;
        Assert.Throws<ArgumentNullException>(() => heroes.Create(hero), "Hero is null");
    }
    [Test]
    public void Test_HeroRepositoriRemove()
    {
        heroes.Create(hero);
        Assert.True(heroes.Remove("Test_Hero_Name"));
        Assert.False(heroes.Remove("Test_Hero_Name"));

        string name = null;

        Assert.Throws<ArgumentNullException>(() => heroes.Remove(name), "Name cannot be null");

    }
    [Test]
    public void Test_HeroRepositoriGetHeroWithHighestLevel()
    {
        heroes.Create(hero);
        heroes.Create(new Hero("TestName2",10));

        var heroFilter = heroes.GetHeroWithHighestLevel();

        Assert.AreEqual("TestName2", heroFilter.Name);
        Assert.AreEqual(10, heroFilter.Level);  
    }
    [Test]
    public void Test_HeroRepositoriGetHero()
    {
        heroes.Create(hero);
        heroes.Create(new Hero("TestName2", 10));

        var heroFilter = heroes.GetHero("TestName2");

        Assert.AreEqual("TestName2", heroFilter.Name);
        Assert.AreEqual(10, heroFilter.Level);
    }
    [Test]
    public void Test_HeroRepositoriIReadOnlyCollection()
    {
        Assert.NotNull(heroes);

        heroes.Create(hero);
        heroes.Create(new Hero("TestName2", 10));

        Assert.NotNull(heroes.Heroes);
        Assert.AreEqual(2,heroes.Heroes.Count);
    }

}