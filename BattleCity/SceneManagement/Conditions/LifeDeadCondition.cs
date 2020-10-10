using BattleCity.DataStructures;
using BattleCity.Entities;
using BattleCity.Extensions;
using BattleCity.SceneManagement.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BattleCity.SceneManagement.Conditions
{
    public class LifeDeadCondition : ICondition
    {
        public void CheckAndAct(List<List<Map>> map)
        {
            var lives = map.GetMapPoints().Where(p => p.Entity is Life);
            if (!lives.Any())
            {
                SceneManager.CurrentScene = Scene.LostScene;
            }
        }
    }
}
