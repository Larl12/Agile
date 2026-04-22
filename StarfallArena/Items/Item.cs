namespace StarfallArena.Items;

public class Item
{
    public Item(string name, string description, int x, int y, char symbol)
    {
        Name = name;
        Description = description;
        X = x;
        Y = y;
        Symbol = symbol;
    }

    public string Name { get; }

    public string Description { get; }

    public int X { get; }

    public int Y { get; }

    public char Symbol { get; }
}
