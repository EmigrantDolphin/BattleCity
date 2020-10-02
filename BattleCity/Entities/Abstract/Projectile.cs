using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;

namespace BattleCity.Entities.Abstract
{
    public abstract class Projectile : Entity, IMoveable, IDestroyable, IDamager
    {
        protected int Health { get; set; }
        protected int Damage { get; set; }
        public MovingDirection Direction { get; set; }

        public void DamageDestroyable(IDestroyable destroyable)
        {
            destroyable.DealDamage(Damage);
        }

        public void DealDamage(int damage) => Health -= damage;

        public bool IsDead() => Health <= 0;

        public abstract void Move();

        public void MoveToPreviousPosition()
        {
            //todo: get rid of this method from IMoveable
            throw new System.NotImplementedException();
        }
    }
}
