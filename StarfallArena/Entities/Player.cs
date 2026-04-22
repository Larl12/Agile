namespace StarfallArena.Entities;

public class Player : Entity
{
    public Player(string name, int health, int x, int y)
        : base(name, health, x, y, '@')
    {
        CharacterClass = "Adventurer";
        StartingWeapon = "Training Sword";
    }

    public int Armor { get; private set; }

    public string CharacterClass { get; private set; }

    public string StartingWeapon { get; private set; }

    public int Score { get; private set; }

    public void ConfigureLoadout(int armor, string characterClass, string startingWeapon)
    {
        Armor = armor;
        CharacterClass = characterClass;
        StartingWeapon = startingWeapon;
    }

    public void AddScore(int points)
    {
        Score += points;
    }
}
