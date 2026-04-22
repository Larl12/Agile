using StarfallArena.Entities;

namespace StarfallArena.UI;

public class ConsoleHud : IDisposable
{
    private readonly Player _player;

    public ConsoleHud(Player player)
    {
        _player = player;
        LastHealthBar = FormatHealthBar(player.Health, player.MaxHealth);
        _player.OnHealthChanged += HandleHealthChanged;
    }

    public string LastHealthBar { get; private set; }

    public void Dispose()
    {
        _player.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        LastHealthBar = FormatHealthBar(currentHealth, maxHealth);
    }

    private static string FormatHealthBar(int currentHealth, int maxHealth)
    {
        const int barWidth = 10;
        int filledSegments = (int)Math.Round((double)currentHealth / maxHealth * barWidth, MidpointRounding.AwayFromZero);
        filledSegments = Math.Clamp(filledSegments, 0, barWidth);
        string filled = new('|', filledSegments);
        string empty = new('.', barWidth - filledSegments);
        return $"[HP: {filled}{empty}] {currentHealth}/{maxHealth}";
    }
}
