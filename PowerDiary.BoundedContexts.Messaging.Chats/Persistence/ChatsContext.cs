using Microsoft.EntityFrameworkCore;
using PowerDiary.BoundedContexts.Messaging.Chats.Models;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Persistence
{
	public class ChatsContext : DbContext
	{
		public ChatsContext(DbContextOptions<ChatsContext> options) : base(options)
		{ }

		public DbSet<Chat> Chats { get; set; }
		public DbSet<Message> Messages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Models.Settings.ChatSettings.ConfigureSettings(modelBuilder);
			Models.Settings.MessageSettings.ConfigureSettings(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}
	}
}
