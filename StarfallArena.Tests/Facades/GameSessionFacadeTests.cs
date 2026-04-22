using StarfallArena.Facades;
using StarfallArena.Factories;

namespace StarfallArena.Tests.Facades;

public class GameSessionFacadeTests
{
    [Fact]
    public void StartSession_WithFactories_ShouldPreparePlayerWeaponAndEnemy()
    {
        // Arrange
        GameSessionFacade facade = new();
        List<EnemyFactory> factories = new()
        {
            new OrcFactory(),
            new GhostFactory()
        };

        // Act
        GameSessionContext session = facade.StartSession(30, 12, factories);

        // Assert
        Assert.Equal("Arin", session.Player.Name);
        Assert.Equal(26, session.Weapon.GetDamage());
        Assert.Equal("Orc", session.StartingEnemy.Name);
        Assert.Contains("Session ready", session.Summary);
    }
}
