using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;

namespace BattleCity.Entities
{
    public class Bullet : Projectile
    {
        public Bullet(MovingDirection direction, int damage, IDestroyable originEntity)
        {
            Damage = damage;
            OriginEntity = originEntity;
            Direction = direction;
            Health = 1;
        }

        public override void Move()
        {
            //todo: figure out how to not duplicate this
            switch (Direction)
            {
                case MovingDirection.Left:
                    Position.CurX--;
                    break;
                case MovingDirection.Right:
                    Position.CurX++;
                    break;
                case MovingDirection.Up:
                    Position.CurY--;
                    break;
                case MovingDirection.Down:
                    Position.CurY++;
                    break;
            }
        }
    }
}
