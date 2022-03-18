using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

namespace Challenges.Challenge_4;

public class Tests {
    [Test(Description = "Demonstrates that each item has the correct Value, HighAlch, and LowAlch variables.")]
    [TestCase(typeof(BronzePickaxe),          typeof(RingOfDueling),          typeof(GenieLamp))]
    [TestCase(typeof(SPOILERS.BronzePickaxe), typeof(SPOILERS.RingOfDueling), typeof(SPOILERS.GenieLamp))]
    public void Challenge4_Variables(Type pickType, Type ringType, Type lampType) {
        // 📎 The `!` says, "Don't worry about this variable maybe being null, I know it won't be."
        // See: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
        //
        // It seems weird that `Activator.CreateInstance`, which calls the default constructor, would return `null`,
        // but apparently it can when you try to activate a `Nullable<>` type like `Nullable<int>`
        // (usually written as `int?`)
        var pick = Activator.CreateInstance(pickType)!;
        var ring = Activator.CreateInstance(ringType)!;
        var lamp = Activator.CreateInstance(lampType)!;
        Assert.Multiple(
            () => {
                // Value
                Assert.That(pick.GetVariableValue("Value"), Is.EqualTo(1),    $"{pick.GetType().Name} Value"); // 1, 0, 0
                Assert.That(ring.GetVariableValue("Value"), Is.EqualTo(1275), $"{ring.GetType().Name} Value"); // 1275, 765, 510
                Assert.That(lamp.GetVariableValue("Value"), Is.EqualTo(200),  $"{lamp.GetType().Name} Value"); // 200, 120, 80

                // High Alch
                Assert.That(pick.GetVariableValue("HighAlch"), Is.EqualTo(0),   $"{pick.GetType().Name} HighAlch");
                Assert.That(ring.GetVariableValue("HighAlch"), Is.EqualTo(765), $"{ring.GetType().Name} HighAlch");
                Assert.That(lamp.GetVariableValue("HighAlch"), Is.EqualTo(120), $"{lamp.GetType().Name} HighAlch");

                // Low Alch
                Assert.That(pick.GetVariableValue("LowAlch"), Is.EqualTo(0),   $"{pick.GetType().Name} LowAlch");
                Assert.That(ring.GetVariableValue("LowAlch"), Is.EqualTo(510), $"{ring.GetType().Name} LowAlch");
                Assert.That(lamp.GetVariableValue("LowAlch"), Is.EqualTo(80),  $"{lamp.GetType().Name} LowAlch");
            }
        );
    }

    private static Type[] ItemTypes = {
        typeof(RingOfDueling),
        typeof(BronzePickaxe),
        typeof(GenieLamp),
        typeof(SPOILERS.RingOfDueling),
        typeof(SPOILERS.BronzePickaxe),
        typeof(SPOILERS.GenieLamp),
    };

    [Test(Description = "Demonstrates that each type has 3 read-only Properties and 0 Fields.")]
    public void Challenge4_Turbo([ValueSource(nameof(ItemTypes))] Type itemType) {
        Assert.Multiple(
            () => {
                Assert.That(
                    itemType.GetRuntimeFields,
                    Is.Empty,
                    $"{itemType} cannot have any fields!"
                );
                Assert.That(
                    itemType.GetRuntimeProperties,
                    Has.Length.EqualTo(3).And.All.Property("CanWrite").False,
                    $"{itemType} must have exactly 3 read-only properties!"
                );

                var declaredMethods = itemType.GetRuntimeMethods()
                                              .Where(it => it.DeclaringType == itemType)
                                              .Where(it => it.IsSpecialName == false);

                Assert.That(declaredMethods, Is.Empty, $"{itemType} cannot declare any methods!");
            }
        );
    }
}