using BattleCity.DataStructures;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Scripts;
using BattleCity.MapControl;
using System;

namespace BattleCity.Entities
{
    public class Player : Tank
    {
        private PlayerBullet _bullet;
        public Player()
        {
            Color = ConsoleColor.Green;
            Direction = MovingDirection.Stationary;
        }

        public override void Move()
        {
            ChangeDirection();
            DirectionalMovement.Move(Direction, Position);
        }

        public override void InstantiationAction(IMapController mapController)
        {
            var wasSpacePressed = Input.GetKeyDown(ConsoleKey.Spacebar);

            if (wasSpacePressed && (_bullet == null || _bullet.IsDead()))
            {
                SpawnBullet(mapController);
            }
        }

        private void SpawnBullet(IMapController mapController)
        {
            _bullet = new PlayerBullet(Direction, 1, this);
            _bullet.Position = Position.Clone();
            DirectionalMovement.Move(Direction, _bullet.Position);
            var wasSpawned = mapController.Spawn(_bullet);
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
    }
}
