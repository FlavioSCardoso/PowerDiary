using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Models
{
	public class Message : ModelBase
	{
		public int SenderUserId { get; set; }
		public Chat Chat { get; set; }
		public int ChatId { get; set; }
		public string Content { get; set; }
		public MessageEvent EventType { get; set; }
	}
}
