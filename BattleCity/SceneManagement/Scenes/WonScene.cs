using BattleCity.SceneManagement.Enums;
using BattleCity.SceneManagement.Scenes.Interfaces;
using System;

namespace BattleCity.SceneManagement.Scenes
{
    public class WonScene : IScene
    {
        public bool IsCurrentScene(Scene currentScene) => currentScene == Scene.WonScene;
        
        public void Act()
        {
            Console.WriteLine("        You Won");
            Console.WriteLine("Press Enter to play again");
            
            Input.WaitForKeyDown(ConsoleKey.Enter);

            SceneManager.CurrentScene = Scene.GameScene;
        }
    }
}
