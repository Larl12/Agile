using StarfallArena.Enemies;
using StarfallArena.Entities;
using StarfallArena.Facades;
using StarfallArena.Factories;
using StarfallArena.Strategies;
using StarfallArena.Weapons;

namespace StarfallArena;

public class GameManager
{
    private const int FrameDelayMilliseconds = 80;
    private const ConsoleKey FirstEnemyKey = ConsoleKey.D1;
    private const ConsoleKey SecondEnemyKey = ConsoleKey.D2;
    private const ConsoleKey AggressiveStrategyKey = ConsoleKey.D3;
    private const ConsoleKey RangedStrategyKey = ConsoleKey.D4;
    private const ConsoleKey FleeStrategyKey = ConsoleKey.D5;
    private const ConsoleKey ExecuteStrategyKey = ConsoleKey.Enter;
    private const ConsoleKey ExitKey = ConsoleKey.Escape;
    private const char WallSymbol = '#';
    private const char FloorSymbol = '.';

    private static GameManager? _instance;
    private readonly List<EnemyFactory> _enemyFactories;
    private readonly GameSessionFacade _sessionFacade;
    private readonly Player _player;
    private readonly IWeapon _playerWeapon;
    private Enemy _currentEnemy;
    private bool _isRunning;
    private bool _enemyShouldAct;
    private int _frameCounter;
    private string _lastAction = "Press any key to interact. Press Esc to exit.";

    private GameManager()
    {
        MapWidth = 30;
        MapHeight = 12;
        Difficulty = Difficulty.Normal;
        _sessionFacade = new GameSessionFacade();
        _enemyFactories = CreateEnemyFactories();
        (_player, _playerWeapon, _currentEnemy, _lastAction) = CreateInitialSession();
    }

    public static GameManager Instance
    {
        get
        {
            _instance ??= new GameManager();
            return _instance;
        }
    }

    public int MapWidth { get; }

    public int MapHeight { get; }

    public Difficulty Difficulty { get; }

    public void Run()
    {
        PrepareGameLoop();

        try
        {
            while (_isRunning)
            {
                HandleInput();
                Update();
                Draw();
                Thread.Sleep(FrameDelayMilliseconds);
            }
        }
        finally
        {
            CleanupConsole();
        }
    }

    private static List<EnemyFactory> CreateEnemyFactories()
    {
        return
        [
            new OrcFactory(),
            new GhostFactory()
        ];
    }

    private (Player player, IWeapon weapon, Enemy enemy, string summary) CreateInitialSession()
    {
        GameSessionContext session = _sessionFacade.StartSession(MapWidth, MapHeight, _enemyFactories);
        return (session.Player, session.Weapon, session.StartingEnemy, session.Summary);
    }

    private void PrepareGameLoop()
    {
        _isRunning = true;
        _frameCounter = 0;
        Console.CursorVisible = false;
    }

    private static void CleanupConsole()
    {
        Console.CursorVisible = true;
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("Game Manager stopped the game loop.");
    }

    private void HandleInput()
    {
        if (!Console.KeyAvailable)
        {
            return;
        }

        ConsoleKey key = Console.ReadKey(intercept: true).Key;

        if (key == ExitKey)
        {
            StopGameLoop();
            return;
        }

        if (key == FirstEnemyKey)
        {
            SpawnEnemyFromFactory(0);
            return;
        }

        if (key == SecondEnemyKey)
        {
            SpawnEnemyFromFactory(1);
            return;
        }

        if (key == AggressiveStrategyKey)
        {
            ChangeEnemyStrategy(new AggressiveAttackStrategy());
            return;
        }

        if (key == RangedStrategyKey)
        {
            ChangeEnemyStrategy(new RangedAttackStrategy());
            return;
        }

        if (key == FleeStrategyKey)
        {
            ChangeEnemyStrategy(new FleeBehaviorStrategy());
            return;
        }

        if (key == ExecuteStrategyKey)
        {
            _enemyShouldAct = true;
            _lastAction = $"{_currentEnemy.Name} prepares to use {_currentEnemy.CurrentBehavior} behavior.";
            return;
        }

        _lastAction = $"Last input: {key}";
    }

    private void StopGameLoop()
    {
        _lastAction = "Escape pressed. Exiting the game.";
        _isRunning = false;
    }

    private void SpawnEnemyFromFactory(int index)
    {
        _currentEnemy = _enemyFactories[index].CreateEnemy();
        _lastAction = _enemyFactories[index].SpawnEnemy();
    }

    private void ChangeEnemyStrategy(IEnemyBehaviorStrategy strategy)
    {
        _currentEnemy.SetBehaviorStrategy(strategy);
        _lastAction = $"{_currentEnemy.Name} switched to {_currentEnemy.CurrentBehavior} behavior.";
    }

    private void Update()
    {
        _frameCounter++;

        if (_enemyShouldAct)
        {
            _lastAction = _currentEnemy.Act();
            _enemyShouldAct = false;
        }
    }

    private void Draw()
    {
        Console.Clear();
        DrawHud();
        DrawArena();
    }

    private void DrawHud()
    {
        Console.WriteLine($"Game Started with difficulty: {Difficulty}");
        Console.WriteLine($"Map size: {MapWidth} x {MapHeight}");
        Console.WriteLine($"Frame: {_frameCounter}");
        Console.WriteLine(
            $"Player: {_player.Name}, Class: {_player.CharacterClass}, Health: {_player.Health}, Armor: {_player.Armor}");
        Console.WriteLine($"Starting weapon: {_player.StartingWeapon}");
        Console.WriteLine($"Weapon modifiers: {_playerWeapon.GetDescription()}");
        Console.WriteLine($"Weapon damage: {_playerWeapon.GetDamage()}");
        Console.WriteLine($"Current enemy: {_currentEnemy.Name}, Health: {_currentEnemy.Health}");
        Console.WriteLine($"Enemy behavior: {_currentEnemy.CurrentBehavior}");
        Console.WriteLine(_lastAction);
        Console.WriteLine();
        Console.WriteLine("Controls: 1 = Orc, 2 = Ghost, 3 = Aggressive, 4 = Ranged, 5 = Flee, Enter = Act, Esc = exit.");
        Console.WriteLine();
    }

    private void DrawArena()
    {
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                Console.Write(IsBorder(x, y) ? WallSymbol : FloorSymbol);
            }

            Console.WriteLine();
        }
    }

    private bool IsBorder(int x, int y)
    {
        return y == 0 || y == MapHeight - 1 || x == 0 || x == MapWidth - 1;
    }
}
