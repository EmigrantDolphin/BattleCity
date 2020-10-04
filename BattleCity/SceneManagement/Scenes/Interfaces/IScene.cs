
using BattleCity.SceneManagement.Enums;
namespace BattleCity.SceneManagement.Scenes.Interfaces
{
    public interface IScene
    {
        public void Act();
        public bool IsCurrentScene(Scene currentScene);
    }
}
