using StarfallArena.Enemies;
using StarfallArena.Entities;
using StarfallArena.Weapons;

namespace StarfallArena.Facades;

public class GameSessionContext
{
    public required Player Player { get; init; }

    public required IWeapon Weapon { get; init; }

    public required Enemy StartingEnemy { get; init; }

    public required string Summary { get; init; }
}
