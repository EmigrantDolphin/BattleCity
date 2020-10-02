using BattleCity.MapControl;
using BattleCity.Options;
using System;
using System.Threading;

namespace BattleCity
{
    public class GameRunner
    {
        private readonly WindowOptions _windowOptions;
        private readonly MapController _mapController;

        public GameRunner(WindowOptions windowOptions, MapController mapController)
        {
            _windowOptions = windowOptions;
            _mapController = mapController;
        }

        public void Run(){

            SetupConsole();

            while (true)
            {
                Thread.Sleep(100);
                _mapController.Act();
            }
        }

        private void SetupConsole()
        {
            Console.CursorVisible = false;
            Console.WriteLine(Console.LargestWindowHeight + " " + Console.LargestWindowWidth);
            Console.SetWindowSize(_windowOptions.Width, _windowOptions.Height);
        }
    }
}