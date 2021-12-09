using Microsoft.EntityFrameworkCore;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Models.Settings
{
	public static class ChatSettings
	{
		public static void ConfigureSettings(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Chat>()
				.ToTable("Chats");

			modelBuilder.Entity<Chat>()
				.HasMany(c => c.Users);
		}
	}
}
