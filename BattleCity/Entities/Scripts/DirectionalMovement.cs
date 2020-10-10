using BattleCity.DataStructures;
using BattleCity.Entities.Enums;

namespace BattleCity.Entities.Scripts
{
    public static class DirectionalMovement
    {
        public static void Move(MovingDirection direction, Position position)
        {

            switch (direction)
            {
                case MovingDirection.Up:
                    position.CurY--;
                    break;
                case MovingDirection.Down:
                    position.CurY++;
                    break;
                case MovingDirection.Left:
                    position.CurX--;
                    break;
                case MovingDirection.Right:
                    position.CurX++;
                    break;
            }
        }
    }
}
