using BattleCity.DataStructures;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Interfaces;

namespace BattleCity.Entities.Abstract
{
    public abstract class Tank : Entity, IMovable, IDestroyable
    {
        public int Health { get; private set; }
        public MovingDirection Direction { get; protected set; }
        public Position Position { get; set; } = new Position();
        public abstract void Move();
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
        public bool IsDead() => Health <= 0;

    }
}
