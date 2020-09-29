using BattleCity.DataStructures;
using System;

namespace BattleCity.Entities.Abstract
{
    public class Entity
    {
        public Position Position { get; set; } = new Position();
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
    }
}
