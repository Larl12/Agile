using StarfallArena.Entities;
using StarfallArena.UI;

namespace StarfallArena.Tests.UI;

public class ConsoleHudTests
{
    [Fact]
    public void ConsoleHud_WhenPlayerTakesDamage_ShouldUpdateHealthBar()
    {
        // Arrange
        Player player = new("Hero", 10, 1, 1);
        using ConsoleHud hud = new(player);

        // Act
        player.TakeDamage(4);

        // Assert
        Assert.Equal("[HP: ||||||....] 6/10", hud.LastHealthBar);
    }

    [Fact]
    public void ConsoleHud_WhenDisposed_ShouldStopReactingToHealthChanges()
    {
        // Arrange
        Player player = new("Hero", 10, 1, 1);
        ConsoleHud hud = new(player);
        string initialBar = hud.LastHealthBar;
        hud.Dispose();

        // Act
        player.TakeDamage(2);

        // Assert
        Assert.Equal(initialBar, hud.LastHealthBar);
    }
}
