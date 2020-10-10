using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.SceneManagement;
using BattleCity.SceneManagement.Conditions;
using BattleCity.SceneManagement.Enums;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTests.Builders;

namespace UnitTests
{
    [TestClass]
    public class EnemiesDeadConditionTests
    {
        [TestMethod]
        public void CheckAndActCondition_NoEnemies_ChangesGameStateToWon()
        {
            //Arrange
            SceneManager.CurrentScene = Scene.None;
            List<List<Map>> map = A.Map;
            var enemiesDeadCondition = new EnemiesDeadCondition();

            //Act
            enemiesDeadCondition.CheckAndAct(map);

            //Assert
            SceneManager.CurrentScene.Should().Be(Scene.WonScene);
        }

        [TestMethod]
        public void CheckAndActCondition_WithEnemies_GameStateDoesntChange()
        {
            //Arrange
            var expectedScene = Scene.None;
            SceneManager.CurrentScene = expectedScene;
            List<List<Map>> map = A.Map.ContainsEntity(new Enemy());
            var enemiesDeadCondition = new EnemiesDeadCondition();

            //Act
            enemiesDeadCondition.CheckAndAct(map);

            //Assert
            SceneManager.CurrentScene.Should().Be(expectedScene);
        }
    }
}
