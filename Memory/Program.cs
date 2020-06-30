using Memory.Bridges;
using Memory.Console.Command;
using Memory.Console.Command.Commands;
using Memory.Console.Command.Services;
using Memory.Data;
using Memory.Data.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Configuration;

namespace Memory
{
    class Program
    {

        static List<ICommand> History { get; set; } = new List<ICommand>();


        static void Main(string[] args)
        {
            string datasource = ConfigurationManager.AppSettings.Get("Datasource");
            //setup our DI
            var serviceCollection = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug);
            serviceCollection.AddDbContext<DataContext>(options =>
                options.UseSqlite(datasource));
            // DAOs
            serviceCollection
                .AddSingleton<AgentDAO>()
                .AddSingleton<MoneyTransferCategoryDAO>()
                .AddSingleton<PersonDAO>()
                ;
            // Command
            serviceCollection
                .AddSingleton<ConsoleWriter>()
                .AddSingleton<ExecutionMain>();

            // Utils
            serviceCollection
                .AddSingleton<ServicesProviderBridge>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            //configure console logging
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            // Get reference and delegate to a Main
            ExecutionMain executionMain
                = serviceProvider.GetRequiredService<ExecutionMain>();
            string v = "start";
            while (!v.StartsWith("exit"))
            {
                v = System.Console.ReadLine();
                System.Console.WriteLine("");
               History.Add(executionMain.Execute(v));
                System.Console.WriteLine("");
                System.Console.WriteLine("");
            }
        }
    }
}
