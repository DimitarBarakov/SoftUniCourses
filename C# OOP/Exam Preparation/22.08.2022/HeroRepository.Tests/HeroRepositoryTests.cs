using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateShouldThrowExceptionIfHeroIsNull()
    {
        Hero hero = null;
        Assert.Throws<ArgumentNullException>(() =>
        {
            HeroRepository heroRepository = new HeroRepository();
            heroRepository.Create(hero);
        },"Hero is null");
    }
    [Test]
    public void CreateShouldThrowExceptionIfHeroExist()
    {
        Hero hero1 = new Hero("Mite", 4);
        Assert.Throws<InvalidOperationException>(() =>
        {
            HeroRepository heroRepository = new HeroRepository();
            heroRepository.Create(hero1);
            heroRepository.Create(hero1);
        }, "Hero with name Mite already exists");
    }
    [Test]
    public void CreateShouldWork()
    {
        Hero hero1 = new Hero("Mite", 4);
        HeroRepository heroRepository = new HeroRepository();
        string res = heroRepository.Create(hero1);

        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(1));
        Assert.That(res, Is.EqualTo("Successfully added hero Mite with level 4"));
    }

    [Test]
    public void RemoveShouldThrowExeption()
    {
        Hero hero = new Hero("", 2);
        Assert.Throws<ArgumentNullException>(() =>
        {
            HeroRepository heroRepository = new HeroRepository();
            heroRepository.Remove("");
        }, "Name cannot be null");
    }

    [Test]
    public void RemoveShouldWork()
    {
        Hero hero1 = new Hero("Mite", 4);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        bool res = heroRepository.Remove("Mite");
        Assert.That(res, Is.True);
    }

    [Test]
    public void GetHeroWithHighestLevel()
    {
        Hero hero1 = new Hero("Mite", 4);
        Hero hero2 = new Hero("Mitko", 2);
        Hero hero3 = new Hero("Miteto", 1);
        Hero hero4 = new Hero("Mitaka", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        heroRepository.Create(hero4);
        heroRepository.Create(hero3);
        heroRepository.Create(hero2);

        Hero hero = heroRepository.GetHeroWithHighestLevel();

        Assert.That(hero, Is.EqualTo(hero1));
    }
    [Test]
    public void GetHero()
    {
        Hero hero1 = new Hero("Mite", 4);
        Hero hero2 = new Hero("Mitko", 2);
        Hero hero3 = new Hero("Miteto", 1);
        Hero hero4 = new Hero("Mitaka", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        heroRepository.Create(hero4);
        heroRepository.Create(hero3);
        heroRepository.Create(hero2);

        Hero hero = heroRepository.GetHero("Mite");

        Assert.That(hero, Is.EqualTo(hero1));
    }
}