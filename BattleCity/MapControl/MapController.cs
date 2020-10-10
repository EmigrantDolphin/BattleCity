﻿using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;
using BattleCity.Extensions;
using BattleCity.SceneManagement.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.MapControl
{

    public interface IMapController
    {
        public void Act();
        public bool Spawn(Entity entity, char charr);
    }

    public class MapController : IMapController
    {
        private readonly List<List<Map>> _map;
        private readonly IEnumerable<ICondition> _conditions;

        public MapController(IMapRetriever mapRetriever, IEnumerable<ICondition> conditions)
        {
            _map = mapRetriever.ReadMainMap();
            _conditions = conditions;
        }

        public void Act()
        {
            Instantiate();
            Movement();
            CleanDead();
            CheckAndActConditions();
            RedrawMap();
        }

        private void CheckAndActConditions()
        {
            foreach(var condition in _conditions)
            {
                condition.CheckAndAct(_map);
            }
        }

        private void CleanDead()
        {
            var dead = _map.GetMapPoints().Where(p => p.Entity is IDestroyable && (p.Entity as IDestroyable).IsDead()).ToList();
            foreach(var point in dead)
            {
                point.Entity = new Empty();
                point.Char = '.';
            }
        }

        public bool Spawn(Entity entity, char charr)
        {
            //todo: validate
            var mapPoint = _map[entity.Position.CurY][entity.Position.CurX];

            if (mapPoint.Entity is Empty)
            {
                _map[entity.Position.CurY][entity.Position.CurX] = new Map { Entity = entity, Char = charr };
                return true;
            }
            else if (entity is IDamager && mapPoint.Entity is IDestroyable && !(entity as IDamager).IsTargetImmune(mapPoint.Entity as IDestroyable))
            {
                (entity as IDamager).DamageDestroyable(mapPoint.Entity as IDestroyable);
                CleanDead();
            }

            return false;
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

        private void Instantiate()
        {
            var instantiators = GetInstantiators();
            instantiators.ForEach(i => i.InstantiationAction(this));
        }

        private List<IInstantiator> GetInstantiators() => _map.GetMapPoints().Where(mp => mp.Entity is IInstantiator).Select(mp => mp.Entity as IInstantiator).ToList();
        private List<IMoveable> GetMoveables() => _map.GetMapPoints().Where(mp => mp.Entity is IMoveable).Select(mp => mp.Entity as IMoveable).ToList();

        private void ValidateCollision(List<IMoveable> movables)
        {
            bool isOutOfBounds(IMoveable movable) =>
                movable.Position.CurX >= _map[0].Count ||
                movable.Position.CurX < 0 ||
                movable.Position.CurY >= _map.Count ||
                movable.Position.CurY < 0;

            bool isColliding(IMoveable movable) => !(_map[movable.Position.CurY][movable.Position.CurX].Entity is Empty);

            bool isStationary(IMoveable movable) => movable.Direction == MovingDirection.Stationary;

            foreach (var movable in movables)
            {
                if (isStationary(movable))
                {
                    continue;
                }

                if ( isOutOfBounds(movable) )
                {
                    movable.MoveToPreviousPosition();
                }
                else if ( isColliding(movable) )
                {
                    var collidedWith = _map[movable.Position.CurY][movable.Position.CurX];

                    if (collidedWith.Entity is IDestroyable && movable is IDamager && !(movable as IDamager).IsTargetImmune(collidedWith.Entity as IDestroyable))
                    {
                        (movable as IDamager).DamageDestroyable(collidedWith.Entity as IDestroyable);
                    }
                    else
                    {
                        movable.MoveToPreviousPosition();
                    }
                }
                else
                {
                    var swap = _map[movable.Position.CurY][movable.Position.CurX];
                    _map[movable.Position.CurY][movable.Position.CurX] = _map[movable.Position.PrevY][movable.Position.PrevX];
                    _map[movable.Position.PrevY][movable.Position.PrevX] = swap;
                }
            }
        }
    }
}
