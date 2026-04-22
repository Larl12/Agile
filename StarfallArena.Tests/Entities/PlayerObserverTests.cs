using StarfallArena.Entities;

namespace StarfallArena.Tests.Entities;

public class PlayerObserverTests
{
    [Fact]
    public void TakeDamage_WhenHealthChanges_ShouldRaiseOnHealthChangedEvent()
    {
        // Arrange
        Player player = new("Hero", 10, 1, 1);
        int receivedHealth = -1;
        int receivedMaxHealth = -1;
        player.OnHealthChanged += (currentHealth, maxHealth) =>
        {
            receivedHealth = currentHealth;
            receivedMaxHealth = maxHealth;
        };

        // Act
        player.TakeDamage(3);

        // Assert
        Assert.Equal(7, receivedHealth);
        Assert.Equal(10, receivedMaxHealth);
    }

    [Fact]
    public void Heal_WhenHealthDoesNotChange_ShouldNotRaiseOnHealthChangedEvent()
    {
        // Arrange
        Player player = new("Hero", 10, 1, 1);
        int callCount = 0;
        player.OnHealthChanged += (_, _) => callCount++;

        // Act
        player.Heal(0);

        // Assert
        Assert.Equal(0, callCount);
    }
}
