using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Extensions;
using BattleCity.SceneManagement.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.SceneManagement.Conditions
{
    public class EnemiesDeadCondition : ICondition
    {
        public void CheckAndAct(List<List<Map>> map)
        {
            var enemies = map.GetMapPoints().Where(e => e.Entity is Enemy);
            if (!enemies.Any())
            {
                SceneManager.CurrentScene = Scene.WonScene;
            }
        }
    }
}
