using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Extensions;
using BattleCity.SceneManagement.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.SceneManagement.Conditions
{
    public class PlayerDeadCondition : ICondition
    {
        public void CheckAndAct(List<List<Map>> map)
        {
            var players = map.GetMapPoints().Where(p => p.Entity is Player).ToList();
            if (!players.Any())
            {
                SceneManager.CurrentScene = Scene.LostScene;
            }
        }
    }
}
