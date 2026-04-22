using StarfallArena.Core;

namespace StarfallArena.Facades;

public class ArenaLoader
{
    public GameMap Load(int width, int height)
    {
        return new GameMap("Arena", width, height);
    }
}
