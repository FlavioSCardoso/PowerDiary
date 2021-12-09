using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.Messaging.Chats.Persistence
{
	public class ChatsUnitOfWork : UnitOfWorkBase
	{
		public ChatsUnitOfWork(ChatsContext context) : base(context)
		{ }
	}
}
