using BattleCity.SceneManagement.Enums;
using BattleCity.SceneManagement.Scenes.Interfaces;
using System;

namespace BattleCity.SceneManagement.Scenes
{
    public class LostScene : IScene
    {
        public bool IsCurrentScene(Scene currentScene) => currentScene == Scene.LostScene;

        public void Act()
        {
            Console.WriteLine("       You Lost");
            Console.WriteLine("Press Enter to restart");

            Input.WaitForKeyDown(ConsoleKey.Enter);

            SceneManager.CurrentScene = Scene.GameScene;
        }
    }
}
