using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconGame.Extensions
{
    public static class ConfigExtensions
    {
        public static Func<IConfiguration, string, int> Implementation { private get; set; } =
            (config, key) =>
            {
                var section = config.GetSection("game:mapsettings");
                return int.TryParse(section[key], out int result) ? result : 0;
            };

        public static int GetMapSizeFor(this IConfiguration config, string key)
        {
           return Implementation(config,key);
        }
    }

    //public interface IGetMapSize
    //{
    //    int GetMapSizeFor(IConfiguration config, string key);
    //}

    //public class GetMapSize : IGetMapSize
    //{
    //    public int GetMapSizeFor(IConfiguration config, string key)
    //    {
    //        var section = config.GetSection("game:mapsettings");
    //        return int.TryParse(section[key], out int result) ? result : 0;
    //    }
    //}
}
