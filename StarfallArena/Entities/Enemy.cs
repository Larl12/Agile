namespace StarfallArena.Entities;

public class Enemy : Entity
{
    public Enemy(string name, int health, int x, int y, string behavior)
        : base(name, health, x, y, 'E')
    {
        Behavior = behavior;
    }

    public string Behavior { get; }

    public void TakeStep(int playerX)
    {
        int direction = Math.Sign(playerX - X);
        if (direction != 0)
        {
            X += direction;
        }
    }
}
