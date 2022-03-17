using System;
using System.Reflection;

using NUnit.Framework;

namespace Challenges.Challenge_4;

public class Tests {
    private BronzePickaxe Pick = new BronzePickaxe();
    private RingOfDueling Ring = new RingOfDueling();
    private GenieLamp     Lamp = new GenieLamp();

    [Test(Description = "Demonstrates that each item has the correct Value, HighAlch, and LowAlch variables.")]
    public void Challenge4_Variables() {
        Assert.Multiple(
            () => {
                // Value
                Assert.That(Pick.GetVariableValue("Value"), Is.EqualTo(1),    $"{Pick.GetType().Name} Value"); // 1, 0, 0
                Assert.That(Ring.GetVariableValue("Value"), Is.EqualTo(1275), $"{Ring.GetType().Name} Value"); // 1275, 765, 510
                Assert.That(Lamp.GetVariableValue("Value"), Is.EqualTo(200),  $"{Lamp.GetType().Name} Value"); // 200, 120, 80

                // High Alch
                Assert.That(Pick.GetVariableValue("HighAlch"), Is.EqualTo(0),   $"{Pick.GetType().Name} HighAlch");
                Assert.That(Ring.GetVariableValue("HighAlch"), Is.EqualTo(765), $"{Ring.GetType().Name} HighAlch");
                Assert.That(Lamp.GetVariableValue("HighAlch"), Is.EqualTo(120), $"{Lamp.GetType().Name} HighAlch");

                // Low Alch
                Assert.That(Pick.GetVariableValue("LowAlch"), Is.EqualTo(0),   $"{Pick.GetType().Name} LowAlch");
                Assert.That(Ring.GetVariableValue("LowAlch"), Is.EqualTo(510), $"{Ring.GetType().Name} LowAlch");
                Assert.That(Lamp.GetVariableValue("LowAlch"), Is.EqualTo(80),  $"{Lamp.GetType().Name} LowAlch");
            }
        );
    }

    private static Type[] ItemTypes = {
        typeof(RingOfDueling),
        typeof(BronzePickaxe),
        typeof(GenieLamp),
    };

    [Test]
    public void Challenge4_Turbo([ValueSource(nameof(ItemTypes))] Type itemType) {
        Assert.That(itemType.GetRuntimeFields,     Has.Count.EqualTo(1));
        Assert.That(itemType.GetRuntimeProperties, Has.Count.EqualTo(3).And.All.Property("CanWrite").False);

        foreach (var meth in itemType.GetRuntimeMethods()) {
            Assert.That(meth.DeclaringType != itemType || meth.IsSpecialName);
        }
    }
}