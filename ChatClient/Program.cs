using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerDiary.BoundedContexts.BaseRegistry.Persistence;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
using System;
using System.Threading.Tasks;
using PowerDiary.BoundedContexts.Messaging.Chats.Services.Configuration;
using PowerDiary.BoundedContexts.BaseRegistry.Services.Configuration;

namespace ChatClient
{
	class Program
	{

		static async Task<int> Main(string[] args)
		{
			var configuration = Configure();//
			var host = CreateHostBuilder(configuration);
			await host.RunConsoleAsync();
			return Environment.ExitCode;
		}

		private static IConfiguration Configure()
		{
			return new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", true, true)
			.Build();
		}

		private static IHostBuilder CreateHostBuilder(IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("Default");
			return Host.CreateDefaultBuilder()
			.ConfigureLogging(logging =>
			{
				logging.ClearProviders().AddConsole();
			})
			.ConfigureServices((hostContext, services) =>
			{
				services
				.AddHostedService<RunTheChatClient>()
				.ConfigureChatsServicesWithLogs(ServiceLifetime.Singleton)
				.ConfigureBaseRegistryServices(ServiceLifetime.Singleton)
				.AddDbContext<BaseRegistryContext>(options =>
				{
					options.EnableDetailedErrors(true);
					options.UseInMemoryDatabase(connectionString);
				})
				.AddDbContext<ChatsContext>(options =>
				{
					options.EnableDetailedErrors(true);
					options.UseInMemoryDatabase(connectionString);
				});
			}).UseConsoleLifetime();

		}
	}
}
