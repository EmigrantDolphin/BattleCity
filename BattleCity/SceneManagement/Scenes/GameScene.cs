using BattleCity.MapControl;
using BattleCity.SceneManagement.Conditions;
using BattleCity.SceneManagement.Enums;
using BattleCity.SceneManagement.Scenes.Interfaces;
using System;
using System.Collections.Generic;

namespace BattleCity.SceneManagement.Scenes
{
    public class GameScene : IScene, IRestartableScene
    {
        private IMapController _mapController;
        private readonly IMapRetriever _mapRetriever;
        private readonly IEnumerable<ICondition> _conditions;

        public GameScene(IMapRetriever mapRetriever, IEnumerable<ICondition> conditions)
        {
            _mapRetriever = mapRetriever;
            _conditions = conditions;
            Restart();
        }

        public void Restart()
        {
            _mapController = new MapController(_mapRetriever, _conditions);
            Console.Clear();
        }

        public void Act()
        {
            _mapController.Act();
        }

        public bool IsCurrentScene(Scene currentScene) => currentScene == Scene.GameScene;
    }
}
