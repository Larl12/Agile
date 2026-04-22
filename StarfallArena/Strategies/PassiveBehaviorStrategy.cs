using StarfallArena.Enemies;

namespace StarfallArena.Strategies;

public class PassiveBehaviorStrategy : IEnemyBehaviorStrategy
{
    public string Name => "Passive";

    public string Execute(Enemy enemy)
    {
        return $"{enemy.Name} watches the arena and waits.";
    }
}
