namespace StarfallArena.Core;

public class GameMap
{
    public GameMap(string name, int width, int height)
    {
        Name = name;
        Width = width;
        Height = height;
    }

    public string Name { get; }

    public int Width { get; }

    public int Height { get; }
}
