namespace StarfallArena.Core;

public class HealthComponent
{
    public HealthComponent(int maxHealth)
    {
        if (maxHealth <= 0)
        {
            throw new ArgumentException("Max health must be greater than zero.", nameof(maxHealth));
        }

        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public int MaxHealth { get; }

    public int CurrentHealth { get; private set; }

    public void TakeDamage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Damage cannot be negative.", nameof(amount));
        }

        CurrentHealth = Math.Max(0, CurrentHealth - amount);
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Heal cannot be negative.", nameof(amount));
        }

        if (CurrentHealth == 0)
        {
            return;
        }

        CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
    }
}
