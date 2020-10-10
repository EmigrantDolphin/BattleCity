using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;

namespace BattleCity.Entities.Abstract
{
    public abstract class Projectile : Entity, IMoveable, IDestroyable, IDamager
    {
        protected IDestroyable OriginEntity { get; set; }
        protected int Health { get; set; }
        protected int Damage { get; set; }
        public MovingDirection Direction { get; set; }

        public abstract void Move();
        public abstract bool IsTargetImmune(IDestroyable target);

        public void DamageDestroyable(IDestroyable destroyable)
        {
            if (OriginEntity != null && destroyable == OriginEntity)
            {
                return;
            }

            destroyable.DealDamage(Damage);
            Health = 0;
        }

        public void DealDamage(int damage) => Health -= damage;

        public bool IsDead() => Health <= 0;

        public void MoveToPreviousPosition()
        {
            Health = 0;
        }

    }
}
