
using System.Data;

internal class Game
{
    internal void Run()
    {
        Initialize();
    }

    private void Initialize()
    {
        var map = new Map(width: 10, height: 10);
    }
}