namespace StarfallArena.Entities;

public class Player : Entity
{
    public event Action<int, int>? OnHealthChanged;

    public Player(string name, int health, int x, int y)
        : base(name, health, x, y, '@')
    {
        MaxHealth = health;
        CharacterClass = "Adventurer";
        StartingWeapon = "Training Sword";
    }

    public int MaxHealth { get; }

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

    public void TakeDamage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Damage cannot be negative.", nameof(amount));
        }

        int newHealth = Math.Max(0, Health - amount);
        SetHealth(newHealth);
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Heal cannot be negative.", nameof(amount));
        }

        int newHealth = Math.Min(MaxHealth, Health + amount);
        SetHealth(newHealth);
    }

    private void SetHealth(int newHealth)
    {
        if (newHealth == Health)
        {
            return;
        }

        Health = newHealth;
        OnHealthChanged?.Invoke(Health, MaxHealth);
    }
}
