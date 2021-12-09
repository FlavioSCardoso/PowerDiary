using PowerDiary.BoundedContexts.BaseRegistry.Models;
using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.BaseRegistry.Persistence
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(BaseRegistryUnitOfWork uow) : base(uow)
		{
		}
	}
}
