using BattleCity.Entities;
using BattleCity.Entities.Enums;

namespace UnitTests.Builders
{
    public class PlayerBuilder
    {
        private MovingDirection _direction; 

        public PlayerBuilder WithDirection(MovingDirection direction)
        {
            _direction = direction;
            return this;
        }

        public Player Build()
        {
            var player = new Player();
            player.Direction = _direction;

            return player;
        }

        public static implicit operator Player(PlayerBuilder builder)
        {
            return builder.Build();
        }
    }
}
