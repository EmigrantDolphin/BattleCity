using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;
using BattleCity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Movement();
            RedrawMap();
        }

        private void Movement()
        {
            var moveables = GetMoveables();
            moveables.ForEach(m => m.Move());
            ValidateCollision(moveables);
        }
        
        private void RedrawMap()
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

        private List<IMoveable> GetMoveables() => _map.GetMapPoints().Where(mp => mp.Entity is IMoveable).Select(mp => mp.Entity as IMoveable).ToList();


        private void ValidateCollision(List<IMoveable> tanks)
        {
            bool isOutOfBounds(IMoveable movable) =>
                movable.Position.CurX >= _map[0].Count ||
                movable.Position.CurX < 0 ||
                movable.Position.CurY >= _map.Count ||
                movable.Position.CurY < 0;

            bool isColliding(IMoveable movable) => !(_map[movable.Position.CurY][movable.Position.CurX].Entity is Empty);

            bool isStationary(IMoveable movable) => movable.Direction == MovingDirection.Stationary;

            foreach (var tank in tanks)
            {
                if (isStationary(tank))
                {
                    continue;
                }

                if ( isOutOfBounds(tank) || isColliding(tank) )
                {
                    tank.MoveToPreviousPosition();
                }
                else
                {
                    var swap = _map[tank.Position.CurY][tank.Position.CurX];
                    var debug1 = _map[tank.Position.CurY][tank.Position.CurX];
                    var debug3 = _map[tank.Position.PrevY][tank.Position.PrevX];
                    _map[tank.Position.CurY][tank.Position.CurX] = _map[tank.Position.PrevY][tank.Position.PrevX];
                    var debug2 = _map[tank.Position.CurY][tank.Position.CurX];
                    _map[tank.Position.PrevY][tank.Position.PrevX] = swap;
                }
            }
        }
    }
}
