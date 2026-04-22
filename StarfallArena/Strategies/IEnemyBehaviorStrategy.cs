using StarfallArena.Enemies;

namespace StarfallArena.Strategies;

public interface IEnemyBehaviorStrategy
{
    string Name { get; }

    string Execute(Enemy enemy);
}
