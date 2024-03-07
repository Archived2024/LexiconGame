using System.Data;
using System.Reflection.PortableExecutable;
internal class Game
{
    private Map map = null;
    private Character character = null; 
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
        //DrawMap

        //GetCommand

        //Act

        //DrawMap

        //EnemyAction

        //DrawMap

        Console.ReadKey(); 

        } while (gameInProgress);
    }

    private void Initialize()
    {
        map = new Map(width: 10, height: 10);
        character = new Character(); 
    }
}