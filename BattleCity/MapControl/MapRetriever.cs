﻿using BattleCity.DataStructures;
using BattleCity.Extensions;
using BattleCity.Factories;
using BattleCity.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleCity.MapControl
{
    public interface IMapRetriever
    {
        public List<List<Map>> ReadMainMap();
    }

    public class MapRetriever : IMapRetriever
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

            var map = new List<List<Map>>();
            var charMap = streamReader.ReadAllLinesOfCharacters();

            CreateEmptyMap(map, charMap.First().Count, charMap.Count);
            PopulateMap(map, charMap);

            return map;
        }

        private void CreateEmptyMap(List<List<Map>> map, int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                var mapLine = new List<Map>();
                for (int j = 0; j < x; j++)
                {
                    mapLine.Add(new Map());
                }
                map.Add(mapLine);
            }
        }

        private void PopulateMap(List<List<Map>> map, List<List<char>> charMap)
        {
            var entityFactory = new EntityFactory();
            var mapFactory = new MapFactory();

            for (int y = 0; y < charMap.Count; y++)
            {
                for (int x = 0; x < charMap[y].Count; x++)
                {
                    var character = charMap[y][x];
                    var entity = entityFactory.GetEntity(character);
                    var mapPoint = mapFactory.GetWithEntity(entity);
                    entity.Position.CurX = x;
                    entity.Position.CurY = y;
                    map[y][x] = mapPoint;
                }
            }
        }
    }
}
