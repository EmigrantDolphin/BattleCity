using BattleCity.Options;
using BattleCity.SceneManagement;
using System;
using System.Threading;

namespace BattleCity
{
    public class GameRunner
    {
        private readonly ISceneManager _sceneManager;

        public GameRunner(WindowOptions windowOptions, ISceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            SetupConsole(windowOptions.Width, windowOptions.Height);
        }

        public void Run(){
            while (true)
            {
                Thread.Sleep(100);
                _sceneManager.GetScene().Act();
            }
        }

        private void SetupConsole(int windowWidth, int windowHeight)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(windowWidth, windowHeight);
        }
    }
}