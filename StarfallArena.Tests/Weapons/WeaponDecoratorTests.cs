using StarfallArena.Weapons;

namespace StarfallArena.Tests.Weapons;

public class WeaponDecoratorTests
{
    [Fact]
    public void DecoratorChain_FireRustAndCritical_ShouldCalculateExpectedDamage()
    {
        // Arrange
        IWeapon weapon = new CriticalStrikeDecorator(
            new FireDamageDecorator(
                new RustDecorator(new Sword(), 2),
                5),
            2);

        // Act
        int damage = weapon.GetDamage();
        string description = weapon.GetDescription();

        // Assert
        Assert.Equal(26, damage);
        Assert.Equal("Critical Simple sword + Rust + Fire", description);
    }
}
