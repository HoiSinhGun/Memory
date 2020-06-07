using Memory.Console.Command.Services;
using Memory.Data;
using Memory.Data.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            string datasource = ConfigurationManager.AppSettings.Get("Datasource");
            //setup our DI
            var serviceCollection = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug);
            serviceCollection.AddDbContext<DataContext>(options =>
                options.UseSqlite(datasource));
            serviceCollection
                .AddSingleton<AgentDAO>()
                .AddSingleton<MoneyTransferCategoryDAO>()
                .AddSingleton<PersonDAO>()
                ;
            // Command
            serviceCollection
                .AddSingleton<ConsoleWriter>()
                .AddSingleton<ExecutionMain>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //configure console logging
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            string v = "start";
            while (!v.StartsWith("exit"))
            {
                v = System.Console.ReadLine();
                ExecutionMain.Current().Execute(v);
            }
        }
    }
}
