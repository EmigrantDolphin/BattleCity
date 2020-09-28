using BattleCity.MapControl;
using BattleCity.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace BattleCity
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input();
            Task.Run(input.StartLoop);

            var services = ConfigureServices(GetConfiguration()).BuildServiceProvider();
            var game = services.GetService<GameRunner>();
            game.Run();
        }

        private static IServiceCollection ConfigureServices(IConfiguration config)
        {
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<WindowOptions>(config.GetSection("WindowOptions").Get<WindowOptions>(c => c.BindNonPublicProperties = true));
            services.AddSingleton<MapOptions>(config.GetSection("MapOptions").Get<MapOptions>(c => c.BindNonPublicProperties = true));


            services.AddTransient<GameRunner>();
            services.AddTransient<MapRetriever>();
            services.AddTransient<MapController>();

            return services;
        }

        private static IConfiguration GetConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    }
}
