using PowerDiary.BoundedContexts.Messaging.Chats.Models;
using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Persistence
{
	public interface IChatRepository : IRepository<Chat>
	{
	}
}
