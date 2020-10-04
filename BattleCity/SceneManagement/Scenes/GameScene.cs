using BattleCity.MapControl;
using BattleCity.SceneManagement.Enums;
using BattleCity.SceneManagement.Scenes.Interfaces;

namespace BattleCity.SceneManagement.Scenes
{
    public class GameScene : IScene, IRestartableScene
    {
        private IMapController _mapController;
        private IMapRetriever _mapRetriever;
        public GameScene(IMapRetriever mapRetriever)
        {
            _mapRetriever = mapRetriever;
            Restart();
        }

        public void Restart()
        {
            _mapController = new MapController(_mapRetriever);
        }

        public void Act()
        {
            _mapController.Act();
        }

        public bool IsCurrentScene(Scene currentScene) => currentScene == Scene.GameScene;
    }
}
