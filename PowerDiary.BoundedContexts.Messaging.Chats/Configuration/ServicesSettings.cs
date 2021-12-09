using Microsoft.Extensions.DependencyInjection;
using PowerDiary.BoundedContexts.Messaging.Chats.Persistence;
 
namespace PowerDiary.BoundedContexts.Messaging.Chats.Configuration
{
	public static class ServicesSettings
	{
		public static IServiceCollection ConfigureChatsDomain(this IServiceCollection services, ServiceLifetime serviceLifetime)
		{
			services.Add(new ServiceDescriptor(typeof(ChatsUnitOfWork), typeof(ChatsUnitOfWork), serviceLifetime));
			services.Add(new ServiceDescriptor(typeof(IChatRepository), typeof(ChatRepository), serviceLifetime));
			services.Add(new ServiceDescriptor(typeof(IMessageRepository), typeof(MessageRepository), serviceLifetime));

			return services;
		}
	}
}
