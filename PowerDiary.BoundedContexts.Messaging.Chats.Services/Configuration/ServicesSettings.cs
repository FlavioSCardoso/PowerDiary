using Microsoft.Extensions.DependencyInjection;
using PowerDiary.BoundedContexts.Messaging.Chats.Configuration;
using PowerDiary.BoundedContexts.Messaging.Chats.Services.Logs;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Services.Configuration
{
	public static class ServicesSettings
	{
		public static IServiceCollection ConfigureChatsServices(this IServiceCollection services, ServiceLifetime serviceLifetime)
		{
			services.ConfigureChatsDomain(serviceLifetime);
			services.Add(new ServiceDescriptor(typeof(IChatsServices), typeof(ChatsServices), serviceLifetime));
			services.Add(new ServiceDescriptor(typeof(IMessagesServices), typeof(MessagesServices), serviceLifetime));

			return services;
		}

		public static IServiceCollection ConfigureChatsServicesWithLogs(this IServiceCollection services, ServiceLifetime serviceLifetime)
		{
			services.ConfigureChatsServices(serviceLifetime);
			services.Add(new ServiceDescriptor(typeof(IHourlyLogs), typeof(HourlyLogs), serviceLifetime));
			services.Add(new ServiceDescriptor(typeof(IMinuteByMinuteLogs), typeof(MinuteByMinuteLogs), serviceLifetime));

			return services;
		}

	}
}
