using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCity
{
    public class Input
    {
        private static ConsoleKey _lastKeyPressed;
        public static bool GetKeyDown(ConsoleKey input)
        {
            return input == _lastKeyPressed;
        }

        public Task StartLoop()
        {
            while (true)
            {
                Thread.Sleep(20);

                if (Console.KeyAvailable)
                {
                    _lastKeyPressed = Console.ReadKey(true).Key;
                }
            }
        }
    }
}
