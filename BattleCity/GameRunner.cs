using BattleCity.Options;
using BattleCity.SceneManagement;
using System;
using System.Threading;

namespace BattleCity
{
    public class GameRunner
    {
        private readonly WindowOptions _windowOptions;
        private readonly ISceneManager _sceneManager;

        public GameRunner(WindowOptions windowOptions, ISceneManager sceneManager)
        {
            _windowOptions = windowOptions;
            _sceneManager = sceneManager;
        }

        public void Run(){

            SetupConsole();

            while (true)
            {
                Thread.Sleep(100);
                _sceneManager.GetScene().Act();
            }
        }

        private void SetupConsole()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(_windowOptions.Width, _windowOptions.Height);
        }
    }
}