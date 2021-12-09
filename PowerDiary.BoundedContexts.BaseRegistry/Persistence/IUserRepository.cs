using PowerDiary.BoundedContexts.BaseRegistry.Models;
using PowerDiary.Infrastructure.Database;

namespace PowerDiary.BoundedContexts.BaseRegistry.Persistence
{
	public interface IUserRepository : IRepository<User>
	{
	}
}
