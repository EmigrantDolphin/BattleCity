using BattleCity.Entities.Abstract;
using BattleCity.Entities.Interfaces;
using System;

namespace BattleCity.Entities
{
    public class DestroyableWall : Entity, IDestroyable
    {
        private int Health = 1;

        public void DealDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsDead() => Health <= 0;
    }
}
