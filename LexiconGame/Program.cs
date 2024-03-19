using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json", false, reloadOnChange: true)
                            .Build();

var test = config.GetSection("game:ui").Value;

var game = new Game(new ConsoleUI(), new Map(width: 10, height: 10));
game.Run();

Console.WriteLine("Game over!");
Console.ReadLine();