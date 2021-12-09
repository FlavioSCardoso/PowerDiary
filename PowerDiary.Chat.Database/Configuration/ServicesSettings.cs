using Microsoft.Extensions.DependencyInjection;

namespace PowerDiary.Infrastructure.Database.Configuration
{
	public static class ServicesSettings
	{
		public static IServiceCollection ConfigureDatabaseInfrastructure(this IServiceCollection services, ServiceLifetime serviceLifetime)
		{
			// If needed 

			return services;
		}
	}
}
