using BattleCity.Entities.Abstract;
using BattleCity.Entities.Interfaces;
using System;

namespace BattleCity.Entities
{
    public class Life : Entity, IDestroyable
    {
        private bool _isDead = false;

        public Life()
        {
            Color = ConsoleColor.Yellow;
        }

        public void DealDamage(int damage)
        {
            _isDead = true;
        }

        public bool IsDead() => _isDead;
    }
}
