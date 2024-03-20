using LexiconGame.Extensions;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json", false, reloadOnChange: true)
                            .Build();

//var ui = config.GetSection("game:ui").Value;
//var x = config.GetSection("game:mapsettings:x").Value;

//var mapSettings = config.GetSection("game:mapsettings").GetChildren();

var x = config.GetMapSizeFor("x");
var y = config.GetMapSizeFor("y");


var game = new Game(new ConsoleUI(), new Map(width: y, height: x));
game.Run();

Console.WriteLine("Game over!");
Console.ReadLine();