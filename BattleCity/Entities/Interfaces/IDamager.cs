
namespace BattleCity.Entities.Interfaces
{
    public interface IDamager
    {
        public bool IsTargetImmune(IDestroyable target);
        public void DamageDestroyable(IDestroyable destroyable);
    }
}
