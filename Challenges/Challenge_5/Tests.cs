using System;

using NUnit.Framework;

namespace Challenges.Challenge_5;

public class Tests {
    private static BronzePickaxe Pick  = new BronzePickaxe();
    private static RingOfDueling Ring  = new RingOfDueling();
    private static GenieLamp     Lamp  = new GenieLamp();
    private static object[]      Items = { Pick, Ring, Lamp };

    [Test(Description = "Shows that a " + nameof(BronzePickaxe) + "is worth less than a " + nameof(RingOfDueling))]
    public void Challenge5_Comparison() {
        Assert.That(Pick, Is.LessThan(Ring));
    }

    [Test(Description = "Shows that Rings of Dueling can be instantiated with a Value parameter, and that that Value parameter is used to compare them to each other")]
    public void Challenge5_Turbo() {
        Assert.That(Challenge5_Comparison, Throws.Nothing);

        var full  = Activator.CreateInstance(typeof(RingOfDueling), 8);
        var empty = Activator.CreateInstance(typeof(RingOfDueling), 0);
        Assert.That(full, Is.GreaterThan(empty));
    }

    [Test(Description = "🏋️‍")]
    public void Challenge5_Turbo_ChampionshipEdition() {
        Assert.That(Challenge5_Turbo, Throws.Nothing);

        var pick  = new BronzePickaxe();
        var full  = Activator.CreateInstance(typeof(RingOfDueling), 8);
        var empty = Activator.CreateInstance(typeof(RingOfDueling), 0);

        Assert.That(pick, Is.LessThan(full));
        Assert.That(pick, Is.LessThan(empty));
        Assert.That(full, Is.GreaterThan(empty));
    }
}