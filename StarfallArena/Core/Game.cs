using StarfallArena.Entities;
using StarfallArena.Items;
using StarfallArena.Systems;

namespace StarfallArena.Core;

public class Game
{
    private readonly GameMap _map;
    private readonly Player _player;
    private readonly List<Enemy> _enemies;
    private readonly List<Item> _items;
    private readonly RenderSystem _renderSystem;
    private bool _isRunning = true;
    private string _lastInputMessage = "Press Esc to exit the game loop.";

    public Game()
    {
        _map = new GameMap("Arena", 30, 12);
        _player = new Player("Hero", 10, 2, 2);
        _enemies =
        [
            new Enemy("Goblin", 4, 10, 4, "Patrol"),
            new Enemy("Orc", 6, 18, 7, "Guard")
        ];
        _items =
        [
            new Item("Potion", "Restores health", 6, 3, '!'),
            new Item("Key", "Opens the gate", 22, 8, '?')
        ];
        _renderSystem = new RenderSystem();
    }

    public void Run()
    {
        Console.CursorVisible = false;

        try
        {
            while (_isRunning)
            {
                HandleInput();
                Update();
                Draw();
                Thread.Sleep(60);
            }
        }
        finally
        {
            Console.CursorVisible = true;
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Game loop stopped.");
        }
    }

    private void HandleInput()
    {
        if (!Console.KeyAvailable)
        {
            return;
        }

        ConsoleKey key = Console.ReadKey(intercept: true).Key;

        switch (key)
        {
            case ConsoleKey.Escape:
                _lastInputMessage = "Escape pressed. Closing the game.";
                _isRunning = false;
                break;
            case ConsoleKey.LeftArrow:
                _player.Move(-1, 0, _map.Width, _map.Height);
                _lastInputMessage = "Player moved left.";
                break;
            case ConsoleKey.RightArrow:
                _player.Move(1, 0, _map.Width, _map.Height);
                _lastInputMessage = "Player moved right.";
                break;
            case ConsoleKey.UpArrow:
                _player.Move(0, -1, _map.Width, _map.Height);
                _lastInputMessage = "Player moved up.";
                break;
            case ConsoleKey.DownArrow:
                _player.Move(0, 1, _map.Width, _map.Height);
                _lastInputMessage = "Player moved down.";
                break;
            default:
                _lastInputMessage = $"Pressed key: {key}";
                break;
        }
    }

    private void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.TakeStep(_player.X);
        }
    }

    private void Draw()
    {
        _renderSystem.DrawFrame(
            _map.Name,
            _map.Width,
            _map.Height,
            _player,
            _enemies,
            _items,
            _lastInputMessage);
    }
}
