using StarfallArena.Entities;
using StarfallArena.Items;

namespace StarfallArena.Systems;

public class RenderSystem
{
    public void DrawFrame(
        string mapName,
        int mapWidth,
        int mapHeight,
        Player player,
        IReadOnlyCollection<Enemy> enemies,
        IReadOnlyCollection<Item> items,
        string message)
    {
        Console.Clear();
        Console.WriteLine($"Map: {mapName} ({mapWidth}x{mapHeight})");
        Console.WriteLine($"Player: {player.Name}, Health: {player.Health}, Score: {player.Score}");
        Console.WriteLine($"Enemies: {enemies.Count}, Items: {items.Count}");
        Console.WriteLine(message);
        Console.WriteLine();
        Console.WriteLine("Controls: Arrow keys to move, Esc to exit.");
        Console.WriteLine();

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                Console.Write(GetSymbolAt(x, y, mapWidth, mapHeight, player, enemies, items));
            }

            Console.WriteLine();
        }
    }

    private static char GetSymbolAt(
        int x,
        int y,
        int mapWidth,
        int mapHeight,
        Player player,
        IReadOnlyCollection<Enemy> enemies,
        IReadOnlyCollection<Item> items)
    {
        if (player.X == x && player.Y == y)
        {
            return player.Symbol;
        }

        Enemy? enemy = enemies.FirstOrDefault(current => current.X == x && current.Y == y);
        if (enemy is not null)
        {
            return enemy.Symbol;
        }

        Item? item = items.FirstOrDefault(current => current.X == x && current.Y == y);
        if (item is not null)
        {
            return item.Symbol;
        }

        if (y == 0 || y == mapHeight - 1 || x == 0 || x == mapWidth - 1)
        {
            return '#';
        }

        return '.';
    }
}
