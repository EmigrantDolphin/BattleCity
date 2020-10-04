using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.MapControl;
using System;
using System.Linq;

namespace BattleCity.Entities
{
    public class Enemy : Tank
    {
        private Bullet _bullet;

        public Enemy()
        {
            Color = ConsoleColor.Red;
            PickNewDirection();
        }

        public override void MoveToPreviousPosition()
        {
            Position.MoveToPrevious();
            PickNewDirection();
        }

        public override void Move()
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

        private void PickNewDirection()
        {
            var possibleDirections = Enum.GetValues(typeof(MovingDirection))
                                         .Cast<MovingDirection>()
                                         .Except(new MovingDirection[] { Direction, MovingDirection.Stationary })
                                         .ToList();
            var random = new Random();
            var randomIndex = random.Next(0, possibleDirections.Count);
            Direction = possibleDirections[randomIndex];
        }

        public override void InstantiationAction(IMapController mapController)
        {
            if (_bullet == null || _bullet.IsDead())
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

    }
}
