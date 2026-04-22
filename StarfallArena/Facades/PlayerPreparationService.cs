using StarfallArena.Builders;
using StarfallArena.Entities;
using StarfallArena.Weapons;

namespace StarfallArena.Facades;

public class PlayerPreparationService
{
    private const string DefaultPlayerName = "Arin";
    private const int DefaultPlayerHealth = 18;
    private const int DefaultPlayerX = 2;
    private const int DefaultPlayerY = 2;
    private const int DefaultPlayerArmor = 4;
    private const string DefaultPlayerClass = "Arena Knight";
    private const string DefaultWeaponName = "Steel Sword";
    private const int RustPenalty = 2;
    private const int FireBonus = 5;
    private const int CriticalMultiplier = 2;

    public Player CreatePlayer()
    {
        return new CharacterBuilder()
            .SetName(DefaultPlayerName)
            .SetHealth(DefaultPlayerHealth)
            .SetPosition(DefaultPlayerX, DefaultPlayerY)
            .SetArmor(DefaultPlayerArmor)
            .SetClass(DefaultPlayerClass)
            .SetStartingWeapon(DefaultWeaponName)
            .Build();
    }

    public IWeapon CreateWeapon()
    {
        return new CriticalStrikeDecorator(
            new FireDamageDecorator(
                new RustDecorator(new Sword(), RustPenalty),
                FireBonus),
            CriticalMultiplier);
    }
}
