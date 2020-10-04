using BattleCity.SceneManagement.Enums;
using BattleCity.SceneManagement.Scenes.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.SceneManagement
{
    public interface ISceneManager
    {
        public IScene GetScene();
    }
    public class SceneManager : ISceneManager
    {
        public static Scene CurrentScene;

        private IScene _currentScene;
        private readonly IEnumerable<IScene> _scenes;

        public SceneManager(IEnumerable<IScene> scenes)
        {
            _scenes = scenes;
            CurrentScene = Scene.GameScene;
            _currentScene = _scenes.FirstOrDefault(s => s.IsCurrentScene(CurrentScene));
        }

        public IScene GetScene()
        {
            if (_currentScene.IsCurrentScene(CurrentScene))
            {
                return _currentScene;
            }

            _currentScene = _scenes.FirstOrDefault(s => s.IsCurrentScene(CurrentScene));

            if (_currentScene is IRestartableScene)
            {
                (_currentScene as IRestartableScene).Restart();
            }

            return _currentScene;
        }
    }
}
