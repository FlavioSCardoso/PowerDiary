using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Persistence
{
	public class ChatRepository : Repository<Chat>, IChatRepository
	{
		public ChatRepository(ChatsUnitOfWork uow) : base(uow)
		{
		}
	}
}
