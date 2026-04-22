namespace StarfallArena.Enemies;

public abstract class Enemy
{
    protected Enemy(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public string Name { get; }

    public int Health { get; }

    public abstract string Attack();
}
