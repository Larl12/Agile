using StarfallArena.Enemies;

namespace StarfallArena.Strategies;

public class AggressiveAttackStrategy : IEnemyBehaviorStrategy
{
    public string Name => "Aggressive";

    public string Execute(Enemy enemy)
    {
        return $"{enemy.Name} charges forward. {enemy.Attack()}";
    }
}
