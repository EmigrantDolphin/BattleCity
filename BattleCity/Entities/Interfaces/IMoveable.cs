using BattleCity.DataStructures;
using BattleCity.Entities.Enums;

namespace BattleCity.Entities.Interfaces
{
    public interface IMoveable
    {
        public Position Position { get; set; }
        public MovingDirection Direction { get; set; }
        public void Move();
        public void MoveToPreviousPosition();
    }
}
