using StarfallArena.Enemies;

namespace StarfallArena.Strategies;

public class FleeBehaviorStrategy : IEnemyBehaviorStrategy
{
    public string Name => "Flee";

    public string Execute(Enemy enemy)
    {
        return $"{enemy.Name} retreats and looks for a safe escape route.";
    }
}
