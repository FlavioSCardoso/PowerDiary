using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerDiary.BoundedContexts.BaseRegistry.Persistence;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.BoundedContexts.Messaging.Chats.Services.Logs;

namespace ChatClient
{
	internal class RunTheChatClient : IHostedService
	{
		private readonly ILogger<RunTheChatClient> logger;
		private readonly IHourlyLogs hourlyLogs;
		private readonly IMinuteByMinuteLogs minuteByMinuteLogs;
		private readonly IServiceProvider serviceProvider;

		public RunTheChatClient(ILogger<RunTheChatClient> logger,
						  IHourlyLogs hourlyLogs,
						  IMinuteByMinuteLogs minuteByMinuteLogs,
						  IServiceProvider serviceProvider)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.hourlyLogs = hourlyLogs ?? throw new ArgumentNullException(nameof(hourlyLogs));
			this.minuteByMinuteLogs = minuteByMinuteLogs ?? throw new ArgumentNullException(nameof(minuteByMinuteLogs));
			this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await GetData();
			ShowLogs();
		}

		private void ShowLogs()
		{
			Console.Write(minuteByMinuteLogs.ShowLogs());
			Console.WriteLine();
			Console.Write(hourlyLogs.ShowLogs());
		}

		private async Task GetData()
		{
			//This is a workaround to have a db
			var seed = new SeedDBs(serviceProvider.GetRequiredService<BaseRegistryContext>(), serviceProvider.GetRequiredService<ChatsContext>());
			await seed.SeedEmAll();
			//End - This is a workaround to have a db

			var initial = DateTime.Now.AddMinutes(-20);
			var final = DateTime.Now;

			await hourlyLogs.GetMessages(initial, final);
			var messages = hourlyLogs.Messages;

			//this is another workaround to get nice data
			RandomizeHours(messages.ToList());
			hourlyLogs.Messages = messages; //Actualy this was'n supposed be possible
											//End - this is another workaround to get nice data

			await minuteByMinuteLogs.GetMessages(initial, final);
			minuteByMinuteLogs.Messages = messages;
		}

		private static void RandomizeHours(IList<Message> messageList)
		{
			Random random = new();
			int quantity = random.Next(0, messageList.Count);
			for (int i = 0; i < quantity; i++)
			{
				int hoursToAdd = random.Next(0, 3);
				messageList[i].InsertDate = messageList[i].InsertDate.AddHours(hoursToAdd);
				
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			logger.LogInformation("Let's get out! Cheers!");
			Environment.ExitCode = 0;
			return Task.CompletedTask;
		}
	}
}