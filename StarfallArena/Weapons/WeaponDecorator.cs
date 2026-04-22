namespace StarfallArena.Weapons;

public abstract class WeaponDecorator : IWeapon
{
    protected WeaponDecorator(IWeapon weapon)
    {
        Weapon = weapon;
    }

    protected IWeapon Weapon { get; }

    public virtual int GetDamage()
    {
        return Weapon.GetDamage();
    }

    public virtual string GetDescription()
    {
        return Weapon.GetDescription();
    }
}
