namespace StarfallArena.Builders;

public class CharacterBuilder
{
    private readonly Player _player = new();

    public CharacterBuilder SetName(string name)
    {
        _player.Name = name;
        return this;
    }

    public CharacterBuilder SetHealth(int health)
    {
        _player.Health = health;
        return this;
    }

    public CharacterBuilder SetArmor(int armor)
    {
        _player.Armor = armor;
        return this;
    }

    public CharacterBuilder SetClass(string characterClass)
    {
        _player.CharacterClass = characterClass;
        return this;
    }

    public CharacterBuilder SetStartingWeapon(string startingWeapon)
    {
        _player.StartingWeapon = startingWeapon;
        return this;
    }

    public Player Build()
    {
        return new Player
        {
            Name = _player.Name,
            Health = _player.Health,
            Armor = _player.Armor,
            CharacterClass = _player.CharacterClass,
            StartingWeapon = _player.StartingWeapon
        };
    }
}
