using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.hero = new Hero("Name", 5);
        this.heroRepository = new HeroRepository();
    }
    [Test]
    public void Test_HeroConstructor()
    {
        string name = "HeroName";
        int level = 5;

        hero = new Hero(name, level);

        Assert.NotNull(hero);

        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);

    }
    [Test]
    public void Test_HeroRepositorycONSTRUCTOR()
    {
        Assert.NotNull(heroRepository);
        Assert.NotNull(heroRepository.Heroes);
    }
    [Test]
    public void Test_HeroRepositoryCreate()
    {
        string name = "HeroName";
        int level = 5;

        hero = new Hero(name, level);

        this.heroRepository.Create(hero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero), $"Hero with name {name} already exists");

        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null), "Hero is null");
    }
    [Test]
    public void Test_HeroRepositoryRemove()
    {
        string name = "HeroName";
        int level = 5;

        hero = new Hero(name, level);

        this.heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(null), "Name cannot be null");

        Assert.False(this.heroRepository.Remove("Vanko"));

        Assert.True(this.heroRepository.Remove(name));
    }
    [Test]
    public void Test_HeroRepositoryGetHeroWithHighestLevel()
    {
        string name = "HeroName";
        int level = 50;

        hero = new Hero(name, level);



        this.heroRepository.Create(hero);
        this.heroRepository.Create(new Hero("Vanko", 43));

        var heroWithHighestLevel = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(name, heroWithHighestLevel.Name);   
        Assert.AreEqual(level, heroWithHighestLevel.Level);

    }
    [Test]
    public void Test_HeroRepositoryGetHero()
    {
        string name = "HeroName";
        int level = 50;

        hero = new Hero(name, level);



        this.heroRepository.Create(hero);
        this.heroRepository.Create(new Hero("Vanko", 43));

        Assert.AreEqual(2, this.heroRepository.Heroes.Count);

        var getHero = this.heroRepository.GetHero(name);

        Assert.AreEqual(name, getHero.Name);
        Assert.AreEqual(level,getHero.Level);
    }



}