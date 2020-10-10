using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;
using BattleCity.Entities.Scripts;
using System;

namespace BattleCity.Entities
{
    public class PlayerBullet : Projectile
    {
        public PlayerBullet(MovingDirection direction, int damage, IDestroyable originEntity)
        {
            Damage = damage;
            Color = ConsoleColor.Green;
            OriginEntity = originEntity;
            Direction = direction;
            Health = 1;
        }

        public override bool IsTargetImmune(IDestroyable target)
        {
            return target is Player;
        }

        public override void Move()
        {
            DirectionalMovement.Move(Direction, Position);
        }
    }
}
