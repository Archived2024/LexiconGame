var game = new Game(new ConsoleUI(), new Map(width: 10, height: 10));
game.Run();

Console.WriteLine("Game over!");
Console.ReadLine();