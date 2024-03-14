
using LexiconGame.Entities;
using LexiconGame.Extensions;

internal class ConsoleUI
{
    internal static void Clear()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
    }

    internal static void Draw(IMap map)
    {
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell);

                IDrawable drawable = map.Creatures.CreatureAtExtension(cell) 
                                             ?? cell.Items.FirstOrDefault() as IDrawable 
                                             ?? cell;

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);

            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
   
}