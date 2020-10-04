using BattleCity.Entities.Abstract;
using BattleCity.Entities.Interfaces;
using BattleCity.SceneManagement;
using BattleCity.SceneManagement.Enums;

namespace BattleCity.Entities
{
    public class Life : Entity, IDestroyable
    {
        public void DealDamage(int damage)
        {
            SceneManager.CurrentScene = Scene.LostScene;
        }

        public bool IsDead() => false;
    }
}
