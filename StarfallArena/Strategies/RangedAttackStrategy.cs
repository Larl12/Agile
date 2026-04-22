using StarfallArena.Enemies;

namespace StarfallArena.Strategies;

public class RangedAttackStrategy : IEnemyBehaviorStrategy
{
    public string Name => "Ranged";

    public string Execute(Enemy enemy)
    {
        return $"{enemy.Name} attacks from distance and keeps space from the player.";
    }
}
