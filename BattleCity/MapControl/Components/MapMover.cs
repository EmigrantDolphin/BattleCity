using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;
using BattleCity.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.MapControl.Components
{
    public static class MapMover
    {
        public static void Move(List<List<Map>> mapList)
        {
            var moveables = GetMoveables(mapList);
            moveables.ForEach(m => m.Move());
            ValidateCollision(moveables, mapList);
        }

        private static List<IMoveable> GetMoveables(List<List<Map>> map) => 
            map.GetMapPoints().Where(mp => mp.Entity is IMoveable).Select(mp => mp.Entity as IMoveable).ToList();

        private static void ValidateCollision(List<IMoveable> movables, List<List<Map>> map)
        {

            foreach (var movable in movables)
            {
                if (IsStationary(movable))
                {
                    continue;
                }

                if ( IsOutOfBounds(movable, map) )
                {
                    movable.MoveToPreviousPosition();
                }
                else if ( IsColliding(movable, map) )
                {
                    var collidedWith = map[movable.Position.CurY][movable.Position.CurX];

                    if (CanDestroy(movable as Entity, collidedWith.Entity))
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
                    Move(movable, map);
                }
            }
        }

        private static void Move(IMoveable movable, List<List<Map>> map)
        {
            var swap = map[movable.Position.CurY][movable.Position.CurX];
            map[movable.Position.CurY][movable.Position.CurX] = map[movable.Position.PrevY][movable.Position.PrevX];
            map[movable.Position.PrevY][movable.Position.PrevX] = swap;
        }

        private static bool IsOutOfBounds(IMoveable movable, List<List<Map>> map) =>
            movable.Position.CurX >= map[0].Count ||
            movable.Position.CurX < 0 ||
            movable.Position.CurY >= map.Count ||
            movable.Position.CurY < 0;

        private static bool IsColliding(IMoveable movable, List<List<Map>> map) => !(map[movable.Position.CurY][movable.Position.CurX].Entity is Empty);

        private static bool IsStationary(IMoveable movable) => movable.Direction == MovingDirection.Stationary;

        private static bool CanDestroy(Entity damager, Entity destroyable) =>
            destroyable is IDestroyable && damager is IDamager && !(damager as IDamager).IsTargetImmune(destroyable as IDestroyable);

    }
}
