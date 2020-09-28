using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCity.MapControl
{

    public interface IMapController
    {
        public void Act();
    }

    public class MapController : IMapController
    {
        private readonly List<List<Map>> _map;

        public MapController(MapRetriever mapRetriever)
        {
            _map = mapRetriever.ReadMainMap();
        }

        public void Act()
        {
            MoveMoveables();
            DrawMap();
        }

        private void DrawMap()
        {
            Console.SetCursorPosition(0, 0);

            foreach(var mapLine in _map)
            {
                foreach(var map in mapLine)
                {
                    var cacheColor = Console.ForegroundColor;
                    Console.ForegroundColor = map.Entity == null ? ConsoleColor.White : map.Entity.Color;
                    Console.Write(map.Char);
                    Console.ForegroundColor = cacheColor;
                }
                Console.WriteLine();
            }
        }

        private void MoveMoveables()
        {
            foreach(var mapLine in _map)
            {
                foreach(var mapPoint in mapLine)
                {
                    if (mapPoint.Entity != null && mapPoint.Entity is IMovable)
                    {
                        var movable = mapPoint.Entity as IMovable;
                        movable.Move();
                        var player = mapPoint.Entity as Player;
                        //todo: sync player position with map position somehow 
                        _map[player.Position.CurX][player.Position.CurY].Char = mapPoint.Char;
                        _map[player.Position.CurX][player.Position.CurY].Entity = mapPoint.Entity;
                    }
                }
            }
        }

        private void ValidateTankPosition(List<Tank> tanks)
        {

        }
    }
}
