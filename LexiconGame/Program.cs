using LexiconGame.Entities;
using LexiconGame.Extensions;
using LexiconGame.GameWorld;
using LexiconGame.LinitedList;
using LexiconGame.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json", false, reloadOnChange: true)
                            .Build();

//var ui = config.GetSection("game:ui").Value;
//var x = config.GetSection("game:mapsettings:x").Value;

//var mapSettings = config.GetSection("game:mapsettings").GetChildren();
var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IUI, ConsoleUI>();
                   services.AddSingleton<IConfiguration>(config);
                   services.AddSingleton<IMap, Map>();
                   services.AddSingleton<IMapService, MapService>();
                   services.AddSingleton<Game>();
                   services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
                   // services.AddSingleton<ILimitedList<Item>>(new LimitedList<Item>(3));
                   services.AddSingleton<IMapSettings>(config.GetSection("game:mapsettings").Get<MapSettings>()!);
               })
               .UseConsoleLifetime()
               .Build();

host.Services.GetRequiredService<Game>().Run();

//var game = new Game(new ConsoleUI(), new Map(width: y, height: x));
//game.Run();

Console.WriteLine("Game over!");
Console.ReadLine();