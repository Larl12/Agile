using StarfallArena.Enemies;

namespace StarfallArena.Factories;

public class OrcFactory : EnemyFactory
{
    public override Enemy CreateEnemy()
    {
        return new OrcEnemy();
    }
}
