using PowerDiary.BoundedContexts.BaseRegistry.Models;
using PowerDiary.Infrastructure.Database;
using System.Collections.Generic;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Models
{
	public class Chat : ModelBase
	{
		public string Title { get; set; }
		public IEnumerable<User> Users { get; set; }
		public IEnumerable<Message> Messages { get; set; }
	}
}
