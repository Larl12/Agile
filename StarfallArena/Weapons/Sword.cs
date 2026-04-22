namespace StarfallArena.Weapons;

public class Sword : IWeapon
{
    public int GetDamage()
    {
        return 10;
    }

    public string GetDescription()
    {
        return "Simple sword";
    }
}
