using Microsoft.EntityFrameworkCore;
using PowerDiary.BoundedContexts.BaseRegistry.Models;

namespace PowerDiary.BoundedContexts.BaseRegistry.Persistence
{
	public class BaseRegistryContext : DbContext
	{
		public BaseRegistryContext(DbContextOptions<BaseRegistryContext> options) : base(options)
		{ 	}

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Models.Settings.UserSettings.ConfigureSettings(modelBuilder);
			base.OnModelCreating(modelBuilder);
		}
	}
}
