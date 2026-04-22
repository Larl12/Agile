using StarfallArena.Enemies;

namespace StarfallArena.Factories;

public abstract class EnemyFactory
{
    public abstract Enemy CreateEnemy();

    public string SpawnEnemy()
    {
        Enemy enemy = CreateEnemy();
        return $"{enemy.Name} entered the arena. {enemy.Attack()}";
    }
}
