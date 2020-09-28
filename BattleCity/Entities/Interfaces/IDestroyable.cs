
namespace BattleCity.Entities.Interfaces
{
    public interface IDestroyable
    {
        public void DealDamage(int damage);
        public bool IsDead();
    }
}
