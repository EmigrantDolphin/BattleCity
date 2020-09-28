using System;

namespace BattleCity
{
    public class PlayerNuts : GameObject
    {
        public PlayerNuts(GameObject go) : base(go)
        {
        }
        public override void Update()
        {
            Console.WriteLine("Player nutz");
        }
    }
}