using BattleCity.Entities;
using BattleCity.Entities.Enums;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Builders;

namespace UnitTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerPosition_ShouldMoveRight()
        {
            //Arrange
            Player player = A.Player.WithDirection(MovingDirection.Right);
            var expectedPositionX = player.Position.CurX + 1;

            //Act
            player.Move();

            //Assert 
            player.Position.CurX.Should().Be(expectedPositionX);
        }

        [TestMethod]
        public void PlayerPosition_ShouldMoveLeft()
        {
            //Arrange
            Player player = A.Player.WithDirection(MovingDirection.Left);
            var expectedPositionX = player.Position.CurX - 1;

            //Act
            player.Move();

            //Assert 
            player.Position.CurX.Should().Be(expectedPositionX);
        }

        [TestMethod]
        public void PlayerPosition_ShouldMoveUp()
        {
            //Arrange
            Player player = A.Player.WithDirection(MovingDirection.Up);
            var expectedPositionY = player.Position.CurY - 1;

            //Act
            player.Move();

            //Assert 
            player.Position.CurY.Should().Be(expectedPositionY);
        }

        [TestMethod]
        public void PlayerPosition_ShouldMoveDown()
        {
            //Arrange
            Player player = A.Player.WithDirection(MovingDirection.Down);
            var expectedPositionY = player.Position.CurY + 1;

            //Act
            player.Move();

            //Assert 
            player.Position.CurY.Should().Be(expectedPositionY);
        }

        [TestMethod]
        public void PlayerHealth_ReachesZero_ShouldDie()
        {
            //Arrange
            var player = new Player();
            var health = player.Health;

            //Act
            player.DealDamage(health);

            //Assert
            player.IsDead().Should().BeTrue();
        }
    }
}
