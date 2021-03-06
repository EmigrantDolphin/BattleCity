﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCity
{
    public class Input
    {
        private static ConsoleKey _lastKeyPressed;
        public static bool GetKeyDown(ConsoleKey input)
        {
            if (input == _lastKeyPressed)
            {
                _lastKeyPressed = ConsoleKey.F13;
                return true;
            }
            return false;
        }

        public static void WaitForKeyDown(ConsoleKey input)
        {
            while (input != _lastKeyPressed)
            {
                Thread.Sleep(20);
            }
            _lastKeyPressed = ConsoleKey.F13;
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
