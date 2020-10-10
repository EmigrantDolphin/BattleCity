using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Entities.Abstract;
using BattleCity.Entities.Interfaces;
using BattleCity.Extensions;
using BattleCity.Factories;
using BattleCity.MapControl.Components;
using BattleCity.SceneManagement.Conditions;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.MapControl
{

    public interface IMapController
    {
        public void Act();
        public bool Spawn(Entity entity);
    }

    public class MapController : IMapController
    {
        private readonly List<List<Map>> _map;
        private readonly IEnumerable<ICondition> _conditions;

        public MapController(IMapRetriever mapRetriever, IEnumerable<ICondition> conditions)
        {
            _map = mapRetriever.ReadMainMap();
            _conditions = conditions;
        }

        public void Act()
        {
            Instantiate();
            MapMover.Move(_map);
            CleanDead();
            CheckAndActConditions();
            MapRedrawer.Redraw(_map);
        }

        public bool Spawn(Entity entity)
        {
            var mapPoint = _map[entity.Position.CurY][entity.Position.CurX];

            if (mapPoint.Entity is Empty)
            {
                var newMapPoint = new MapFactory().GetWithEntity(entity);
                _map[entity.Position.CurY][entity.Position.CurX] = newMapPoint;
                return true;
            }
            else if (CanDestroy(entity, mapPoint.Entity))
            {
                (entity as IDamager).DamageDestroyable(mapPoint.Entity as IDestroyable);
                CleanDead();
            }

            return false;
        }

        private void Instantiate()
        {
            var instantiators = _map.GetMapPoints().Where(mp => mp.Entity is IInstantiator).Select(mp => mp.Entity as IInstantiator).ToList();
            instantiators.ForEach(i => i.InstantiationAction(this));
        }

        private void CleanDead()
        {
            var dead = _map.GetMapPoints().Where(p => p.Entity is IDestroyable && (p.Entity as IDestroyable).IsDead()).ToList();
            foreach(var point in dead)
            {
                point.Entity = new Empty();
                point.Char = '.';
            }
        }

        private void CheckAndActConditions()
        {
            foreach(var condition in _conditions)
            {
                condition.CheckAndAct(_map);
            }
        }

        private bool CanDestroy(Entity damager, Entity destroyable) =>
            destroyable is IDestroyable && damager is IDamager && !(damager as IDamager).IsTargetImmune(destroyable as IDestroyable);
    }
}
