using StarfallArena.Core;
using StarfallArena.Enemies;
using StarfallArena.Factories;

namespace StarfallArena.Facades;

public class GameSessionFacade
{
    private readonly ArenaLoader _arenaLoader;
    private readonly PlayerPreparationService _playerPreparationService;
    private readonly EnemyPreparationService _enemyPreparationService;

    public GameSessionFacade()
        : this(new ArenaLoader(), new PlayerPreparationService(), new EnemyPreparationService())
    {
    }

    public GameSessionFacade(
        ArenaLoader arenaLoader,
        PlayerPreparationService playerPreparationService,
        EnemyPreparationService enemyPreparationService)
    {
        _arenaLoader = arenaLoader;
        _playerPreparationService = playerPreparationService;
        _enemyPreparationService = enemyPreparationService;
    }

    public GameSessionContext StartSession(
        int mapWidth,
        int mapHeight,
        IReadOnlyList<EnemyFactory> enemyFactories)
    {
        GameMap map = _arenaLoader.Load(mapWidth, mapHeight);
        var player = _playerPreparationService.CreatePlayer();
        var weapon = _playerPreparationService.CreateWeapon();
        Enemy enemy = _enemyPreparationService.CreateStartingEnemy(enemyFactories);

        return new GameSessionContext
        {
            Player = player,
            Weapon = weapon,
            StartingEnemy = enemy,
            Summary = $"Session ready: {map.Name} {map.Width}x{map.Height}, player {player.Name}, enemy {enemy.Name}."
        };
    }
}
