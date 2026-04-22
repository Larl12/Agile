using StarfallArena.Enemies;
using StarfallArena.Factories;

namespace StarfallArena;

public class GameManager
{
    private static GameManager? _instance;
    private readonly List<EnemyFactory> _enemyFactories;
    private Enemy _currentEnemy;
    private bool _isRunning;
    private int _frameCounter;
    private string _lastAction = "Press any key to interact. Press Esc to exit.";

    private GameManager()
    {
        MapWidth = 30;
        MapHeight = 12;
        Difficulty = Difficulty.Normal;
        _enemyFactories = new List<EnemyFactory>
        {
            new OrcFactory(),
            new GhostFactory()
        };
        _currentEnemy = _enemyFactories[0].CreateEnemy();
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
        _isRunning = true;
        _frameCounter = 0;
        Console.CursorVisible = false;

        try
        {
            while (_isRunning)
            {
                HandleInput();
                Update();
                Draw();
                Thread.Sleep(80);
            }
        }
        finally
        {
            Console.CursorVisible = true;
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Game Manager stopped the game loop.");
        }
    }

    private void HandleInput()
    {
        if (!Console.KeyAvailable)
        {
            return;
        }

        ConsoleKey key = Console.ReadKey(intercept: true).Key;

        if (key == ConsoleKey.Escape)
        {
            _lastAction = "Escape pressed. Exiting the game.";
            _isRunning = false;
            return;
        }

        if (key == ConsoleKey.D1)
        {
            _currentEnemy = _enemyFactories[0].CreateEnemy();
            _lastAction = _enemyFactories[0].SpawnEnemy();
            return;
        }

        if (key == ConsoleKey.D2)
        {
            _currentEnemy = _enemyFactories[1].CreateEnemy();
            _lastAction = _enemyFactories[1].SpawnEnemy();
            return;
        }

        _lastAction = $"Last input: {key}";
    }

    private void Update()
    {
        _frameCounter++;
    }

    private void Draw()
    {
        Console.Clear();
        Console.WriteLine($"Game Started with difficulty: {Difficulty}");
        Console.WriteLine($"Map size: {MapWidth} x {MapHeight}");
        Console.WriteLine($"Frame: {_frameCounter}");
        Console.WriteLine($"Current enemy: {_currentEnemy.Name}, Health: {_currentEnemy.Health}");
        Console.WriteLine(_lastAction);
        Console.WriteLine();
        Console.WriteLine("Controls: 1 = Orc factory, 2 = Ghost factory, Esc = exit.");
        Console.WriteLine();

        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                if (y == 0 || y == MapHeight - 1 || x == 0 || x == MapWidth - 1)
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();
        }
    }
}
