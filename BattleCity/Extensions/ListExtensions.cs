using BattleCity.DataStructures;
using BattleCity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCity.Extensions
{
    public static class ListExtensions
    {
        public static void ForEachMapPoint(this List<List<Map>> map, Action<Map> action)
        {
            foreach(var mapLine in map)
            {
                foreach(var mapPoint in mapLine)
                {
                    action(mapPoint);
                }
            }
        }

        public static List<Map> GetMapPoints(this List<List<Map>> map)
        {
            var mapPoints = new List<Map>();

            map.ForEachMapPoint(c => mapPoints.Add(c));

            return mapPoints;
        }
    }
}
