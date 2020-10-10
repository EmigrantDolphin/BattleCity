using BattleCity.Entities.Abstract;
using BattleCity.Entities.Enums;
using BattleCity.Entities.Scripts;
using BattleCity.MapControl;
using System;
using System.Linq;

namespace BattleCity.Entities
{
    public class Enemy : Tank
    {
        private EnemyBullet _bullet;

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
            DirectionalMovement.Move(Direction, Position);
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
            _bullet = new EnemyBullet(Direction, 1, this);
            _bullet.Position = Position.Clone();
            DirectionalMovement.Move(Direction, _bullet.Position);
            var wasSpawned = mapController.Spawn(_bullet);
            if (!wasSpawned)
            {
                _bullet = null;
            }
        }

    }
}
