namespace StarfallArena.Enemies;

public class OrcEnemy : Enemy
{
    public OrcEnemy()
        : base("Orc", 12)
    {
    }

    public override string Attack()
    {
        return $"{Name} swings a heavy axe for 6 damage.";
    }
}
