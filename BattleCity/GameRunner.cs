namespace BattleCity
{
    public class GameRunner
    {
        public void Run(){
            var player = new Player();
            player.AddComponent<PlayerNuts>();
            var playerNuts = player.GetComponent<PlayerNuts>();

            player.Update();
            playerNuts.Update();
            playerNuts.gameObject.Update();
        }
    }
}