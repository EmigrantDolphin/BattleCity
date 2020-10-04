using BattleCity.DataStructures;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;
using BattleCity.MapControl;

namespace BattleCity.Entities.Abstract
{
    public abstract class Tank : Entity, IMoveable, IDestroyable, IInstantiator
    {
        public int Health { get; protected set; } = 1;
        public MovingDirection Direction { get; set; }

        public abstract void Move();
        public abstract void InstantiationAction(IMapController mapController);

        public virtual void MoveToPreviousPosition()
        {
            Position.MoveToPrevious();
        }

        public void DealDamage(int damage) 
        {
            if (Health > damage)
            {
                Health -= damage;
            }
            else
            {
                Health = 0;
            }
        }

        public void ReturnToPreviousPosition()
        {
            Position.CurX = Position.PrevX;
            Position.CurY = Position.PrevY;
        }

        public bool IsDead() => Health <= 0;

    }
}
