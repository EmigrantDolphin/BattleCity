using BattleCity.DataStructures;
using BattleCity.Extensions;
using BattleCity.Factories;
using BattleCity.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleCity.MapControl
{
    public class MapRetriever
    {
        private readonly MapOptions _mapOptions;

        public MapRetriever(MapOptions mapOptions)
        {
            _mapOptions = mapOptions;
        }

        public List<List<Map>> ReadMainMap()
        {
            var mapFileLocation = Path.Join(Directory.GetCurrentDirectory(), _mapOptions.RelativeFilePath);
            using var streamReader = new StreamReader(mapFileLocation);
            var entityFactory = new EntityFactory();

            var charMap = streamReader.ReadAllLinesOfCharacters();
            var map = new List<List<Map>>();

            foreach(var line in charMap)
            {
                var mapLine = line.Select(ch => new Map() { Char = ch , Entity = entityFactory.GetEntity(ch)});
                map.Add(mapLine.ToList());
            }

            return map;
        }
    }
}
