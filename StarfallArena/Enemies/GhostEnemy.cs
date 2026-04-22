namespace StarfallArena.Enemies;

public class GhostEnemy : Enemy
{
    public GhostEnemy()
        : base("Ghost", 8)
    {
    }

    public override string Attack()
    {
        return $"{Name} drains energy and ignores part of the armor.";
    }
}
