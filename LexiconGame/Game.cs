using LexiconGame.Entities;
using System.Data;
using System.Reflection.PortableExecutable;
internal class Game
{
    private Map map = null!;
    private Character character = null!; 
    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;
        do
        {
            DrawMap();

        //GetCommand

        //Act

        //DrawMap

        //EnemyAction

        //DrawMap

        Console.ReadKey(); 

        } while (gameInProgress);
    }

    private void DrawMap()
    {
        Console.Clear();

        for (int y= 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell);

                IDrawable drawable = cell;

                foreach (var creature in map.Creatures)
                {
                    if(creature.Cell == drawable)
                    {
                        drawable = creature;
                        break;
                    }
                }

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);

            }
            Console.WriteLine();
        }
        Console.ResetColor(); 
    }

    private void Initialize()
    {
        //ToDo: Maybe read from config?
        map = new Map(width: 10, height: 10);
        Cell? characterCell = map.GetCell(0, 0);
        character = new Character(characterCell!);
        map.Creatures.Add(character);
    }
}