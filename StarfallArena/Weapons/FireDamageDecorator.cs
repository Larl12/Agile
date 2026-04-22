namespace StarfallArena.Weapons;

public class FireDamageDecorator : WeaponDecorator
{
    private readonly int _bonusDamage;

    public FireDamageDecorator(IWeapon weapon, int bonusDamage)
        : base(weapon)
    {
        _bonusDamage = bonusDamage;
    }

    public override int GetDamage()
    {
        return base.GetDamage() + _bonusDamage;
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()} + Fire";
    }
}
