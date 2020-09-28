using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using System;

namespace BattleCity.Entities
{
    public class Player : Tank
    {
        public Player()
        {
            Color = ConsoleColor.Green;
        }

        public override void Move()
        {
            ChangeDirection();
            MoveInDirection();
            Console.WriteLine(Position.CurX + " " + Position.CurY);
        }

        private void ChangeDirection()
        {
            if (Input.GetKeyDown(ConsoleKey.A))
            {
                Direction = MovingDirection.Left;
            }
            else if (Input.GetKeyDown(ConsoleKey.D))
            {
                Direction = MovingDirection.Right;
            }
            else if (Input.GetKeyDown(ConsoleKey.W))
            {
                Direction = MovingDirection.Up;
            }
            else if (Input.GetKeyDown(ConsoleKey.S))
            {
                Direction = MovingDirection.Down;
            }
        }

        private void MoveInDirection()
        {
            switch (Direction)
            {
                case MovingDirection.Left:
                    Position.CurX--;
                    break;
                case MovingDirection.Right:
                    Position.CurX++;
                    break;
                case MovingDirection.Up:
                    Position.CurY--;
                    break;
                case MovingDirection.Down:
                    Position.CurY++;
                    break;
            }
        }
    }
}
