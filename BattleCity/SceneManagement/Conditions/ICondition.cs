using BattleCity.DataStructures;
using System.Collections.Generic;

namespace BattleCity.SceneManagement.Conditions
{
    public interface ICondition
    {
        public void CheckAndAct(List<List<Map>> map);
    }
}
