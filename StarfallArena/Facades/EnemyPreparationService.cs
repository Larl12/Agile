using StarfallArena.Enemies;
using StarfallArena.Factories;

namespace StarfallArena.Facades;

public class EnemyPreparationService
{
    public Enemy CreateStartingEnemy(IReadOnlyList<EnemyFactory> enemyFactories)
    {
        return enemyFactories[0].CreateEnemy();
    }
}
