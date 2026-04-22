using StarfallArena.Builders;
using StarfallArena.Entities;
using StarfallArena.Weapons;

namespace StarfallArena.Facades;

public class PlayerPreparationService
{
    public Player CreatePlayer()
    {
        return new CharacterBuilder()
            .SetName("Arin")
            .SetHealth(18)
            .SetPosition(2, 2)
            .SetArmor(4)
            .SetClass("Arena Knight")
            .SetStartingWeapon("Steel Sword")
            .Build();
    }

    public IWeapon CreateWeapon()
    {
        return new CriticalStrikeDecorator(
            new FireDamageDecorator(
                new RustDecorator(new Sword(), 2),
                5),
            2);
    }
}
