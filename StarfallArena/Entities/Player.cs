namespace StarfallArena.Entities;

public class Player : Entity
{
    public Player(string name, int health, int x, int y)
        : base(name, health, x, y, '@')
    {
    }

    public int Score { get; private set; }

    public void AddScore(int points)
    {
        Score += points;
    }
}
