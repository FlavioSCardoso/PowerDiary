using Microsoft.Extensions.DependencyInjection;
using PowerDiary.BoundedContexts.BaseRegistry.Configuration;

namespace PowerDiary.BoundedContexts.BaseRegistry.Services.Configuration
{
	public static class ServicesSettings
	{
		public static IServiceCollection ConfigureBaseRegistryServices(this IServiceCollection services, ServiceLifetime serviceLifetime)
		{
			services.ConfigureBaseRegistryDomain(serviceLifetime);
			services.Add(new ServiceDescriptor(typeof(IUsersServices), typeof(UsersServices), serviceLifetime));

			return services;

		}
	}
}
