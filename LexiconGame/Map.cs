﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }

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

    //ToDo: Do better
    //Same as Cell?:[return: MaybeNull]    
    internal Cell? GetCell(int y, int x)
    {
        try
        {
        return cells[y, x];

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null; 
        }
    }
}