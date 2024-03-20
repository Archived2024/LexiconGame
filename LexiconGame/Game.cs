using LexiconGame.Entities;
using LexiconGame.Extensions;
using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
internal class Game
{
    private Dictionary<ConsoleKey, Action> actionMeny = null!;
    private IMap map;
    private Character character = null!;
    private IUI ui;
    private bool gameInProgress;

    public Game(IUI ui, IMap map)
    {
        this.ui = ui;
        this.map = map;
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;
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
        var keyPressed = ui.GetKey();

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
            //case ConsoleKey.P:
            //    PickUp();
            //    break;
            //case ConsoleKey.I:
            //    Inventory();
            //    break;
        }

        

        if(actionMeny.ContainsKey(keyPressed))
        {
            actionMeny[keyPressed]?.Invoke();
        }
    }

    private void Inventory()
    {
        for (int i = 0; i < character.BackPack.Count; i++)
        {
            ui.AddMessage($"{i + 1}: {character.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (character.BackPack.IsFull)
        {
            ui.AddMessage("Backpack is full");
            return;
        }

        var items = character.Cell.Items;
        var item = character.Cell.Items.FirstOrDefault();
        if (item is null) return;

        if (character.BackPack.Add(item))
        {
            ui.AddMessage($"Character pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        var newPosition = character.Cell.Position + movement;
        var newCell = map.GetCell(newPosition);

        Creature? opponent = map.CreatureAt(newCell!);
        if(opponent is not null)
        {
            character.Attack(opponent);
            opponent.Attack(character);
        }

        gameInProgress = !character.IsDead;

        if (newCell is not null)
        {
            character.Cell = newCell;
            if (newCell.Items.Any())
                ui.AddMessage($"You see {string.Join(", ", newCell.Items)}");
        }
    }

    private void DrawMap()
    {
        ui.Clear();
        ui.Draw();
        ui.PrintStats($"Health: {character.Health}, Enemys: {map.Creatures.Where(c => !c.IsDead ).Count() - 1} ");
        ui.PrintLog();
    }

    private void Initialize()
    {
        CreateActionMeny();

        
        Cell? characterCell = map.GetCell(0, 0);
        character = new Character(characterCell!);
        map.Creatures.Add(character);
        var r = new Random();

        

        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Stone());

        map.Place(new Orc(RCell()));
        map.Place(new Orc(RCell()));
        map.Place(new Troll(RCell()));
        map.Place(new Troll(RCell()));
        map.Place(new Goblin(RCell()));
        map.Place(new Goblin(RCell()));

        //map.Creatures.ForEach(c =>
        //{
        //    c.AddToLog = ConsoleUI.AddMessage;
        //   // c.AddToLog += m => Debug.WriteLine(m);
        //});
        Creature.AddToLog = ui.AddMessage;

        Cell RCell()
        {
            var width = r.Next(0, map.Width);
            var height = r.Next(0, map.Height);

            var cell = map.GetCell(height, width);

            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            return cell;
        }
    }

    private void CreateActionMeny()
    {
        actionMeny = new Dictionary<ConsoleKey, Action>
        {
            { ConsoleKey.P, PickUp },
            { ConsoleKey.I, Inventory },
            { ConsoleKey.D, Drop }
        };
    }

    private void Drop()
    {
        var item = character.BackPack.FirstOrDefault();

        if(item != null && character.BackPack.Remove(item))
        {
            character.Cell.Items.Add(item); 
            ui.AddMessage($"Hero dropped the {item}");
        }
        else
        {
            ui.AddMessage("Backpack is empty");
        }
    }
}
