using Microsoft.EntityFrameworkCore;

namespace PowerDiary.BoundedContexts.BaseRegistry.Models.Settings
{
	public static class UserSettings
	{
		public static void ConfigureSettings(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.ToTable("Users");

			modelBuilder.Entity<User>()
				.HasKey(u => u.Id);

			modelBuilder.Entity<User>()
				.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(100);

			modelBuilder.Entity<User>()
				.Property(u => u.EmailAddress)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
