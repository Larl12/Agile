namespace StarfallArena.Weapons;

public class RustDecorator : WeaponDecorator
{
    private readonly int _damagePenalty;

    public RustDecorator(IWeapon weapon, int damagePenalty)
        : base(weapon)
    {
        _damagePenalty = damagePenalty;
    }

    public override int GetDamage()
    {
        return Math.Max(0, base.GetDamage() - _damagePenalty);
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()} + Rust";
    }
}
