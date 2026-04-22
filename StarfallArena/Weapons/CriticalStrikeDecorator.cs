namespace StarfallArena.Weapons;

public class CriticalStrikeDecorator : WeaponDecorator
{
    private readonly int _multiplier;

    public CriticalStrikeDecorator(IWeapon weapon, int multiplier)
        : base(weapon)
    {
        _multiplier = multiplier;
    }

    public override int GetDamage()
    {
        return base.GetDamage() * _multiplier;
    }

    public override string GetDescription()
    {
        return $"Critical {base.GetDescription()}";
    }
}
