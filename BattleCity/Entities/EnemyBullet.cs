using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;
using BattleCity.Entities.Scripts;
using System;

namespace BattleCity.Entities
{
    public class EnemyBullet : Projectile
    {
        public EnemyBullet(MovingDirection direction, int damage, IDestroyable originEntity)
        {
            Damage = damage;
            Color = ConsoleColor.Red;
            OriginEntity = originEntity;
            Direction = direction;
            Health = 1;
        }

        public override bool IsTargetImmune(IDestroyable target)
        {
            return target is Enemy;
        }

        public override void Move()
        {
            DirectionalMovement.Move(Direction, Position);
        }
    }
}
