using BattleCity.DataStructures;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;

namespace BattleCity.Entities.Abstract
{
    public abstract class Tank : Entity, IMoveable, IDestroyable
    {
        public int Health { get; private set; }
        public MovingDirection Direction { get; set; }

        public abstract void Move();

        public void MoveToPreviousPosition()
        {
            Position.CurX = Position.PrevX;
            Position.CurY = Position.PrevY;
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
