using StarfallArena.Enemies;

namespace StarfallArena.Factories;

public class GhostFactory : EnemyFactory
{
    public override Enemy CreateEnemy()
    {
        return new GhostEnemy();
    }
}
