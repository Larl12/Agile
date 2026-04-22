using StarfallArena.Core;

namespace StarfallArena.Tests.Core;

public class HealthComponentTests
{
    [Fact]
    public void TakeDamage_WithPositiveAmount_ShouldReduceHealth()
    {
        // Arrange
        HealthComponent health = new(100);

        // Act
        health.TakeDamage(10);

        // Assert
        Assert.Equal(90, health.CurrentHealth);
    }

    [Fact]
    public void TakeDamage_MoreThanCurrentHealth_ShouldNotGoBelowZero()
    {
        // Arrange
        HealthComponent health = new(50);

        // Act
        health.TakeDamage(80);

        // Assert
        Assert.Equal(0, health.CurrentHealth);
    }

    [Fact]
    public void TakeDamage_WithNegativeAmount_ShouldThrowArgumentException()
    {
        // Arrange
        HealthComponent health = new(100);

        // Act
        Action action = () => health.TakeDamage(-5);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Heal_AfterTakingDamage_ShouldRestoreHealthWithoutExceedingMaximum()
    {
        // Arrange
        HealthComponent health = new(100);
        health.TakeDamage(35);

        // Act
        health.Heal(20);

        // Assert
        Assert.Equal(85, health.CurrentHealth);
    }

    [Fact]
    public void Heal_WhenCharacterIsDead_ShouldNotResurrect()
    {
        // Arrange
        HealthComponent health = new(40);
        health.TakeDamage(40);

        // Act
        health.Heal(10);

        // Assert
        Assert.Equal(0, health.CurrentHealth);
    }

    [Fact]
    public void Heal_WithNegativeAmount_ShouldThrowArgumentException()
    {
        // Arrange
        HealthComponent health = new(100);

        // Act
        Action action = () => health.Heal(-3);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}
