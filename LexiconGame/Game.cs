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
                //ToDo: Handle null
                Cell? cell = map.GetCell(y, x);
                Console.ForegroundColor = cell.Color;
                Console.Write(cell.Symbol);

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
    }
}