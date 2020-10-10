using BattleCity.DataStructures;
using System;
using System.Collections.Generic;

namespace BattleCity.MapControl.Components
{
    public static class MapRedrawer
    {
        public static void Redraw(List<List<Map>> mapList)
        {
            Console.SetCursorPosition(0, 0);

            foreach(var mapLine in mapList)
            {
                foreach(var map in mapLine)
                {
                    var cacheColor = Console.ForegroundColor;
                    Console.ForegroundColor = map.Entity == null ? ConsoleColor.White : map.Entity.Color;
                    Console.Write(map.Char);
                    Console.ForegroundColor = cacheColor;
                }
                Console.WriteLine();
            }
        }
    }
}
