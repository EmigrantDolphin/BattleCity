using BattleCity.Entities;
using BattleCity.Entities.Abstract;

namespace BattleCity.Factories
{
    public class EntityFactory
    {
        public Entity GetEntity(char ch)
        {
            return ch switch
            {
                'P' => new Player(),
                'E' => new Enemy(),
                'B' => new DestroyableWall(),
                '#' => new Border(),
                _ => new Empty()
            };
        }
    }
}
