using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Persistence
{
	public class MessageRepository : Repository<Message>, IMessageRepository
	{
		public MessageRepository(ChatsUnitOfWork uow) : base(uow)
		{

		}
	}
}
