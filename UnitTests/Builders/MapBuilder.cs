using BattleCity.DataStructures;
using BattleCity.Entities.Abstract;
using BattleCity.Factories;
using System.Collections.Generic;

namespace UnitTests.Builders
{
    public class MapBuilder
    {
        private Entity _entity;

        public MapBuilder ContainsEntity(Entity entity)
        {
            _entity = entity;
            return this;
        }

        public List<List<Map>> Build()
        {
            var mapFactory = new MapFactory();
            var map = new List<List<Map>>();
            var mapLine = new List<Map>();

            if (_entity != null)
            {
                mapLine.Add(mapFactory.GetWithEntity(_entity));
            }

            map.Add(mapLine);

            return map;
        }

        public static implicit operator List<List<Map>>(MapBuilder builder)
        {
            return builder.Build();
        }
    }
}
