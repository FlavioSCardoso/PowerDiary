using Microsoft.Extensions.DependencyInjection;
using PowerDiary.BoundedContexts.BaseRegistry.Persistence;

namespace PowerDiary.BoundedContexts.BaseRegistry.Configuration
{
	public static class ServicesSettings
	{
		public static IServiceCollection ConfigureBaseRegistryDomain(this IServiceCollection services, ServiceLifetime serviceLifetime)
		{
			services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), serviceLifetime));
			services.Add(new ServiceDescriptor(typeof(BaseRegistryUnitOfWork), typeof(BaseRegistryUnitOfWork), serviceLifetime));

			return services;
		}
	}
}
