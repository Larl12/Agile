using StarfallArena.Entities;

namespace StarfallArena.Builders;

public class CharacterBuilder
{
    private string _name = "Hero";
    private int _health = 10;
    private int _x = 1;
    private int _y = 1;
    private int _armor;
    private string _characterClass = "Adventurer";
    private string _startingWeapon = "Training Sword";

    public CharacterBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CharacterBuilder SetHealth(int health)
    {
        _health = health;
        return this;
    }

    public CharacterBuilder SetArmor(int armor)
    {
        _armor = armor;
        return this;
    }

    public CharacterBuilder SetClass(string characterClass)
    {
        _characterClass = characterClass;
        return this;
    }

    public CharacterBuilder SetStartingWeapon(string startingWeapon)
    {
        _startingWeapon = startingWeapon;
        return this;
    }

    public CharacterBuilder SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
        return this;
    }

    public Player Build()
    {
        Player player = new(_name, _health, _x, _y);
        player.ConfigureLoadout(_armor, _characterClass, _startingWeapon);
        return player;
    }
}
