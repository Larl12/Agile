using StarfallArena.Strategies;

namespace StarfallArena.Enemies;

public abstract class Enemy
{
    protected Enemy(string name, int health)
    {
        Name = name;
        Health = health;
        _behaviorStrategy = new PassiveBehaviorStrategy();
    }

    private IEnemyBehaviorStrategy _behaviorStrategy;

    public string Name { get; }

    public int Health { get; }

    public string CurrentBehavior => _behaviorStrategy.Name;

    public abstract string Attack();

    public void SetBehaviorStrategy(IEnemyBehaviorStrategy strategy)
    {
        _behaviorStrategy = strategy;
    }

    public string Act()
    {
        return _behaviorStrategy.Execute(this);
    }
}
