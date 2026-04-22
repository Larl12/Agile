using StarfallArena.Enemies;
using StarfallArena.Strategies;

namespace StarfallArena.Tests.Strategies;

public class EnemyBehaviorStrategyTests
{
    [Fact]
    public void Enemy_WithAggressiveStrategy_ShouldUseAttackMessage()
    {
        // Arrange
        Enemy enemy = new OrcEnemy();
        enemy.SetBehaviorStrategy(new AggressiveAttackStrategy());

        // Act
        string action = enemy.Act();

        // Assert
        Assert.Contains("charges forward", action);
        Assert.Contains("swings a heavy axe", action);
    }

    [Fact]
    public void Enemy_WhenStrategyChanges_ShouldUseNewBehaviorWithoutRecreation()
    {
        // Arrange
        Enemy enemy = new GhostEnemy();
        enemy.SetBehaviorStrategy(new RangedAttackStrategy());
        string firstAction = enemy.Act();

        // Act
        enemy.SetBehaviorStrategy(new FleeBehaviorStrategy());
        string secondAction = enemy.Act();

        // Assert
        Assert.Contains("attacks from distance", firstAction);
        Assert.Contains("retreats", secondAction);
        Assert.Equal("Flee", enemy.CurrentBehavior);
    }

    [Fact]
    public void Enemy_WithoutCustomStrategy_ShouldUsePassiveBehaviorByDefault()
    {
        // Arrange
        Enemy enemy = new OrcEnemy();

        // Act
        string action = enemy.Act();

        // Assert
        Assert.Equal("Passive", enemy.CurrentBehavior);
        Assert.Contains("waits", action);
    }
}
