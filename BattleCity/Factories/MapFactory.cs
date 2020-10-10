using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Entities.Abstract;
using System;

namespace BattleCity.Factories
{
    public class MapFactory
    {
        public Map GetWithEntity(Entity entity)
        {
            if (entity is PlayerBullet)
            {
                return new Map { Char = 'o', Entity = entity };
            }
            else if (entity is EnemyBullet)
            {
                return new Map { Char = 'o', Entity = entity };
            }
            else if (entity is Empty)
            {
                return new Map { Char = '.', Entity = entity };
            }
            else if (entity is Player)
            {
                return new Map { Char = 'P', Entity = entity };
            }
            else if (entity is Enemy)
            {
                return new Map { Char = 'E', Entity = entity };
            }
            else if (entity is DestroyableWall)
            {
                return new Map { Char = 'B', Entity = entity };
            }
            else if (entity is Border)
            {
                return new Map { Char = '#', Entity = entity };
            }
            else if (entity is Life)
            {
                return new Map { Char = 'L', Entity = entity };
            }
            else if (entity is Empty)
            {
                return new Map { Char = '.', Entity = entity };
            }

            return new Map { Char = '?', Entity = entity };
        }
    }
}
