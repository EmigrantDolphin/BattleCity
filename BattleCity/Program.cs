using Microsoft.Extensions.DependencyInjection;

namespace BattleCity
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<GameRunner>();

            var service = serviceCollection.BuildServiceProvider();
            var game = service.GetService<GameRunner>();
            game.Run();
        }
    }
}
