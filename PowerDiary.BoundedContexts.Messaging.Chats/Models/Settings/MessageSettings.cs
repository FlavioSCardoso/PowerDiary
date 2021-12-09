using Microsoft.EntityFrameworkCore;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Models.Settings
{
	public static class MessageSettings
	{
		public static void ConfigureSettings(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Message>()
				.ToTable("Messages");

			modelBuilder.Entity<Message>()
				.HasKey(m => m.Id);

			modelBuilder.Entity<Message>()
				.HasOne(m => m.Chat)
				.WithMany(c => c.Messages)
				.HasForeignKey(m => m.ChatId);

			modelBuilder.Entity<Message>()
				.Property(m => m.Content)
				.HasMaxLength(2048);

			modelBuilder.Entity<Message>()
				.Property(m => m.EventType)
				.HasConversion<int>(x => (int) x, x => (MessageEvent) x);
		}
	}
}
