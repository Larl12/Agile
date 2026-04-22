namespace StarfallArena.Entities;

public abstract class Entity
{
    protected Entity(string name, int health, int x, int y, char symbol)
    {
        Name = name;
        Health = health;
        X = x;
        Y = y;
        Symbol = symbol;
    }

    public string Name { get; protected set; }

    public int Health { get; protected set; }

    public int X { get; protected set; }

    public int Y { get; protected set; }

    public char Symbol { get; protected set; }

    public void Move(int dx, int dy, int mapWidth, int mapHeight)
    {
        X = Math.Clamp(X + dx, 1, mapWidth - 2);
        Y = Math.Clamp(Y + dy, 1, mapHeight - 2);
    }
}
