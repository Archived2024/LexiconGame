using LexiconGame.Entities;
using LexiconGame.Extensions;
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
            GetCommand();

            //Act

            //DrawMap

            //EnemyAction

            //DrawMap

            //Console.ReadKey(); 

        } while (gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch (keyPressed)
        {
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
            case ConsoleKey.P:
                PickUp();
                break;
            case ConsoleKey.I:
                Inventory();
                break;
        }
    }

    private void Inventory()
    {
        for (int i = 0; i < character.BackPack.Count; i++)
        {
            ConsoleUI.AddMessage($"{i + 1}: {character.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (character.BackPack.IsFull)
        {
            ConsoleUI.AddMessage("Backpack is full");
            return;
        }

        var items = character.Cell.Items;
        var item = character.Cell.Items.FirstOrDefault();
        if (item is null) return;

        if (character.BackPack.Add(item))
        {
            ConsoleUI.AddMessage($"Character pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        var newPosition = character.Cell.Position + movement;
        var newCell = map.GetCell(newPosition);
        if (newCell is not null) character.Cell = newCell;
    }

    private void DrawMap()
    {
        ConsoleUI.Clear();
        ConsoleUI.Draw(map);
        ConsoleUI.PrintStats($"Health: {character.Health}");
        ConsoleUI.PrintLog();
    }

    private void Initialize()
    {
        //ToDo: Maybe read from config?
        map = new Map(width: 10, height: 10);
        Cell? characterCell = map.GetCell(0, 0);
        character = new Character(characterCell!);
        map.Creatures.Add(character);

        map.GetCell(2, 4)?.Items.Add(Item.Coin());
        map.GetCell(5, 8)?.Items.Add(Item.Stone());
        map.GetCell(5, 8)?.Items.Add(Item.Coin());
    }
}
