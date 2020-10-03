using BattleCity.DataStructures;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.MapControl;
using System;

namespace BattleCity.Entities
{
    public class Player : Tank
    {
        private Bullet _bullet;
        public Player()
        {
            Color = ConsoleColor.Green;
            Position.CurX = 5;
            Position.CurY = 5;
            Health = 1;
            Direction = MovingDirection.Stationary;
        }

        public override void Move()
        {
            ChangeDirection();
            MoveInDirection();
            Console.WriteLine(Position.CurX + " " + Position.CurY);
        }

        public override void InstantiationAction(IMapController mapController)
        {
            var wasSpacePressed = Input.GetKeyDown(ConsoleKey.Spacebar);

            if (wasSpacePressed && _bullet == null)
            {
                SpawnBullet(mapController);
            }
            else if (wasSpacePressed && _bullet.IsDead())
            {
                SpawnBullet(mapController);
            }
        }

        private void SpawnBullet(IMapController mapController)
        {
            _bullet = new Bullet(Direction, 1, this);
            _bullet.Position = Position.Clone();
            switch (Direction)
            {
                case MovingDirection.Up:
                    _bullet.Position.CurY--;
                    break;
                case MovingDirection.Down:
                    _bullet.Position.CurY++;
                    break;
                case MovingDirection.Left:
                    _bullet.Position.CurX--;
                    break;
                case MovingDirection.Right:
                    _bullet.Position.CurX++;
                    break;
            }
            var charr = 'o';
            var wasSpawned = mapController.Spawn(_bullet, charr);
            if (!wasSpawned)
            {
                _bullet = null;
            }
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
