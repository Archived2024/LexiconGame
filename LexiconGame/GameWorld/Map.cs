using LexiconGame.Entities;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }
    public List<Creature> Creatures { get; } = new List<Creature>();

    public Map(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        cells = new Cell[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[y, x] = new Cell(); 
            }
        }
    }

    //Same as Cell?:[return: MaybeNull]    
    internal Cell? GetCell(int y, int x)
    {
       return (x  < 0 || x >= Width || y < 0 || y>=Height) ? null : cells[y, x];
    }
}